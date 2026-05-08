using AutoMapper;
using DAL.Models;
using DTO;
using IDAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    internal class EmployeeDal : IEmployeeDal
    {
        private readonly AmusementParkContext _context;//הזרקת הדאטאבייס
        private readonly IMapper _mapper; // הזרקת המאפר
        public EmployeeDal(AmusementParkContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        //return Employees By Attraction
        public async Task<List<EmployeeDTO>> GetEmployeesByAttractionAsync(int id)
        {
           var employeesFromDB=
             await _context.Employees.Where(x => x.AttractionId == id).ToListAsync();

            var employeesDTO= _mapper.Map<List<EmployeeDTO>>(employeesFromDB);
            return employeesDTO;
        }

        //update Employee
        public async Task UpdateEmployeeAsync(EmployeeDTO employee)
        {
            var employeeDAL = _mapper.Map<Employee>(employee);
            _context.Employees.Update(employeeDAL);
            await _context.SaveChangesAsync();
        }

        //delete employee from DB
        public async Task DeleteEmployeeAsync(string id)
        {
            var id2 = await _context.Employees.FindAsync(id);
            if(id2!=null)
            {
                _context.Employees.Remove(id2);
                await _context.SaveChangesAsync();
            }


        }

        //adding Employee to DB
        public async Task CreateEmployeeAsync(EmployeeDTO employee)
        {
            var employeeDAL=_mapper.Map<Employee>(employee);
            await _context.Employees.AddAsync(employeeDAL);
            await _context.SaveChangesAsync();
        }
    }
}
