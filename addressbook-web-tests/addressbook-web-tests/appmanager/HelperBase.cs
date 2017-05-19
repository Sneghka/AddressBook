using OpenQA.Selenium;

namespace addressbook_web_tests.appmanager
{
    public class HelperBase
    {
        protected readonly IWebDriver _driver;
        protected readonly ApplicationManager _manager;

        public HelperBase(ApplicationManager manager)
        {
            _manager = manager;
            _driver = manager.Driver;
        }

        public bool IsElementPresnt(By by)
        {
            try
            {
                _driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}