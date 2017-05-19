using System;
using System.Text;
using addressbook_web_tests.appmanager;
using addressbook_web_tests.Model;
using NUnit.Framework;


namespace addressbook_web_tests.Tests
{
    public class TestBase
    {
       protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();

        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble()*max);
            var builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(65 + Convert.ToInt32(rnd.NextDouble()*25))); // коды печатных символов
            }
            return builder.ToString();
        }
    }
}
