using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.Infra.DataGateways
{
    public class CostTableGateway : ICostTableGateway
    {
        string _connectionString;
        public CostTableGateway(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task DeleteByIdAsync(int costId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[costs_delete]";
                    cmd.Parameters.AddWithValue("@id", costId);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    var result = await cmd.ExecuteScalarAsync();
                }
            }
        }

        public async Task<CostDTO> GetByIdAsync(int costId)
        {
            var cost = new CostDTO();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[get_cost_by_id]";
                    cmd.Parameters.AddWithValue("@id", costId);
                    cmd.Connection = connection;
                    cmd.Connection.Open();

                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        await dataReader.ReadAsync();

                        cost.Id = dataReader.Extract<int>("id");
                        cost.Title = dataReader.Extract<string>("title");
                        cost.Cost = dataReader.Extract<decimal>("cost");
                        cost.CostGroupId = dataReader.Extract<int>("cost_group_id");
                        cost.From = dataReader.Extract<DateTime>("from");
                        cost.To = dataReader.Extract<DateTime>("to");
                    }
                }
            }
            return cost;
        }

        public async Task<int> InsertAsync(CostDTO cost)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[costs_create]";
                    cmd.Parameters.AddWithValue("@title", cost.Title);
                    cmd.Parameters.AddWithValue("@cost_group_id", cost.CostGroupId);
                    cmd.Parameters.AddWithValue("@from", cost.From);
                    cmd.Parameters.AddWithValue("@to", cost.To);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    var result = await cmd.ExecuteScalarAsync();
                    id = Convert.ToInt32(result);
                }
            }
            return id;
        }

        public async Task UpdateAsync(CostDTO updatedCost)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[costs_update]";
                    cmd.Parameters.AddWithValue("@id", updatedCost.Id);
                    cmd.Parameters.AddWithValue("@title", updatedCost.Title);
                    cmd.Parameters.AddWithValue("@cost_group_id", updatedCost.CostGroupId);
                    cmd.Parameters.AddWithValue("@from", updatedCost.From);
                    cmd.Parameters.AddWithValue("@to", updatedCost.To);
                    cmd.Parameters.AddWithValue("@cost", updatedCost.Cost);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    var result = await cmd.ExecuteScalarAsync();
                }
            }
        }
    }
}
