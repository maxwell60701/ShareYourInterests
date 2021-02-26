using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShareYourInterests.Application.Interface;
using ShareYourInterests.Infrastructure.Cache;

namespace ShareYourInterests.MVC.Filters
{
    public class ActionFilter : IActionFilter
    {
        private readonly ILoginApplication _loginApplication;
        private readonly ICacheContext _icacheContext;
        public ActionFilter(ILoginApplication loginApplication, ICacheContext icacheContext)
        {
            _loginApplication = loginApplication;
            _icacheContext = icacheContext;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //有重定向的BUG
            //if (_loginApplication.CheckLogin() && _icacheContext.Get<string>("LoginToken") != null)
            //{
            //    context.Result = new RedirectResult("/Home/Index");
            //}
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }
    }
}
