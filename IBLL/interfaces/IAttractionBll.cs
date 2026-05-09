using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBLL.interfaces
{
    public interface IAttractionBll
    {
        //get all attrction
        Task<List<AttractionDTO>> GetAllAttractionsAsync();
        //get attracion details
        Task<AttractionDTO> getDetailsAsync(int id);
    }
}
