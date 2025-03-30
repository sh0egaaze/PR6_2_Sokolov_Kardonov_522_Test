using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR6_2_Sokolov_Kardonov_522_Test;
using System;
using System.Windows;
using System.Windows.Controls;

namespace UserManagement.Tests
{
    [TestClass]
    public class UnitTest7
    {
        [TestMethod]
        public void TestCorrectCaptchaInput()
        {
            var page = new AuthPage();
            for (int i = 0; i < 3; i++)
            {
                page.Auth("wrong_login", "wrong_password");
            }
            string captchaText = page.GetCurrentCaptchaText();
            TextBox captchaTextBox = page.FindName("CaptchaTextBox") as TextBox;
            if (captchaTextBox == null)
            {
                Assert.Fail("CaptchaTextBox не найден");
            }
            captchaTextBox.Text = captchaText;
            page.BtnCheckCaptcha_Click(null, null);
            UIElement captchaPanel = page.FindName("CaptchaPanel") as UIElement;
            if (captchaPanel == null)
            {
                Assert.Fail("CaptchaPanel не найден");
            }
            Assert.AreEqual(Visibility.Collapsed, captchaPanel.Visibility);
        }
    }
}
