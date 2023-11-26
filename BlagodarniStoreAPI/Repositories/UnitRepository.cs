using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;

namespace BlagodarniStoreAPI.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        MeatStoreContext _context;

        public UnitRepository(MeatStoreContext context)
        {
            _context = context;
        }

        #region GET
        public List<Unit> GetAll()
        {
            return LoadData(_context.Units).ToList();
        }

        private IQueryable<Unit> LoadData(IQueryable<Unit> units)
        {
            return units
                  .Select(x => new UnitDTO(x)
                  {

                  });
        }

        #endregion

        #region ADD



        #endregion

        #region UPDATE



        #endregion

        #region REMOVE



        #endregion
    }
}
