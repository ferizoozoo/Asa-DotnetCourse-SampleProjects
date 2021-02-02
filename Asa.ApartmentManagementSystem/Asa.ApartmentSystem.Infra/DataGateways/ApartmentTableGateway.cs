using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.Infra.DataGateways
{
    public class ApartmentTableGateway : IApartmentTableGateway
    {
        string _connectionString;

        public ApartmentTableGateway(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<int> InsertApartmentUnitAsync(ApartmentUnitDTO apartment)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[apartments_create]";
                    cmd.Parameters.AddWithValue("@Number", apartment.Number);
                    cmd.Parameters.AddWithValue("@BuildingId", apartment.BuildingId);
                    cmd.Parameters.AddWithValue("@Area", apartment.Area);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    var result = await cmd.ExecuteScalarAsync();
                    id = Convert.ToInt32(result);
                }
            }
            return id;
        }

        public async Task<IEnumerable<ApartmentUnitDTO>> GetAllByBuildingId(int buildingId)
        {
            var result = new List<ApartmentUnitDTO>();
            
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[units_get_all]";
                    cmd.Parameters.AddWithValue("@building_id", buildingId);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            //[Id],[building_id],[number] ,[area]
                            var unitDTO = new ApartmentUnitDTO();
                            //unitDTO.BuidlingId = Convert.ToInt32(dataReader["building_id"]);
                            //unitDTO.Id= Convert.ToInt32(dataReader["id"]);
                            //unitDTO.Number= Convert.ToInt32(dataReader["number"]);
                            //unitDTO.Area= Convert.ToDecimal(dataReader["area"]);
                            //unitDTO.Description= Convert.ToString(dataReader["description"]);
                                                        
                            unitDTO.BuildingId = dataReader.Extract<int>("building_id");//== unitDTO.BuidlingId = Extensions.Extract<int>(dataReader,"building_id");
                            unitDTO.Id= dataReader.Extract<int>("id");
                            unitDTO.Number= dataReader.Extract<int>("number");
                            unitDTO.Area= dataReader.Extract<decimal>("area");
                            unitDTO.Description = dataReader.Extract<string>("description",()=>"No description");
                            result.Add(unitDTO);
                        }
                    }
                }
            }
            return result;
        }
    }
}
