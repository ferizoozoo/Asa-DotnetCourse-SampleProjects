using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.BaseInfo.DTOs
{
    public class OwnerTenantInfoDto
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int PersonId { get; set; }
        public int UnitId { get; set; }
        public int Id { get; set; }
        public string UnitNumber { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public bool IsCurrent => !To.HasValue;
    }
}
