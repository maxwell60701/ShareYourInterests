using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShareYourInterests.Application.Interface;
using ShareYourInterests.Application.Application;
using ShareYourInterests.Application.Input;
using ShareYourInterests.Infrastructure;
using ShareYourInterests.Infrastructure.Cache;

namespace ShareYourInterests.MVC.Controllers
{
    public class LoginController : Controller
    {
        private ILoginApplication _ILoginApplication;
        private readonly ICacheContext _iCacheContext;

        public LoginController(ILoginApplication loginApplication, ICacheContext iCacheContext)
        {
            _ILoginApplication = loginApplication;
            _iCacheContext = iCacheContext;
        }
        public IActionResult Login()
        {
            return View();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (_ILoginApplication.CheckLogin() && _iCacheContext.Get<string>("LoginToken") != null)
            {
                context.Result = new RedirectResult("/Home/Index");
            }
        }

        [HttpPost]
        public Response UserLogin([FromBody] LoginInPutModel loginInputModel)
        {
            var response = new Response() { Code = 500 };
            try
            {
                var result = _ILoginApplication.UserLogin(loginInputModel);
                if (result != null)
                {
                     _iCacheContext.Set("LoginToken", result.UserAccount, DateTime.Now.AddDays(10));
                    response.Code = 200;
                }
                return response;
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
