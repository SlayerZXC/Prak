using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using курсовая_трзбд; // Используйте имя вашего основного проекта

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Form1 form;

        [TestInitialize]
        public void Setup()
        {
            form = new Form1();
        }

        [TestMethod]
        public void TestMethod1_ValidLogin()
        {
            // Arrange
            string login = "risha";
            string password = "87654321";

            // Act
            form.Login(login, password);

            // Assert
            Assert.IsTrue(form.IsLoggedIn, "Форма сотрудника не открылась.");
        }

        [TestMethod]
        public void TestMethod2_LoadClientData()
        {
            // Arrange
            string login = "klusha";
            string password = "88005553533";

            // Act
            form.Login(login, password);

            // Assert
            Assert.IsTrue(form.IsClientDataLoaded, "Данные клиента не загружены.");
        }

        [TestMethod]
        public void TestMethod3_InvalidLogin()
        {
            // Arrange
            string login = "shemaa";
            string password = "12345678";

            // Act
            form.Login(login, password);

            // Assert
            Assert.IsTrue(form.IsErrorMessageShown, "Окно с предупреждением не появилось.");
        }

        [TestMethod]
        public void TestMethod4_InvalidPassword()
        {
            // Arrange
            string login = "shema";
            string password = "87654321";

            // Act
            form.Login(login, password);

            // Assert
            Assert.IsTrue(form.IsErrorMessageShown, "Окно с предупреждением не появилось.");
        }

        [TestMethod]
        public void TestMethod5_EmptyCredentials()
        {
            // Arrange
            string login = ""; // Пустой логин
            string password = ""; // Пустой пароль

            // Act
            form.Login(login, password);

            // Assert
            Assert.IsTrue(form.IsErrorMessageShown, "Окно с предупреждением не появилось при пустых данных для входа.");
        }

    }
}
