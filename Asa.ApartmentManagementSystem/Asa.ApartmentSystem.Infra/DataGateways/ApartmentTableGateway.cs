using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Sql;
using System.Threading.Tasks;
using System.Data;

namespace Asa.ApartmentSystem.Infra.DataGateways
{
    public class ApartmentTableGateway : IApartmentTableGateway
    {
        string _connectionString;

        public ApartmentTableGateway(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
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

                            unitDTO.BuidlingId = dataReader.Extract<int>("building_id");//== unitDTO.BuidlingId = Extensions.Extract<int>(dataReader,"building_id");
                            unitDTO.Id = dataReader.Extract<int>("id");
                            unitDTO.Number = dataReader.Extract<int>("number");
                            unitDTO.Area = dataReader.Extract<decimal>("area");
                            unitDTO.Description = dataReader.Extract<string>("description", () => "No description");
                            result.Add(unitDTO);
                        }
                    }
                }
            }
            return result;
        }

        public async Task<IEnumerable<OwnerTenantInfoDto>> GetAllOwnerTenant(int unitId)
        {
            var result = new List<OwnerTenantInfoDto>();
            DataTable dataTable = new DataTable();
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[unit_get_all_owner_tenant]";
                    cmd.Parameters.AddWithValue("@unit_id", unitId);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                }
            }

            foreach (DataRow item in dataTable.Rows)
            {
                var dto = new OwnerTenantInfoDto
                {
                    FullName = Convert.ToString(item["full_name"]),
                    From = Convert.ToDateTime(item["from_date"]),
                    Id = Convert.ToInt32(item["owner_tenant_id"]),
                    PersonId = Convert.ToInt32(item["person_id"]),
                    PhoneNumber = Convert.ToString(item["phone_number"]),
                    UnitNumber = Convert.ToString(item["unit_number"]),
                    UnitId = unitId,
                    To = item["to_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(item["to_date"]),
                };
                result.Add(dto);
            }

            //var items =
            //    dataTable.Rows.AsQueryable()
            //    .OfType<DataRow>()
            //    .Select(item => new OwnerTenantInfoDto
            //    {
            //        FullName = Convert.ToString(item["full_name"]),
            //        From = Convert.ToDateTime(item["from_date"]),
            //        Id = Convert.ToInt32(item["owner_tenant_id"]),
            //        PersonId = Convert.ToInt32(item["person_id"]),
            //        PhoneNumber = Convert.ToString(item["phone_number"]),
            //        UnitNumber = Convert.ToString(item["unit_number"]),
            //        UnitId = unitId,
            //        To = item["to_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(item["to_date"]),
            //    });
            //result.AddRange(items);
            return result;
        }
    }
}
