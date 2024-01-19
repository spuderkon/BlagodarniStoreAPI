using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.GET;

namespace BlagodarniStoreAPI.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        MeatStoreContext _context;

        public RoleRepository(MeatStoreContext context) 
        {
            _context = context;
        }

        #region GET
        public List<Role> GetAll() 
        {
            return _context.Roles.ToList();
        }

        private IQueryable<Role> LoadData(IQueryable<Role> roles)
        {
            return roles
                  .Select(x => new RoleDTO(x)
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
