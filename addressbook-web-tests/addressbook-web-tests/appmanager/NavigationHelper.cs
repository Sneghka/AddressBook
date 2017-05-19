using OpenQA.Selenium;

namespace addressbook_web_tests.appmanager
{
    public class NavigationHelper : HelperBase
    {
        
        private readonly string _baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            _baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            if (_driver.Url == _baseURL + "/addressbook/")
            {
                return;
            }
            _driver.Navigate().GoToUrl(_baseURL);
        }

        public void GoToGroupsPage()
        {
            if(_driver.Url == _baseURL + "/addressbook/group.php" && IsElementPresnt(By.Name("new")))
            {
                return;
            }
            _driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
