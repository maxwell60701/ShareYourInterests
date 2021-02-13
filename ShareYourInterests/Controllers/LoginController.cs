using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShareYourInterests.Application;
using ShareYourInterests.Application.Application;
using ShareYourInterests.Application.Request;
using ShareYourInterests.Infrastructure;

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

        public Response UserLogin(LoginUserModel loginUserModel)
        {
            var result = new Response();
            try
            {
                result = _ILoginApplication.UserLogin(loginUserModel);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
