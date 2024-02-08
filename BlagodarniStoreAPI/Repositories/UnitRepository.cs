using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.GET;
using BlagodarniStoreAPI.ModelsDTO.POST;

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

        public Unit Add(CreateUnitDTO unit)
        {
            var newUnit = new Unit
            {
                Measure = unit.Measure,
                Name = unit.Name,
            };
            _context.Units.Add(newUnit);
            _context.SaveChanges();
            return newUnit;
        }

        #endregion

        #region UPDATE



        #endregion

        #region REMOVE



        #endregion
    }
}
