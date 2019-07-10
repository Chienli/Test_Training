using System;
using System.Net;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerApiDependency.Enums;
using ServerApiDependency.Utility.CustomException;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace ServerApiDependency.Tests
{
    [TestClass()]
    public class ServerApiTests
    {
        /// <summary>
        /// LV 1, verify api correct response
        /// </summary>
        [TestMethod()]
        public void post_cancelGame_third_party_success_test()
        {
            var fakeServerApi = new FakeServerApiForSuccess();

            var actual = (int)fakeServerApi.CancelGame();
            // Assert success
            Assert.AreEqual(0, actual);
        }

        /// <summary>
        /// LV 2, verify specific exception be thrown
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(AuthFailException))]
        public void post_cancelGame_third_party_fail_test()
        {
            var fakeServerApi = new FakeServerApiForFail();
            var fakeDebugHelper = new FakeDebugHelper();
            fakeServerApi.DebugHelper = fakeDebugHelper;

            fakeServerApi.CancelGame();
            // Assert PostToThirdParty() return not correct should throw AuthFailException
        }

        /// <summary>
        /// LV 3, verify specific method be called
        /// </summary>
        [TestMethod()]
        public void post_cancelGame_third_party_exception_test()
        {
            var fakeServerApiForException = new FakeServerApiForException();
            var fakeDebugHelper = new FakeDebugHelper();
            fakeServerApiForException.DebugHelper = fakeDebugHelper;

            Action actual = () => { fakeServerApiForException.CancelGame(); };

            actual.Should().Throw<WebException>();
            // Assert SaveFailRequestToDb() be called once
            Assert.AreEqual(1, FakeServerApiForException.Count);
        }
    }

    internal class FakeServerApiForSuccess : ServerApi
    {
        protected override int PostToThirdParty(ApiType apiType, string apiPage)
        {
            return 0;
        }
    }

    internal class FakeServerApiForFail : ServerApi
    {
        protected override int PostToThirdParty(ApiType apiType, string apiPage)
        {
            return 99;
        }
    }

    internal class FakeServerApiForException : ServerApi
    {
        public static int Count;

        protected override int PostToThirdParty(ApiType apiType, string apiPage)
        {
            throw new WebException();
        }

        protected override void SaveFailRequestToDb(ApiType apiType, string apiPage)
        {
            Count++;
        }
    }

    internal class FakeDebugHelper : IDebugHelper
    {
        public void Error(string message)
        {
            Console.WriteLine(message);
        }
    }
}