using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShareYourInterests.Application;
using ShareYourInterests.Application.Application;
using ShareYourInterests.Application.Request;
using ShareYourInterests.Entity;
using ShareYourInterests.Infrastructure;
using ShareYourInterests.Infrastructure.Interface;

namespace ShareYourInterests.MVC.Controllers
{
    public class LoginController : Controller
    {
        private ILoginApplication _ILoginApplication;

        public LoginController(ILoginApplication loginApplication)
        {
            _ILoginApplication = loginApplication;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public Response UserLogin([FromBody]LoginInputModel loginInputModel)
        {
            var result = new Response();
            try
            {
                result = _ILoginApplication.UserLogin(loginInputModel);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
