using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShareYourInterests.Application;

namespace ShareYourInterests.MVC.Filters
{
    public class ActionFilter : IActionFilter
    {
        private readonly ILoginApplication _loginApplication;
        public ActionFilter(ILoginApplication loginApplication)
        {
            _loginApplication = loginApplication;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_loginApplication.CheckLogin())
            {
               // context.Result = new RedirectResult("/Login/Login");
            }
        }  
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }
    }
}
