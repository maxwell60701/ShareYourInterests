using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareYourInterests.Application.Request;
using ShareYourInterests.Entity;
using ShareYourInterests.Infrastructure;
using ShareYourInterests.Infrastructure.Interface;

namespace ShareYourInterests.Application.Application
{
    public class LoginApplication : ILoginApplication
    {
        private IRepository<User, ShareYourInterestsDbContext> _userRepository;

        public LoginApplication(IRepository<User, ShareYourInterestsDbContext> userRepository)
        {
            _userRepository = userRepository;
        }
        public Response UserLogin(LoginInputModel loginInputModel)
        {
            var userEntity = _userRepository.FirstOrDefault(u =>
                  u.UserName == loginInputModel.UserAccount && u.UserPassword == loginInputModel.UserPassword);
            if (userEntity != null)
                return new Response() { Code = 200 };

            return new Response() { Code = 500 };
        }
    }
}
