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
        
        public async Task AddBuilding(BuildingDTO building)
        {
            Validators.ValidateBuilding(building);
            IBuildingTableGateway tableGateway = _tablegatwayFactory.CreateBuildingTableGateway();
            var id = await tableGateway.InsertBuildingAsync(building).ConfigureAwait(false);
            building.Id = id;
        }
        
        public async Task<IEnumerable<OwnerTenantInfoDto>> GetAllOwnerTenantByUnitId(int unitId)
        {}

        public async Task AddApartment(ApartmentUnitDTO apartment)
        {
            Validators.ValidateApartmentUnit(apartment);
            IApartmentTableGateway tableGateway = _tablegatwayFactory.CreateIApartmentTableGateway();
            var id = await tableGateway.InsertApartmentUnitAsync(apartment).ConfigureAwait(false);
            apartment.Id = id;
        }

        public async Task<IEnumerable<ApartmentUnitDTO>> GetAllApartmentUnits(int unitId)
        {
            if (unitId < 1)
            {
                return new List<OwnerTenantInfoDto>();
            }
            var tableGateway = _tablegatwayFactory.CreateIApartmentTableGateway();
            return await tableGateway.GetAllOwnerTenant(unitId).ConfigureAwait(false);            
        }

        public async Task AddPerson(PersonDTO person)
        {
            Validators.ValidatePerson(person);
            IPersonTableGateway tableGateway = _tablegatwayFactory.CreateIPersonTableGateway();
            var id = await tableGateway.InsertPersonAsync(person).ConfigureAwait(false);
            person.Id = id;
        }

        public async Task<int> AddCost(CostDTO cost)
        {
            ICostTableGateway tableGateway = _tablegatwayFactory.CreateICostTableGateway();
            var id = await tableGateway.InsertAsync(cost).ConfigureAwait(false);
            return id;
        }

        public async Task<CostDTO> GetCost(int costId)
        {
            ICostTableGateway tableGateway = _tablegatwayFactory.CreateICostTableGateway();
            return await tableGateway.GetByIdAsync(costId);
        }

        public async Task UpdateCost(CostDTO cost)
        {
            ICostTableGateway tableGateway = _tablegatwayFactory.CreateICostTableGateway();
            await tableGateway.UpdateAsync(cost);
        }

        public async Task DeleteCost(int costId)
        {
            ICostTableGateway tableGateway = _tablegatwayFactory.CreateICostTableGateway();
            await tableGateway.DeleteByIdAsync(costId);
        }
    }
}
