using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using IBLL.interfaces;
using IDAL.Interfaces;

namespace BLL
{
    public class AttractionBll : IAttractionBll
    {
        private readonly IAttractionDal _attractionDal;

        public AttractionBll(IAttractionDal attractionDal)
        {
            this._attractionDal = attractionDal;
        }

        public Task<List<AttractionDTO>> GetAllAttractionsAsync()
        {
            return _attractionDal.GetAllAttractionsAsync();
        }

        public Task<AttractionDTO> getDetailsAsync(int id)
        {
            return _attractionDal.GetAttractionByIdAsync(id);
        }
    }
}
