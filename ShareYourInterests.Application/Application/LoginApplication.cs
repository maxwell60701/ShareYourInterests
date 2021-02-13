using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareYourInterests.Application.Request;
using ShareYourInterests.Infrastructure;

namespace ShareYourInterests.Application.Application
{
    public class LoginApplication:ILoginApplication
    {
        public Response UserLogin(LoginInputModel loginInputModel)
        {

            return new Response(){Code = 200};
        }
    }
}
