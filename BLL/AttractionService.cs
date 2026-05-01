using IDAL.Interfaces;
using DAL
namespace BLL
{
    public class AttractionService : IAttractionDal
    {
        private readonly IAttractionDal _attractionDal;

        public AttractionService()
        {
        }
    }
}
