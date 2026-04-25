using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDAL.Interfaces
{
    public interface IEmployeeService
    {
        //עובדים
        //פונקציה שמקבלת קוד מתקן ומחזירה את כל העובדים שעובדים בו
        Task<List<EmployeeDTO>> GetEmployeesByAttractionAsync(int id);
 
        //עדכון עובד
        Task UpdateEmployeeAsync(EmployeeDTO employee);
        //מחיקת עובד
        Task DeleteEmployeeAsync(string id);
        //הוספת עובד
        Task CreateEmployeeAsync(EmployeeDTO employee);
    }
}
