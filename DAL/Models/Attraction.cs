using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Attraction
{
    public int AttractionId { get; set; }

    public string AttractionName { get; set; } = null!;

    public int MaxCapacity { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
