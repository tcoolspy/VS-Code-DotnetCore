namespace dotnetPartThree.Core.Framework.Implementations
{
   /// <summary>
    /// Used as the default response type within a generic repository.  Applies to Add, Delete and Update operations.
    /// </summary>
    /// <typeparam name="T">A generic type parameter that coincides with the specific type of a generic repository implementation.</typeparam>    
    public class CrudResponse<T>
    {
        /// <summary>
        /// Used to determine whether the CRUD operation succeeded or not.
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Used to communicate a custom message related to the CRUD operations success or failure
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// The specific type of object that the operation is performed on.
        /// </summary>
        /// <remarks>
        /// The most common use case for this is to return a newly created/added object to the calling method.
        /// </remarks>
        public T Entity { get; set; }        
    }
}