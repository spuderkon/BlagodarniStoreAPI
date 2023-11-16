using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BlagodarniStoreAPI.ModelsDTO
{
    public class PaymentMethodDTO : PaymentMethod
    {
        public PaymentMethodDTO(PaymentMethod paymentMethod) 
        { 
            Id = paymentMethod.Id;
            Name = paymentMethod.Name;
        }

        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }

    }
}
