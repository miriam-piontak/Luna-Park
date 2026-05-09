
using DTO;

namespace IDAL.Interfaces
{
    public interface IEmployeeDal
    {
        //עובדים
        //פונקציה שמחזירה את כל העובדים
        Task<List<EmployeeDTO>> GetEmployeesAsync();

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
