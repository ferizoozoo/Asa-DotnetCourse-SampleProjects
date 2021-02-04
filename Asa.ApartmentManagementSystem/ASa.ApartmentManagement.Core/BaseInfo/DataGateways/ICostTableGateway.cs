using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ASa.ApartmentManagement.Core.BaseInfo.DataGateways
{
    public interface ICostTableGateway
    {
        Task<int> InsertAsync(CostDTO cost);
        Task<CostDTO> GetByIdAsync(int costId);
        Task UpdateAsync(CostDTO updatedCost);
        Task DeleteByIdAsync(int costId);
    }
}
