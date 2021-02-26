using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareYourInterests.Application.Input;
using ShareYourInterests.Infrastructure;

namespace ShareYourInterests.Application.Interface
{
    public interface IRegisterApplication
    {
        bool Register(RegisterInputModel registerInputModel);
    }
}
