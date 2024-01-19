using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.GET;

namespace BlagodarniStoreAPI.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly MeatStoreContext _context;

        public PaymentMethodRepository(MeatStoreContext context)
        {
            _context = context;
        }

        #region GET
        public List<PaymentMethod> GetAll()
        {
            return _context.PaymentMethods.ToList();
        }
        #endregion

        #region TOOLMETHODS

        private IQueryable<PaymentMethod> LoadData(IQueryable<PaymentMethod> paymentMethods)
        {
            return paymentMethods
                  .Select(x => new PaymentMethodDTO(x)
                  {
                  });
        }

        #endregion
    }
}
