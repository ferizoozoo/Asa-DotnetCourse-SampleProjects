using ASa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.BaseInfo.DTOs
{
    public class CostGroupDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CostType Type { get; set; }
    }
}
