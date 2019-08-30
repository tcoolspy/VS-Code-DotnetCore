using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using dotnetPartThree.Core.Framework.Enums;
using LinqKit;
using Microsoft.Extensions.Primitives;

namespace dotnetPartThree.Core.Framework.Extensions
{
    public static class QueryableExtensions
    {
       private static readonly MethodInfo ContainsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string)});
        private static readonly MethodInfo ToLowerMethod = typeof(string).GetMethod("ToLower", new Type[] { });
        private static readonly MethodInfo ToStringMethod = typeof(string).GetMethod("ToString", new[] { typeof(string)});

        public static IQueryable<T> SortBy<T>(this IQueryable<T> query, string attributeName, OrderBy? orderBy)
        {
            Type type = typeof(T);
            ParameterExpression param = Expression.Parameter(type, "x");
            Type lambdaType = type.GetProperty(attributeName).PropertyType;

            MethodCallExpression expression = Expression.Call(typeof(Queryable),
                GetOrderByMethodName(orderBy),
                new Type[] {type, lambdaType},
                query.Expression,
                Expression.Lambda(Expression.Property(param, type.GetProperty(attributeName)), param));
            return query.Provider.CreateQuery<T>(expression);
        }

        public static IQueryable<T> SortBy<T>(this IQueryable<T> query, Expression<Func<T, object>> attribute, OrderBy? orderBy)
        {
            Type type = typeof(T);
            ParameterExpression param = Expression.Parameter(type, "x");
            var body = attribute.Body as MemberExpression;
            Type lambdaType = type.GetProperty(body.Member.Name).PropertyType;

            MethodCallExpression expression = Expression.Call(typeof(Queryable), 
                                                GetOrderByMethodName(orderBy),
                                                new Type[] { type, lambdaType},
                                                query.Expression,
                                                Expression.Lambda(Expression.Property(param, type.GetProperty(body.Member.Name)), param));
            return query.Provider.CreateQuery<T>(expression);            
        }

        public static IQueryable<T> SearchBy<T>(this IQueryable<T> query, string searchTerm, string attributeName)
        {
            if (!string.IsNullOrEmpty(attributeName))
            {
                ParameterExpression param = Expression.Parameter(typeof(T), "x");
                MemberExpression memberExpression = Expression.MakeMemberAccess(param, typeof(T).GetProperty(attributeName));
                MethodInfo methodInfo = typeof(string).GetMethod("Contains", new Type[] { typeof(string)});

                var toLowerExpression = Expression.Call(memberExpression, ToLowerMethod);
                var constant = Expression.Constant(searchTerm.ToLower());
                var call = Expression.Call(toLowerExpression, methodInfo, constant);
                Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(call, param);
                var result = query.Where(lambda).AsQueryable();
                return result;
            }
            return new List<T>().AsQueryable();
        }
        
        public static Expression<Func<T, bool>> SearchByFor<T>(this IQueryable<T> query, string searchTerm, string attributeName)
        {
            if (!string.IsNullOrEmpty(attributeName))
            {
                ParameterExpression param = Expression.Parameter(typeof(T), "x");
                MemberExpression memberExpression = Expression.MakeMemberAccess(param, typeof(T).GetProperty(attributeName));
                MethodInfo methodInfo = typeof(string).GetMethod("Contains", new Type[] { typeof(string)});

                var toLowerExpression = Expression.Call(memberExpression, ToLowerMethod);
                var constant = Expression.Constant(searchTerm.ToLower());
                var call = Expression.Call(toLowerExpression, methodInfo, constant);
                Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(call, param);
                return lambda;
            }
            return null;
        }         

        public static IQueryable<T> SearchBy<T>(this IQueryable<T> query, string searchTerm, Expression<Func<T, object>> attribute)
        {
            if (!string.IsNullOrEmpty(attribute.Name))
            {
                ParameterExpression param = Expression.Parameter(typeof(T), "x");
                MemberExpression memberExpression = Expression.MakeMemberAccess(param, typeof(T).GetProperty(attribute.Name));
                MethodInfo methodInfo = typeof(string).GetMethod("Contains", new Type[] { typeof(string)});

                var toLowerExpression = Expression.Call(memberExpression, ToLowerMethod);
                var constant = Expression.Constant(searchTerm.ToLower());
                var call = Expression.Call(toLowerExpression, methodInfo, constant);
                Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(call, param);
                var result = query.Where(lambda).AsQueryable();
                return result;
            }
            return new List<T>().AsQueryable();
        }

        public static IQueryable<T> SearchBy<T>(this IQueryable<T> query, int searchTerm, string attribute)       
        {
            if (!string.IsNullOrEmpty(attribute))
            {
                ParameterExpression param = Expression.Parameter(typeof(T), "x");
                MemberExpression memberExpression = Expression.MakeMemberAccess(param, typeof(T).GetProperty(attribute));
                MethodInfo methodInfo = typeof(int).GetMethod("Equals", new Type[] { typeof(int)});

                var constant = Expression.Constant(searchTerm);
                var call = Expression.Call(memberExpression, methodInfo, constant);
                Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(call, param);
                var result = query.Where(lambda).AsQueryable();
                return result;                
            }
            return new List<T>().AsQueryable();
        }

        public static IQueryable<T> SearchBy<T>(this IQueryable<T> query, string searchTerm, string[] attributes, LambdaLogicalOp logicalOp)
        {
            if (attributes.Any())
            {
                var predicate = PredicateBuilder.New<T>(true);
                foreach (var attibute in attributes)
                {
                    if (!string.IsNullOrEmpty(attibute))
                    {
                        ParameterExpression param = Expression.Parameter(typeof(T), "x");
                        MemberExpression memberExpression = Expression.MakeMemberAccess(param, typeof(T).GetProperty(attibute));

                        // TODO: this assumes properties are of type string.  This will need to be refactored to 
                        // account for numeric and date types
                        MethodInfo methodInfo = typeof(string).GetMethod("Contains",
                                                    new Type[] {
                                                        typeof(string)
                                                    });
                        var toLowerExpression = Expression.Call(memberExpression, ToLowerMethod);
                        var tempSearchTerm = searchTerm; // used to avoid the outer variable trap
                        ConstantExpression constant = Expression.Constant(tempSearchTerm);
                        var call = Expression.Call(toLowerExpression, methodInfo, constant);
                        //var call = Expression.Call(toLowerCall, methodInfo, toLowerCall);
                        Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(call, param);
                        
                        if (logicalOp == LambdaLogicalOp.And)
                        {
                            predicate = predicate.And(lambda);
                        }
                        else
                        {
                            predicate = predicate.Or(lambda);
                        }
                        
                        //query = query.AsExpandable().Where(lambda);
                    }
                }
                query = query.AsExpandable().Where(predicate);//.AsQueryable();
                return query;
            }
            return query;
        }
        
        public static IQueryable<T> SearchBy<T>(this IQueryable<T> query, Dictionary<string, StringValues> searchTerms, LambdaLogicalOp logicalOp)
        {
            if (searchTerms.Any())
            {
                var predicate = PredicateBuilder.New<T>(true);
                foreach (var searchTerm in searchTerms)
                {
                    ParameterExpression param = Expression.Parameter(typeof(T), "x");
                    MemberExpression memberExpression =
                        Expression.MakeMemberAccess(param, typeof(T).GetProperty(searchTerm.Key));

                    // TODO: this assumes properties are of type string.  This will need to be refactored to account for numeric and date types                    
                    MethodInfo methodInfo = typeof(string).GetMethod("Contains", new Type[] {typeof(string)});

                    var toLowerExpression = Expression.Call(memberExpression, ToLowerMethod);
                    var tempSearchTerm = searchTerm.Value.ToString();
                    ConstantExpression constant = Expression.Constant(tempSearchTerm.ToLower());
                    var call = Expression.Call(toLowerExpression, methodInfo, constant);
                    Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(call, param);

                    if (logicalOp == LambdaLogicalOp.And)
                    {
                        predicate = predicate.And(lambda);
                    }
                    else
                    {
                        predicate = predicate.Or(lambda);
                    }
                }

                query = query.AsExpandable().Where(predicate);
                return query;
            }

            return query;
        }

        public static IQueryable<T> SearchByMultiple<T>(this IQueryable<T> query, string searchTerm)
        {
            Type type = typeof(T);
            var predicate = PredicateBuilder.New<T>(true);
            if (type.IsClass)
            {
                
                var props = type.GetProperties().ToList();
                foreach (var prop in props)
                {
                    var propType = prop.PropertyType;
                    if (propType.Name == "String")
                    {
                        // perform search on this property
                        var queryResponse = query.SearchByFor(searchTerm, prop.Name);
                        if (queryResponse != null)
                        {
                            predicate = predicate.Or(queryResponse);
                        }
                    }
                }
            }

            query = query.AsExpandable().Where(predicate);
            return query;
        }
        
        #region Private Methods 

        private static string GetOrderByMethodName(OrderBy? orderBy)
        {
            if (orderBy == null) return "OrderBy";

            switch (orderBy)
            {
                case OrderBy.Ascending:
                    return "OrderBy";
                case OrderBy.Descending:
                    return "OrderByDescending";  
                default: return "OrderBy";
            }
        }

        #endregion // Private Methods     
    }
}