using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShareYourInterests.Infrastructure;
using ShareYourInterests.Application.Input;
using ShareYourInterests.Application.Interface;

namespace ShareYourInterests.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IRegisterApplication _IRegisterApplication;

        public RegisterController(IRegisterApplication IRegisterApplication)
        {
            _IRegisterApplication = IRegisterApplication;
        }

        [HttpPost]
        public Response RegisterAccount(RegisterInputModel registerInputModel)
        {
            var response = new Response();
            try
            {
                if (_IRegisterApplication.Register(registerInputModel))
                {
                    response.Code = 200;
                }
                else
                {
                    response.Code = 500;
                }
            }
            catch (Exception ex)
            {
                response.Code = 500;
            }

            return response;
        }
    }
}
