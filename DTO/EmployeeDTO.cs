using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class EmployeeDTO
    {
        public string EmployeeTz { get; set; } = null!;
        public string FullName { get; set; } = null!;

        public int AttractionId { get; set; }
        public string AttractionName { get; set; }


    }
}
