using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace IDAL.Interfaces
{
    public interface IAttractionService
    {
        //מתקנים
        // Method to retrieve all attractions
        Task<List<AttractionDTO>> GetAllAttractionsAsync();
        //פונקציה שמקבלת קוד מתקן ומחזירה פרטים
        Task<AttractionDTO> GetAttractionByIdAsync(int id);
        //עדכון מתקן
        Task UpdateAttractionAsync(AttractionDTO attraction);
        //מחיקת מתקן
        Task DeleteAttractionAsync(int id);
        //הוספת מתקן
        Task CreateAttractionAsync(AttractionDTO attraction);

    }
}
