using System;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using GeradorCpf;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace SeleniumTests
{
    [TestClass]
    public class UntitledTestCase
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new ChromeDriver();
            baseURL = "https://www.katalon.com";
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
            driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
            driver.Close();
            driver.Dispose();
        }

        [TestMethod]
        public void TestCase_InvalidEmailAndPassword()
        {
            //Setting to a variable the expected output and the url
            string expected = "Usuário ou senha inválidos.";
           //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("teste@gmail.com");

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys("123");

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/button/span")).Click();
            Thread.Sleep(1000);

            string output = driver.FindElement(By.ClassName("loginError")).Text;

            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestCase_EnterYourPassword()
        {
            //Setting to a variable the expected output and the url
            string expected = "Insira sua senha.";
            //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("teste@gmail.com");

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys(string.Empty);

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/button/span")).Click();
            Thread.Sleep(1000);

            string output = driver.FindElement(By.ClassName("loginError")).Text;
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestCase_EnterYourEmail()
        {
            //Setting to a variable the expected output and the url
            string expected = "Insira seu e-mail.";
            //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(string.Empty);

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys("123");

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/button/span")).Click();
            Thread.Sleep(1000);

            string output = driver.FindElement(By.ClassName("loginError")).Text;

            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestCase_EnterYourEmailAndPassword()
        {
            //Setting to a variable the expected output and the url
            string expected = "Insira seu e-mail e senha.";
            //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(string.Empty);

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys(string.Empty);

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/button/span")).Click();
            Thread.Sleep(1000);

            string output = driver.FindElement(By.ClassName("loginError")).Text;

            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestCase_EmailAndPasswordCorrects()
        {
            //Site url
            //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("archanjovitor@gmail.com");

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys("123456");

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/button/span")).Click();
            string output = driver.FindElement(By.ClassName("loginError")).Text;

            Assert.AreEqual(string.Empty, output);
        }

        /*
        [TestMethod]
        public void TestCase_ForgotPassword()
        {
            //Site url
            driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("archanjovitor@gmail.com");

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys("123456");

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/button/span")).Click();
            string output = driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/span")).Text;

            Assert.AreEqual(string.Empty, output);
        }*/

        [TestMethod]
        public void TestCase_RegisterFailed_EmptyFields()
        {
            //Seite url
            string expected = "Preencha todos os campos corretamente para cadastrar";
            //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //register now - click
            driver.FindElement(By.LinkText("Cadastrar agora")).Click();

            //name
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys(string.Empty);

            //cpf
            driver.FindElement(By.Id("cpf")).Click();
            driver.FindElement(By.Id("cpf")).Clear();
            driver.FindElement(By.Id("cpf")).SendKeys(string.Empty);

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(string.Empty);

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys(string.Empty);

            //confirm password
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).SendKeys(string.Empty);

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/div[6]/button/span")).Click();
            Thread.Sleep(1000);

            string output = driver.FindElement(By.ClassName("Toastify__toast-body")).Text;


            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestCase_RegisterFailed_EmptyName()
        {
            //Seite url
            string expected = "Preencha todos os campos corretamente para cadastrar";
            //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //register now - click
            driver.FindElement(By.LinkText("Cadastrar agora")).Click();

            //name
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys(string.Empty);

            //cpf
            driver.FindElement(By.Id("cpf")).Click();
            driver.FindElement(By.Id("cpf")).Clear();
            driver.FindElement(By.Id("cpf")).SendKeys("11111111111");

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("teste@teste.com");

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys("senha123");

            //confirm password
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).SendKeys("senha123");

            //Register - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/div[6]/button/span")).Click();
            Thread.Sleep(1000);

            string output = driver.FindElement(By.ClassName("Toastify__toast-body")).Text;


            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestCase_RegisterFailed_EmptyCPF()
        {
            //Seite url
            string expected = "Preencha todos os campos corretamente para cadastrar";
            //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //register now - click
            driver.FindElement(By.LinkText("Cadastrar agora")).Click();

            //name
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys("testeN");

            //cpf
            driver.FindElement(By.Id("cpf")).Click();
            driver.FindElement(By.Id("cpf")).Clear();
            driver.FindElement(By.Id("cpf")).SendKeys(string.Empty);

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("teste@teste.com");

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys("senha123");

            //confirm password
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).SendKeys("senha123");

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/div[6]/button/span")).Click();
            Thread.Sleep(1000);

            string output = driver.FindElement(By.ClassName("Toastify__toast-body")).Text;


            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestCase_RegisterFailed_EmptyEmail()
        {
            //Seite url
            string expected = "Preencha todos os campos corretamente para cadastrar";
            //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //register now - click
            driver.FindElement(By.LinkText("Cadastrar agora")).Click();

            //name
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys("testeN");

            //cpf
            driver.FindElement(By.Id("cpf")).Click();
            driver.FindElement(By.Id("cpf")).Clear();
            driver.FindElement(By.Id("cpf")).SendKeys("11111111111");

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(string.Empty);

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys("senha123");

            //confirm password
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).SendKeys("senha123");

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/div[6]/button/span")).Click();
            Thread.Sleep(1000);

            string output = driver.FindElement(By.ClassName("Toastify__toast-body")).Text;


            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestCase_RegisterFailed_EmptyPassword()
        {
            //Seite url
            string expected = "Preencha todos os campos corretamente para cadastrar";
            //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //register now - click
            driver.FindElement(By.LinkText("Cadastrar agora")).Click();

            //name
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys("testeN");

            //cpf
            driver.FindElement(By.Id("cpf")).Click();
            driver.FindElement(By.Id("cpf")).Clear();
            driver.FindElement(By.Id("cpf")).SendKeys("11111111111");

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("teste@teste.com");

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys(string.Empty);

            //confirm password
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).SendKeys("senha123");

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/div[6]/button/span")).Click();
            Thread.Sleep(1000);

            string output = driver.FindElement(By.ClassName("Toastify__toast-body")).Text;


            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestCase_RegisterFailed_EmptyConfirPassword()
        {
            //Seite url
            string expected = "Preencha todos os campos corretamente para cadastrar";
            //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //register now - click
            driver.FindElement(By.LinkText("Cadastrar agora")).Click();

            //name
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys("testeN");

            //cpf
            driver.FindElement(By.Id("cpf")).Click();
            driver.FindElement(By.Id("cpf")).Clear();
            driver.FindElement(By.Id("cpf")).SendKeys("11111111111");

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("teste@teste.com");

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys("senha123");

            //confirm password
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).SendKeys(string.Empty);

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/div[6]/button/span")).Click();
            Thread.Sleep(1000);

            string output = driver.FindElement(By.ClassName("Toastify__toast-body")).Text;


            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestCase_RegisterFailed_InvalidEmail()
        {
            //Site url
            string expected = "email";
            //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //Random name for tests
            string name = NomeAleatorio();

            //Creating a new cpf number
            string cpf = string.Empty;
            GeradorCpf.GeradorCpf cpfGerado = new GeradorCpf.GeradorCpf();
            cpf = cpfGerado.getCpf();

            //register now - click
            driver.FindElement(By.LinkText("Cadastrar agora")).Click();

            //name
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys(name);

            //cpf
            driver.FindElement(By.Id("cpf")).Click();
            driver.FindElement(By.Id("cpf")).Clear();
            driver.FindElement(By.Id("cpf")).SendKeys(cpf);

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            //Writing a invalid email one warning specifying the error should apper
            driver.FindElement(By.Id("email")).SendKeys(name);

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys("senha123");

            //confirm password
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).SendKeys(string.Empty);

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/div[6]/button/span")).Click();
            Thread.Sleep(1000);

            string output = driver.FindElement(By.ClassName("Toastify__toast-body")).Text;

            Assert.IsTrue(output.Contains(expected));
        }

        [TestMethod]
        public void TestCase_RegisterFailed_InvalidCpf()
        {
            //Site url
            string expected = "cpf";
            //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //Random name for tests
            string name = NomeAleatorio();

            //register now - click
            driver.FindElement(By.LinkText("Cadastrar agora")).Click();

            //name
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys(name);

            //cpf
            driver.FindElement(By.Id("cpf")).Click();
            driver.FindElement(By.Id("cpf")).Clear();
            driver.FindElement(By.Id("cpf")).SendKeys("11111111111");

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(name + "@gmail.com");

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys("senha123");

            //confirm password
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).SendKeys(string.Empty);

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/div[6]/button/span")).Click();
            Thread.Sleep(1000);

            string output = driver.FindElement(By.ClassName("Toastify__toast-body")).Text;

            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestCase_RegisterFailed_FormattedCpf()
        {
            //Site url
            string expected = "Cadastro realizado com sucesso";
            //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //Random name for tests
            string name = NomeAleatorio();

            //Creating a new formatted cpf number
            string cpf = string.Empty;
            GeradorCpf.GeradorCpf cpfGerado = new GeradorCpf.GeradorCpf();
            cpf = cpfGerado.getCpfFormatted();

            //register now - click
            driver.FindElement(By.LinkText("Cadastrar agora")).Click();

            //name
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys(name);

            //cpf
            driver.FindElement(By.Id("cpf")).Click();
            driver.FindElement(By.Id("cpf")).Clear();
            driver.FindElement(By.Id("cpf")).SendKeys(cpf);

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(name + "@gmail.com");

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys("senha123");

            //confirm password
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).SendKeys("senha123");

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/div[6]/button/span")).Click();
            Thread.Sleep(1000);

            string output = driver.FindElement(By.ClassName("Toastify__toast-body")).Text;

            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestCase_RegisterFailed_PasswordNotMatch()
        {
            //Site url
            //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //Random name for tests
            string name = NomeAleatorio();

            //Creating a new cpf number
            string cpf = string.Empty;
            GeradorCpf.GeradorCpf cpfGerado = new GeradorCpf.GeradorCpf();
            cpf = cpfGerado.getCpf();

            //register now - click
            driver.FindElement(By.LinkText("Cadastrar agora")).Click();

            //name
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys(name);

            //cpf
            driver.FindElement(By.Id("cpf")).Click();
            driver.FindElement(By.Id("cpf")).Clear();
            driver.FindElement(By.Id("cpf")).SendKeys(cpf);

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(name + "@gmail.com");

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys("senha123");

            //confirm password
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).SendKeys("senha321");

            //Get the passwords writted
            string passord = driver.FindElement(By.Id("senha")).Text;
            string confirmPasswrod = driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Text;

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/div[6]/button/span")).Click();
            Thread.Sleep(1000);

            string output = driver.FindElement(By.ClassName("Toastify__toast-body")).Text;
            //Writted different passwords a warning should apper telling this error
            string expected = "senhas não conferem";

            Assert.AreEqual(output, expected);
        }

        [TestMethod]
        public void TestCase_SuccessefullRegister()
        {
            //Criando um nome e email aleatório para cadastrar novo usuário
            string nome = NomeAleatorio();

            //Creating a new cpf number
            string cpf = string.Empty;
            GeradorCpf.GeradorCpf cpfGerado = new GeradorCpf.GeradorCpf();
            cpf = cpfGerado.getCpf();

            //Seite url
            string expected = "Cadastro realizado com sucesso";
            //driver.Navigate().GoToUrl("https://portal-estabelecimento-dev.azurewebsites.net/login");

            //register now - click
            driver.FindElement(By.LinkText("Cadastrar agora")).Click();

            //name
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys(nome);

            //cpf
            driver.FindElement(By.Id("cpf")).Click();
            driver.FindElement(By.Id("cpf")).Clear();
            driver.FindElement(By.Id("cpf")).SendKeys(cpf);

            //email
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(nome+"@gmail.com");

            //password
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).Clear();
            driver.FindElement(By.Id("senha")).SendKeys("123senhaAS@");

            //confirm password
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='senha'])[2]")).SendKeys("123senhaAS@");

            //Enter - click action
            driver.FindElement(By.XPath("//div[@id='root']/div[2]/div/div[2]/form/div[6]/button/span")).Click();
            Thread.Sleep(2000);

            string output = driver.FindElement(By.ClassName("Toastify__toast-body")).Text;

            Assert.AreEqual(expected, output);
        }

        public static string NomeAleatorio()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 7)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
