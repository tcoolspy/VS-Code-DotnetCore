using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using dotnetPartThree.Core.Framework.Contracts.Ado;
using dotnetPartThree.Core.Models;

namespace dotnetPartThree.Data.Repositories.Ado
{
    public class CustomerDAL : BaseAdoRepository<Customer>, ICustomerDAL
    {
        public IUnitOfWork _unitOfWork;
        public SqlTransaction _sqlTransaction;

        public CustomerDAL(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
            _sqlTransaction = _unitOfWork.BeginTransaction();
        }

        protected override void InsertCommandParameters(Customer entity, SqlCommand cmd, string cmdText = null)
        {
            cmd.CommandText = "spInsert"; // NOTE: change to appropriate stored proc
            cmd.CommandType = CommandType.StoredProcedure; // NOTE: change if needed.
            cmd.Transaction = _sqlTransaction;
            cmd.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
            cmd.Parameters.AddWithValue("@CompanyName", entity.CompanyName);
            // etc.
        }

        protected override void UpdateCommandParameters(Customer entity, SqlCommand cmd, string cmdText = null)
        {
            cmd.CommandText = "spUpdate"; // NOTE: change to appropriate stored proc
            cmd.CommandType = CommandType.StoredProcedure; // NOTE: change if needed.
            cmd.Transaction = _sqlTransaction;
            cmd.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
            cmd.Parameters.AddWithValue("@CompanyName", entity.CompanyName);
            // etc.
        }

        protected override void DeleteCommandParameters(Customer entity, SqlCommand cmd, string cmdText = null)
        {
            base.DeleteCommandParameters(entity, cmd, cmdText);
        }

        protected override Customer Map(SqlDataReader reader)
        {
            Customer customer = new Customer();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    customer.Address = reader["Address"].ToString();
                    customer.City = reader["City"].ToString();
                    // etc.
                }
            }

            return customer;
        }

        protected override List<Customer> Maps(SqlDataReader reader)
        {
            List<Customer> customers = new List<Customer>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Customer customer = new Customer();

                    customer.Address = reader["Address"].ToString();
                    customer.City = reader["City"].ToString();
                    // etc.
                }
            }
            
            return customers;
        }

        public void Create(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new System.NotImplementedException();
        }
    }
}