using Dapper;
using Northwind.Models;
using Northwind.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Northwind.DataAccess
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString) 
        { 
         
        
        }

        public IEnumerable<CustomerList> CustomerPagedList(int page, int rows)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@page", page);
            parameter.Add("@rows", rows);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<CustomerList>("dbo.CustomerPagedList",parameter, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
