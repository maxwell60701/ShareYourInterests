using ShareYourInterests.Application.Input;
using ShareYourInterests.Application.Output;
using ShareYourInterests.Infrastructure.AutoMapper;

namespace ShareYourInterests.ConsoleTest
{
    public static class MapperTest
    {
        public static void LoginMapper()
        {
            var loginInputModel = new LoginInPutModel()
            {
                UserAccount = "test",
                UserPassword = "1111"
            };
            var loginOutPutModel = loginInputModel.MapTo<LoginOutPutModel>();
        }
    }
}
