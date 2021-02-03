using Asa.ApartmentSystem.Infra.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using ASa.ApartmentManagement.Core.BaseInfo.Managers;
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

        public async Task<IEnumerable<ApartmentUnitDTO>> GetUnitsForBuilding(int buildingId)
        {
            var buildingManager = new BuildingManager(tableGatwayFactory);
            var result = await buildingManager.GetAllApartmentUnits(buildingId);
            return result;
        }
    }
}
