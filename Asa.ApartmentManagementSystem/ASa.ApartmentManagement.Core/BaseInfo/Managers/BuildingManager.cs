using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using ASa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASa.ApartmentManagement.Core.BaseInfo.Managers
{
    public class BuildingManager
    {
        ITableGatwayFactory _tablegatwayFactory;
        public BuildingManager(ITableGatwayFactory tablegatwayFactory)
        {
            _tablegatwayFactory = tablegatwayFactory;
        }
        public int JustForTest(int a, int b)
        {
            return a + b;
        }
        public async Task AddBuilding(BuildingDTO building)
        {
            ValidateBuilding(building);
            var tableGateway = _tablegatwayFactory.CreateBuildingTableGateway();
            var id = await tableGateway.InsertBuildingAsync(building).ConfigureAwait(false);
            building.Id = id;

        }

        private static void ValidateBuilding(BuildingDTO building)
        {
            const int MAX_BUILDING_NAME_LENGTH = 50;
            var buildingNameIsValid = string.IsNullOrWhiteSpace(building.Name) || building.Name.Length > MAX_BUILDING_NAME_LENGTH;
            if (buildingNameIsValid)
            {
                throw new ValidationException(ErrorCodes.Invalid_Building_Name, $"Building name cannot be neither empty nor larger than {MAX_BUILDING_NAME_LENGTH} character");
            }
            const int MINIMUM_BUILDING_UNITS_COUNT = 1;
            if (building.NumberOfUnits < MINIMUM_BUILDING_UNITS_COUNT)
            {
                throw new ValidationException(ErrorCodes.Invalid_Number_Of_Units, $"The number of units cannot be less than {MINIMUM_BUILDING_UNITS_COUNT }.");
            }
        }

        public async Task AddApartment(ApartmentUnitDTO apartment)
        {
            const decimal MAX_APARTMENT_AREA = 100;
            const decimal MIN_APARTMENT_AREA = 10;

            if (apartment.Number < 0)
                throw new ValidationException(ErrorCodes.Invalid_Number_Of_Apartment, "Apartment number cannot be less than 0.");

            if (apartment.Area > MAX_APARTMENT_AREA)
                throw new ValidationException(ErrorCodes.Maximum_Violation_Of_Area, $"The area of the apartment {apartment.Id} cannot be less than {MIN_APARTMENT_AREA} squaremeters.");

            if (apartment.Area < MIN_APARTMENT_AREA)
                throw new ValidationException(ErrorCodes.Minimum_Violation_Of_Area, $"The area of the apartment {apartment.Id} cannot be less than {MIN_APARTMENT_AREA} squaremeters.");

            IApartmentTableGateway tableGateway = _tablegatwayFactory.CreateIApartmentTableGateway();
            var id = await tableGateway.InsertApartmentUnitAsync(apartment).ConfigureAwait(false);
            apartment.Id = id;
        }

        public async Task<IEnumerable<ApartmentUnitDTO>> GetAllApartmentUnits(int buildingId)
        {
            var tableGateway = _tablegatwayFactory.CreateIApartmentTableGateway();
            return  await tableGateway.GetAllByBuildingId(buildingId).ConfigureAwait(false);            
        }
    }
}
