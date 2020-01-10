using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret_DLL.Models
{
   public  class ShippingDetails
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage ="Lütfen bir adres bilgisi giriniz. ")]
        public string AdresBilgi { get; set; }
        [Required(ErrorMessage ="Lütfen bir adres bilgisi giriniz. ")]
        public string Adres { get; set; }
        [Required(ErrorMessage ="Lütfen bir adres giriniz. ")]
        public string Sehir { get; set; }
        [Required(ErrorMessage ="Lütfen bir sehir giriniz. ")]
        public string Semt { get; set; }
        [Required(ErrorMessage ="Lütfen bir semt giriniz. ")]
        public string Mahalle { get; set; }
        [Required(ErrorMessage ="Lütfen bir posta kodu giriniz. ")]
        public string PostaKodu { get; set; }
    }
}
