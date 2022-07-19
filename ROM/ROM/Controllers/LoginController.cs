using Microsoft.AspNetCore.Mvc;
using ROM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROM.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserViewModel userVM)
        {
            var anUser = UserInfo().Where(c => c.UserName.Equals(userVM.UserName));
            var user = anUser.Where(d => d.Password.Equals(userVM.Password));

            if (user.Any())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = "Login failed! Invalid username or password.";
                return View();
            }
        }


        private List<UserViewModel> UserInfo()
        {
            var users = new List<UserViewModel>
            {
                new UserViewModel{Id=1, UserName="tarif", Password="abc100"},
                new UserViewModel{Id=2, UserName="admin", Password="12345"},
                new UserViewModel{Id=3, UserName="shapla", Password="abc102"},
                new UserViewModel{Id=4, UserName="golap", Password="abc103"},
                new UserViewModel{Id=5, UserName="doyel", Password="abc104"}
            };
            return users;
        }

    }
}
