using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShareYourInterests.Application;
using ShareYourInterests.Application.Application;
using ShareYourInterests.Application.Request;
using ShareYourInterests.Entity;
using ShareYourInterests.Infrastructure;
using ShareYourInterests.Infrastructure.Cache;
using ShareYourInterests.Infrastructure.Interface;

namespace ShareYourInterests.MVC.Controllers
{
    public class LoginController : Controller
    {
        private ILoginApplication _ILoginApplication;
        private readonly ICacheContext _icacheContext;

        public LoginController(ILoginApplication loginApplication, ICacheContext icacheContext)
        {
            _ILoginApplication = loginApplication;
            _icacheContext = icacheContext;
        }
        public IActionResult Login()
        {
            return View();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (_ILoginApplication.CheckLogin() && _icacheContext.Get<string>("LoginToken") != null)
            {
                context.Result = new RedirectResult("/Home/Index");
            }
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
