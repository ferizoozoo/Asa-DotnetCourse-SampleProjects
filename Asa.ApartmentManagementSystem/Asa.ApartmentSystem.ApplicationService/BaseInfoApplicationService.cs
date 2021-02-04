using Asa.ApartmentSystem.Infra.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using ASa.ApartmentManagement.Core.BaseInfo.Managers;
using ASa.ApartmentManagement.Core.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.ApplicationService
{
    public class BaseInfoApplicationService
    {
        ITableGatwayFactory tableGatwayFactory;
        BuildingManager buildingManager;

        public BaseInfoApplicationService(string connectionString)
        {
            //HACK: This approach is not the best one, we will change it as soon as DI tools get introduced
            tableGatwayFactory = new SqlTableGatewayFactory(connectionString);

            buildingManager = new BuildingManager(tableGatwayFactory);
        }
        public async Task<int> CreateBuilding(string Name, int numberofUnits)
        {
            var buildingDto = new BuildingDTO { Name = Name, NumberOfUnits = numberofUnits };
            await buildingManager.AddBuilding(buildingDto);
            return buildingDto.Id;
        }
        public async Task<IEnumerable<OwnerTenantInfoDto>> GetAllOwnerTenantByUnitId(int unitid)
        {
            return await buildingManager.GetAllOwnerTenantByUnitId(unitid);
        }

        public async Task<int> CreateApartment(int number, int buildingId, decimal area)
        {
            var apartmentDto = new ApartmentUnitDTO { Number = number, BuildingId = buildingId, Area = area };
            await buildingManager.AddApartment(apartmentDto);
            return apartmentDto.Id;
        }

        public async Task<int> CreatePerson(string name, string lastName)
        {
            var personDto = new PersonDTO { Name = name, LastName = lastName };
            await buildingManager.AddPerson(personDto);
            return personDto.Id;
        }

        public async Task<IEnumerable<OwnerTenantInfoDto>> GetUnitsForBuilding(int unitid)
        {
            return await buildingManager.GetAllOwnerTenantByUnitId(unitid);            
        }

        public async Task<int> CreateCost(string title, int costGroupId, DateTime from, DateTime to, decimal cost)
        {
            var costDto = new CostDTO
            {
                Title = title,
                CostGroupId = costGroupId,
                From = from,
                To = to,
                Cost = cost
            };
            await buildingManager.AddCost(costDto);
            return costDto.Id;
        }

        public async Task<CostDTO> GetCost(int costId)
        {
            return await buildingManager.GetCost(costId);
        }

        public async Task UpdateCost(CostDTO cost)
        {
            await buildingManager.UpdateCost(cost);
        }

        public async Task DeleteCost(int costId)
        {
            await buildingManager.DeleteCost(costId);
        }
    }
}
