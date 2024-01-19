using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IPaymentMethodRepository
    {
        public List<PaymentMethod> GetAll();
    }
}
