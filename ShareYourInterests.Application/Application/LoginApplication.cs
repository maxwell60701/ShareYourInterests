using System;
using ShareYourInterests.Application.Request;
using ShareYourInterests.Entity;
using ShareYourInterests.Infrastructure;
using ShareYourInterests.Infrastructure.Cache;
using ShareYourInterests.Infrastructure.Interface;

namespace ShareYourInterests.Application.Application
{
    public class LoginApplication : ILoginApplication
    {
        private IRepository<User, ShareYourInterestsDbContext> _userRepository;
        private ICacheContext _iCacheContext;

        public LoginApplication(IRepository<User, ShareYourInterestsDbContext> userRepository, ICacheContext iCacheContext)
        {
            _userRepository = userRepository;
            _iCacheContext = iCacheContext;
        }
        public Response UserLogin(LoginInputModel loginInputModel)
        {
            var result = new Response();
            var userEntity = _userRepository.FirstOrDefault(u =>
                  u.UserName == loginInputModel.UserAccount && u.UserPassword == loginInputModel.UserPassword);
            if (userEntity != null)
            {
                _iCacheContext.Set("LoginToken", userEntity.UserName, DateTime.Now.AddDays(10));
                result =new Response() { Code = 200 };
            }
            else
            {
                result = new Response() { Code = 500 };
            }

            return result;
        }

        public bool CheckLogin()
        {
            return true;
        }
    }
}
