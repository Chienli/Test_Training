using Microsoft.VisualStudio.TestTools.UnitTesting;
using RsaSecureToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace RsaSecureToken.Tests
{
    [TestClass()]
    public class AuthenticationServiceTests
    {
        [TestMethod()]
        public void IsValidTest()
        {
            var profileDao = Substitute.For<IProfileDao>();
            profileDao.GetRegisterTimeInMinutes(Arg.Any<string>()).Returns(200);
            var rsaTokenDao = Substitute.For<IRsaTokenDao>();
            rsaTokenDao.GetRandom(Arg.Any<int>()).ReturnsForAnyArgs(new Random(200));
            var authenticationService = Substitute.For<AuthenticationService>(profileDao, rsaTokenDao);
            // implement your own act
            var actual = authenticationService.IsValid("guy", "211305");

            Assert.IsTrue(actual);
        }
    }
}