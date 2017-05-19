using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public static class ExtensionMethods
    {

        public static void FillFormField( this IWebDriver driver, string propertyValue, IWebElement webElement)
        {
            webElement.Clear();
            if(propertyValue != null) webElement.SendKeys(propertyValue);
        }

        public static void FillFormField(this IWebElement webElement, string propertyValue)
        {
            webElement.Clear();

            if (propertyValue != null) webElement.SendKeys(propertyValue);
        }

    }
}
