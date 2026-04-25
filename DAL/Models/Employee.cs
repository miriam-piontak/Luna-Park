using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Employee
{
    public string EmployeeTz { get; set; } = null!;

    public string EmployeeFirstName { get; set; } = null!;

    public string EmployeeLastName { get; set; } = null!;

    public int AttractionId { get; set; }

    public virtual Attraction Attraction { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
