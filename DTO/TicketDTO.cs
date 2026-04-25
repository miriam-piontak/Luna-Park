using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class TicketDTO
    {
        public int TicketId { get; set; }
        public int TicketPrice { get; set; }

        public int AttractionId { get; set; }
        public string AttractionName { get; set; } = null!;

        public string EmployeeId { get; set; } = null!;
        public string SellerName { get; set; } = null!;
    }
}
