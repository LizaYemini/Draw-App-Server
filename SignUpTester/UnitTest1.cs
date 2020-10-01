using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraDal;
using NUnit.Framework;
using SignUpService;
using UserDal;

namespace SignUpTester
{
    public class Tests
    {
        private SignUpServiceImpl signUpService;
        [SetUp]
        public void Setup()
        {
            UserDalImpl userDal = new UserDalImpl(new InfraDalImpl());
            signUpService = new SignUpServiceImpl(userDal);
        }

        [Test]
        public void SignUpOk()
        {
            var request = new SignUpRequest();
            var register = new RegisterDto
            {
                Id = "Try8@hotmail.com",
                Name = "Liza"
            };
            //request.Register = register;
            var response = signUpService.SignUp(request);
            Assert.IsInstanceOf(typeof(SignUpResponseOk), response);
        }

        [Test]
        public void SignUpEmailExists()
        {
            var request = new SignUpRequest();
            var register = new RegisterDto
            {
                Id = "Liza091995@hotmail.com",
                Name = "Liza"
            };
            request.Id = "AAA@hotmail.com";
            request.Name = "Liza";
            //request.Register = register;
            var response = signUpService.SignUp(request);
            Assert.IsInstanceOf(typeof(SignUpResponseEmailExists), response);
        }
    }
}