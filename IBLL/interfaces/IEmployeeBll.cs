using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBLL.interfaces
{
    internal interface IEmployeeBll
    {
        //get all employees by attraction
        Task<List<EmployeeDTO>> getEmployeesByAttractionAsync(int id);

        //get all employees
        Task<List<EmployeeDTO>> getEmployeesAsync();
    }
}
