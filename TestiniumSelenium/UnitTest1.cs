using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using Microsoft.VisualBasic.FileIO;



namespace TestiniumSelenium
{
    public class NetworkTest {

       

        //Hooks in NUnit
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
              
            //Browser Driver
            IWebDriver webDriver = new ChromeDriver();
            //Navigate to Site
            webDriver.Navigate().GoToUrl("https://www.network.com.tr/ ");

            //SEARCHBAR

            IWebElement searchBar = webDriver.FindElement(By.Id("search"));
            //Operation
            searchBar.SendKeys("ceket");

            searchBar.Submit();

            // SCROLL METODUNU BUL DENE 
           
            Actions actions = new Actions(webDriver);
            while(webDriver.Url == "https://www.network.com.tr/search?searchKey=ceket&page=2")
            {
                actions.SendKeys(Keys.PageDown).Build().Perform();
            }
         

            // DAHA FAZLA GOSTER BUTONUNA ID'si ILE BEARABER BUL VE TIKLA
            var element = webDriver.FindElement(By.XPath("//button[@class ='button -secondary -sm relative']"));
            element.Click();

            // URL'yi kontrol et
            webDriver.Url = "https://www.network.com.tr/search?searchKey=ceket&page=2";
          
            if(webDriver.Url != "https://www.network.com.tr/search?searchKey=ceket&page=2") webDriver.Navigate().GoToUrl("https://www.network.com.tr/search?searchKey=ceket&page=2");
           
            
            // Ürün Getirme
            webDriver.FindElement(By.CssSelector("[data-id='1073542-170'")).Click();

            //Beden Seçme
            var select = webDriver.FindElement(By.XPath("//label[@class ='radio-box__label']"));
            select.Click();

            //sepete ekleme
            webDriver.FindElement(By.CssSelector(".product__button.-addToCart")).Click();

            //webDriver.FindElement(By.CssSelector("header__icon.- shoppingBag")).Click();



            TimeSpan.FromSeconds(20);

            webDriver.Navigate().GoToUrl("https://www.network.com.tr/cart");

            //webDriver.FindElement(By.CssSelector(".cartItem__price.- labelPrice"));

            webDriver.FindElement(By.CssSelector(".n - button.- primary.block")).Click();


            String email;
            String password;

            using (TextFieldParser parser = new TextFieldParser(@"C:\UserInfo.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                 
                    string[] fields = parser.ReadFields();
                    email = fields[0];
                    password = fields[1];

                    webDriver.FindElement(By.CssSelector("# n-input-email")).SendKeys(email);
                    webDriver.FindElement(By.CssSelector("# n-input-password")).SendKeys(password);
                    webDriver.FindElement(By.CssSelector("# login > button")).Click();
                }
            }

            webDriver.FindElement(By.CssSelector("# home > div.page-wrapper > header > div > div > div.col-md-2 > a")).Click();

            webDriver.FindElement(By.CssSelector("body > div.stickyHeader > header > div > div > div.col - 3.header__rightContent > div.header__basket.js - basket.header__basketLink > a > svg")).Click();


            webDriver.FindElement(By.CssSelector("# cop-app > div > div.layout.-default > div.layout__content > div.layout__main > div:nth-child(2) > section > div.cartItem > div > div > div.cartItem__subArea.-top > div.cartItem__info > div.n-quantity.cartItem__quantity.-mobile > button:nth-child(1)")).Click();

        }
    }
}