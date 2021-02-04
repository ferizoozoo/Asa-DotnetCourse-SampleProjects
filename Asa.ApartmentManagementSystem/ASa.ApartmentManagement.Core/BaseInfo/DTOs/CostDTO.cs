using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.BaseInfo.DTOs
{
    public class CostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CostGroupDTO Group { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal Cost { get; set; }
    }
}
