using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareYourInterests.Application.Request;
using ShareYourInterests.Infrastructure;

namespace ShareYourInterests.Application
{
    public interface ILoginApplication
    {
        Response UserLogin(LoginInputModel loginInputModel);

        bool CheckLogin();
    }
}
