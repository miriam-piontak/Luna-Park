using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int TicketPrice { get; set; }

    public int AttractionId { get; set; }

    public string EmployeeId { get; set; } = null!;

    public DateTime TicketStartDateTime { get; set; }

    public virtual Attraction Attraction { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
