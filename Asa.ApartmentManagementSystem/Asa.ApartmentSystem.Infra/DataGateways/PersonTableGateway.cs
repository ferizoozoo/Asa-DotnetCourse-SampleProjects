using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.Infra.DataGateways
{
    public class PersonTableGateway : IPersonTableGateway
    {
        string _connectionString;
        public PersonTableGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> InsertPersonAsync(PersonDTO person)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[persons_create]";
                    cmd.Parameters.AddWithValue("@name", person.Name);
                    cmd.Parameters.AddWithValue("@lastname", person.LastName);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    var result = await cmd.ExecuteScalarAsync();
                    id = Convert.ToInt32(result);
                }
            }
            return id;
        }
    }
}