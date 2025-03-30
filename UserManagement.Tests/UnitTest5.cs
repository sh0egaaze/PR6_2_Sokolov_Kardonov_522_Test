using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR6_2_Sokolov_Kardonov_522_Test;
using System;

namespace UserManagement.Tests
{
    [TestClass]
    public class UnitTest5
    {
        [TestMethod]
        public void RegistrationTests()
        {
            var page = new RegPage();
            Assert.IsFalse(page.Register("", "", "", "", "", "", ""));
            Assert.IsFalse(page.Register("", "user3", "pass", "Мужской", "User", "+79991234567", ""));
            Assert.IsFalse(page.Register("Иванов Иван", "admin", "", "", "Administrator", "+79991234567", "http://example.com/manager.jpg"));
            Assert.IsTrue(page.Register("Новый Пользователь", "newuser","newpass", "Женский", "Manager", "+79999999999", "http://example.com/manager.jpg"));
        }
    }
}
