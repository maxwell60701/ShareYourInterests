using ShareYourInterests.Application.Interface;
using ShareYourInterests.Application.Input;
using ShareYourInterests.Entity;
using ShareYourInterests.Infrastructure.Interface;

namespace ShareYourInterests.Application.Application
{
    public class RegisterApplication : IRegisterApplication
    {
        private IRepository<User, ShareYourInterestsDbContext> _userRepository;

        public RegisterApplication(IRepository<User, ShareYourInterestsDbContext> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Register(RegisterInputModel registerInputModel)
        {
            if (registerInputModel == null)
                return false;

            var user = _userRepository.FirstOrDefault(u => u.UserName == registerInputModel.UserAccount.Trim());
            if (user == null)
            {
                _userRepository.Add(new User
                {
                    UserName = registerInputModel.UserAccount,
                    UserPassword = registerInputModel.UserPassword
                });
                return true;
            }
            return false;
        }
    }
}
