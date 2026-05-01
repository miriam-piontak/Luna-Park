using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDAL.Interfaces
{
    public interface ITicketDal
    {
        //כרטיסים
        //מחזיר את כל הכרטיסים לפי מתקן
        Task<List<TicketDTO>> GetAllTicketsByAttractionAsync(int id);
        //עדכון כרטיס
        Task UpdateTicketAsync(TicketDTO ticket);
        //מחיקת כרטיס
        Task DeleteTicketAsync(int id);
        //הוספת כרטיס
        Task CreateTicketAsync(TicketDTO ticket);
    }
}
