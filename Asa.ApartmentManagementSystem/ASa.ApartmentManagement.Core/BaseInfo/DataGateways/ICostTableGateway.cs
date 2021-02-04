using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ASa.ApartmentManagement.Core.BaseInfo.DataGateways
{
    public interface ICostTableGateway
    {
        Task<int> InsertCostAsync(CostDTO cost);
        Task<IEnumerable<CostDTO>> GetCostsById(int costId);
        Task<bool> UpdateCostByIdAsync(int costId, CostDTO updatedCost);
        Task<bool> DeleteCostByIdAsync(int costId);
    }
}
