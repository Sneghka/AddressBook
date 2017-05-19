using System;
using System.Globalization;
using System.Threading;
using addressbook_web_tests.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
   public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            var contact = new ContactData();

            contact.FirstName = "FirstName3";
            contact.LastName = "LastName3";
            contact.MobilePhone = "324546";
            contact.PathToPhoto = @"D:\Sneghka\Обои\vladstudio_starfield_1600x1200_signed.jpg";
            contact.Birthday = new DateTime(1980, 1, 30);

            app.Contacts.Create(contact);

        }

        [Test]
        public void ContacModificationTest()
        {
            var contact = new ContactData();

            contact.FirstName = "ModifiedFirstName";
            contact.LastName = "ModifiedLastName";
            contact.MobilePhone = "XXXXXXXX";
            
            app.Contacts.Modify(11, contact);

        }
    }
}
