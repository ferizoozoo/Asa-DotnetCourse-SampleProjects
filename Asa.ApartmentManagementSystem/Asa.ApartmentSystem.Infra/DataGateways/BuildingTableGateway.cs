using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.Infra.DataGateways
{
   public  class BuildingTableGateway
    {
        string _connectionString;
        public BuildingTableGateway(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<int> InsertBuilding(BuildingDTO building)
        {
            return 0;
        }

    }
}
