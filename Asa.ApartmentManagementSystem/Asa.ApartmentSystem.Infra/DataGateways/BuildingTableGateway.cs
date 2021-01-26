using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.Infra.DataGateways
{
    public class BuildingTableGateway : IBuildingTableGateway
    {
        string _connectionString;
        public BuildingTableGateway(string connectionString)
        {
            _connectionString = connectionString;
            // Data source= server; Initial catalog= dbname; userID= user; PWD=password

        }

        public async Task<int> InsertBuildingAsync(BuildingDTO building)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "";//Query / Name of the stored procedure
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("Name of the parameter", "the value");
                    //....
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            return id;
        }
    }
}
