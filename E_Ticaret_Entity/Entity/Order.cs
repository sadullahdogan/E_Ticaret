using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret_Entity.Entity
{
    public class Order
    {
        public int Id { get; set; }

        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen bir adres bilgisi giriniz. ")]
        public string AdresBilgi { get; set; }
        [Required(ErrorMessage = "Lütfen bir adres bilgisi giriniz. ")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Lütfen bir adres giriniz. ")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Lütfen bir sehir giriniz. ")]
        public string Semt { get; set; }
        [Required(ErrorMessage = "Lütfen bir semt giriniz. ")]
        public string Mahalle { get; set; }
        [Required(ErrorMessage = "Lütfen bir posta kodu giriniz. ")]
        public string PostaKodu { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int Quentity { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
    public enum EnumOrderState { 
    [Display(Name="Onay Bekleniyor")]
    Waiting,
    [Display(Name = "Sipariş Tamamlandı")]
    Completed

    }
}
