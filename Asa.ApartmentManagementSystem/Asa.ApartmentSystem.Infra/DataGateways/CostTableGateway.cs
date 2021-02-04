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

        public async Task<bool> DeleteCostByIdAsync(int costId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CostDTO>> GetCostsById(int costId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertCostAsync(CostDTO cost)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[costs_create]";
                    cmd.Parameters.AddWithValue("@title", cost.Title);
                    cmd.Parameters.AddWithValue("@group", cost.Group);
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

        public async Task<bool> UpdateCostByIdAsync(int costId, CostDTO updatedCost)
        {
            throw new NotImplementedException();
        }
    }
}
