
using DTO;

namespace IDAL.Interfaces
{
    public interface IAttractionDal
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
