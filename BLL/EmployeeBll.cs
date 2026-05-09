using IDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using DTO;
using IBLL.interfaces;

namespace BLL
{
    public class EmployeeBll : IEmployeeBll
    {
        private readonly IEmployeeDal _employeeDal;

        public EmployeeBll(IEmployeeDal _employeeDal)
        {
            this._employeeDal = _employeeDal;
        }
        public Task<List<EmployeeDTO>> getEmployeesAsync()
        {
            return _employeeDal.GetEmployeesAsync();
        }

        public Task<List<EmployeeDTO>> getEmployeesByAttractionAsync(int id)
        {
            return _employeeDal.GetEmployeesByAttractionAsync(id);
        }
    }
}
