using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret_DLL.Models
{
    public class RegisterModel
    {
        [Required, DisplayName("Adınız")]
        public string Name { get; set; }
        [Required, DisplayName("Soy Adınız")]
        public string Surname { get; set; }
        [Required, DisplayName("E-Posta Adresi"), DataType(DataType.EmailAddress,ErrorMessage ="Düzgün Mail Gir Lan")]
        public string Email { get; set; }
        [Required, DisplayName("Username")]
        public string Username { get; set; }
        [Required, DisplayName("Şifre"),DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DisplayName("Şifre (Tekrar)"),Compare("Password",ErrorMessage ="Şifreler uyuşmuyor"), DataType(DataType.Password)]
        public string RePassword { get; set; }




    }
}
