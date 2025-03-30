using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR6_2_Sokolov_Kardonov_522_Test;
using System;

namespace UserManagement.Tests
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void AuthTestSuccess()
        {
            var page = new AuthPage();
            Assert.IsTrue(page.Auth("administrator", "12345"));
            Assert.IsTrue(page.Auth("user", "qwerty"));
            Assert.IsTrue(page.Auth("manager", "password"));
        }
    }
}
