using NUnit.Framework;
using ShareYourInterests.Application.Input;
using ShareYourInterests.Application.Output;
using ShareYourInterests.Infrastructure.AutoMapper;

namespace ShareYourInterests.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AutoMapperTest()
        {
            var loginInputModel = new LoginInPutModel()
            {
                UserAccount = "test",
                UserPassword = "1111"
            };
           var loginOutPutModel= loginInputModel.MapTo<LoginOutPutModel>();
        }
    }
}