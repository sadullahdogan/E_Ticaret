using E_Ticaret_DLL.Models;
using E_Ticaret_WEBUI.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaret_WEBUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUsers> userManager;
        private RoleManager<ApplicationRole> roleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUsers>(new DataContext());
            userManager = new UserManager<ApplicationUsers>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new DataContext());
            roleManager = new RoleManager<ApplicationRole>(roleStore);
            
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUsers();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.UserName = model.Username;
                user.Email = model.Email;

                var result = userManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    //User created 
                    //asign role to user
                    if (roleManager.RoleExists("User"))
                    {
                        userManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma Hatası");
                }
            }
            return View(model);
        }
        public ActionResult Login()
        {
            if (Request.IsAuthenticated) {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Find(model.Username, model.Password);
                if (user != null)
                {
                    //sistemem kullanıcıyı at //++//ApplicationCookie oluşur sisteme at//
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityClaims = userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityClaims);

                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı bulunamadı");
                }
            }

            return View(model);
        }
        public ActionResult Logout() {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}