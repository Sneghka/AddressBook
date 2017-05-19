using System.Threading;
using addressbook_web_tests.Model;
using OpenQA.Selenium;

namespace addressbook_web_tests.appmanager
{
    public class LoginHelper : HelperBase
    {


        public LoginHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            _driver.FindElement(By.Name("user")).FillFormField(account.UserName);
            _driver.FindElement(By.Name("pass")).FillFormField(account.Password);
            _driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            Thread.Sleep(1000);
        }

        public bool IsLoggedIn()
        {
            return IsElementPresnt(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() && GetLoggedUserName() == account.UserName;
                   
        }

        private string GetLoggedUserName()
        {
            var text = _driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }

        public void Logout()
        {
            if(IsLoggedIn()) _driver.FindElement(By.LinkText("Logout")).Click();


        }
    }


}
