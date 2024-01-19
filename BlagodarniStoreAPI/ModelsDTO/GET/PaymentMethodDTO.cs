using BlagodarniStoreAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BlagodarniStoreAPI.ModelsDTO.GET
{
    public class PaymentMethodDTO : PaymentMethod
    {
        public PaymentMethodDTO(PaymentMethod paymentMethod)
        {
            Id = paymentMethod.Id;
            Name = paymentMethod.Name;
        }

        [Key]
        new public int Id { get; set; }
        [StringLength(30)]
        new public string Name { get; set; }

    }
}
