using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR6_2_Sokolov_Kardonov_522_Test;
using System;
using System.Windows;
using System.Windows.Controls;

namespace UserManagement.Tests
{
    [TestClass]
    public class UnitTest8
    {
        [TestMethod]
        public void TestIncorrectCaptchaInput()
        {
            var page = new AuthPage();
            for (int i = 0; i < 3; i++)
            {
                page.Auth("wrong_login", "wrong_password");
            }
            TextBox captchaTextBox = page.FindName("CaptchaTextBox") as TextBox;
            if (captchaTextBox == null)
            {
                Assert.Fail("CaptchaTextBox не найден");
            }
            captchaTextBox.Text = "wrong_captcha";
            page.BtnCheckCaptcha_Click(null, null);
            Assert.AreEqual(Visibility.Visible, page.GetCaptchaVisibility());
        }
    }
}
