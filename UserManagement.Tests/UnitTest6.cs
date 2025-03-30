using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR6_2_Sokolov_Kardonov_522_Test;
using System;
using System.Windows;

namespace UserManagement.Tests
{
    [TestClass]
    public class UnitTest6
    {
        [TestMethod]
        public void TestCaptchaVisibilityAfterFailedAttempts()
        {
            var page = new AuthPage();
            for (int i = 0; i < 3; i++)
            {
                bool result = page.Auth("wrong_login", "wrong_password");
                Assert.IsFalse(result);
            }
            var captchaVisibility = page.GetCaptchaVisibility();
            Assert.AreEqual(Visibility.Visible, captchaVisibility);
        }
    }
}
