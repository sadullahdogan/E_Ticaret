using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret_Entity.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Fiyat")]
        public double Price { get; set; }
        public double Rating { get; set; }
        [DisplayName("Stok Adeti")]
        public int Stock { get; set; }
        [DisplayName(" Ürün Resmi")]
        public string Image { get; set; }
        [DisplayName("Onaylandı mı")]
        public bool IsApproved { get; set; } //Onaylı mı? onaylıysa satışta olacak
        [DisplayName("Anasayfa Görünürlüğü")]
        public bool IsHome { get; set; } //Anasayfada görünsün mü?
        [DisplayName("Kategori")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
