﻿using Dapper;
using Northwind.Models;
using Northwind.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Northwind.DataAccess
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Supplier> SupplierPagedList(int page, int rows, string searchTerm)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@page", page);
            parameter.Add("@rows", rows);
            parameter.Add("@searchTerm", searchTerm);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Supplier>("dbo.SupplierPagedList", parameter, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
