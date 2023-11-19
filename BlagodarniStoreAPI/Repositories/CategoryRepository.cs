using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;

namespace BlagodarniStoreAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        MeatStoreContext _context;

        public CategoryRepository(MeatStoreContext context)
        {
            _context = context;
        }

        #region GET
        public List<Category> GetAll()
        {
            var categories = _context.Categories;
            return LoadData(categories).ToList();
        }

        private IQueryable<Category> LoadData(IQueryable<Category> categories)
        {
            return categories
                  .Select(x => new CategoryDTO(x)
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
