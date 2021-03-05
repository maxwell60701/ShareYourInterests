using System;
using ShareYourInterests.Application.Input;
using ShareYourInterests.Application.Interface;
using ShareYourInterests.Application.Output;
using ShareYourInterests.Entity;
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
        public LoginOutPutModel UserLogin(LoginInPutModel loginInputModel)
        {
            if (loginInputModel == null)
                return null;

            var userEntity = _userRepository.FirstOrDefault(u =>
                  u.UserName == loginInputModel.UserAccount && u.UserPassword == loginInputModel.UserPassword);
            if (userEntity != null)
            {
                var result = new LoginOutPutModel
                {
                    UserAccount = userEntity.UserName,
                    UserPassword = userEntity.UserPassword
                };
                return result;
            }
            return null;
        }

        public bool CheckLogin()
        {
            return true;
        }
    }
}
