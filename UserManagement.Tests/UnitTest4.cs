using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR6_2_Sokolov_Kardonov_522_Test;
using System;

namespace UserManagement.Tests
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void AuthTestNegative()
        {
            var page = new AuthPage();
            Assert.IsFalse(page.Auth("", ""));
            Assert.IsFalse(page.Auth("user", ""));
            Assert.IsFalse(page.Auth("", "pass"));
            Assert.IsFalse(page.Auth("fakeuser", "fakepass"));
        }
    }
}
