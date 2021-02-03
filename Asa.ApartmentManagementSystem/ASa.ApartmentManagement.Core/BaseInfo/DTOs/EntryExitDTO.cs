using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.BaseInfo.DTOs
{
    class EntryExitDTO
    {
        public int PersonId { get; set; }
        public int UnitId { get; set; }
        public DateTime Entry { get; set; }
        public DateTime Exit { get; set; }
    }
}
