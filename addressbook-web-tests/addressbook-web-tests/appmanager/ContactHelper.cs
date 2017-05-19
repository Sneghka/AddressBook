using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using addressbook_web_tests.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests.appmanager
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            _manager.Navigator.GoToHomePage();
            Thread.Sleep(2000);
            InitContacCreation();
            FillContactForm(contact);
            UploadPhoto(contact.PathToPhoto);
            SubmitContactForm();
            _manager.Navigator.GoToHomePage();
            return this;
        }
        public ContactHelper Modify(int index, ContactData contact)
        {
            _manager.Navigator.GoToHomePage();
            Thread.Sleep(2000);
            InitContacModification(index);
            FillContactForm(contact);
            UpdateContactForm();
            _manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper InitContacCreation()
        {
            _driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper InitContacModification(int index)
        {
            _driver.FindElement(By.XPath($".//*[@id='maintable']/tbody/tr[{index + 1}]/td[8]/a")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            _driver.FillFormField(contact.FirstName, _driver.FindElement(By.Name("firstname")));
            _driver.FillFormField(contact.LastName, _driver.FindElement(By.Name("lastname")));
            _driver.FillFormField(contact.MiddleName, _driver.FindElement(By.Name("middlename")));

            _driver.FindElement(By.Name("nickname")).FillFormField(contact.NickName);
            _driver.FindElement(By.Name("title")).FillFormField(contact.Title);
            _driver.FindElement(By.Name("company")).FillFormField(contact.Company);
            _driver.FindElement(By.Name("home")).FillFormField(contact.HomePhone);
            _driver.FindElement(By.Name("mobile")).FillFormField(contact.MobilePhone);
            _driver.FindElement(By.Name("work")).FillFormField(contact.WorkPhone);
            _driver.FindElement(By.Name("fax")).FillFormField(contact.Fax);
            _driver.FindElement(By.Name("email")).FillFormField(contact.Email);
            _driver.FindElement(By.Name("email2")).FillFormField(contact.Email2);
            _driver.FindElement(By.Name("email3")).FillFormField(contact.Email3);
            _driver.FindElement(By.Name("homepage")).FillFormField(contact.Homepage);

            CultureInfo ci = new CultureInfo("en-US");

            if (contact.Birthday.Year != 1)
            {
                var birthDay = contact.Birthday.Day.ToString();
                var birthMonth = contact.Birthday.ToString("MMMM", ci);
                var birthYear = contact.Birthday.Year.ToString();
                new SelectElement(_driver.FindElement(By.Name("bday"))).SelectByText(birthDay);
                new SelectElement(_driver.FindElement(By.Name("bmonth"))).SelectByText(birthMonth);
                _driver.FindElement(By.Name("byear")).FillFormField(birthYear);
            }

            if (contact.Anniversary.Year != 1)
            {
                var annDay = contact.Anniversary.Day.ToString();
                var annMonth = contact.Anniversary.ToString("MMMM", ci);
                var annYear = contact.Anniversary.Year.ToString();
                new SelectElement(_driver.FindElement(By.Name("aday"))).SelectByText(annDay);
                new SelectElement(_driver.FindElement(By.Name("amonth"))).SelectByText(annMonth);
                _driver.FindElement(By.Name("ayear")).FillFormField(annYear);
            }

            _driver.FindElement(By.Name("address2")).FillFormField(contact.SecondaryAddress);
            _driver.FindElement(By.Name("phone2")).FillFormField(contact.SecondaryHomePhone);
            _driver.FindElement(By.Name("notes")).FillFormField(contact.Notes);
            return this;
        }

        public ContactHelper UploadPhoto(string path)
        {
            _driver.FindElement(By.Name("photo")).FillFormField(path);
            return this;
        }

        public ContactHelper ChooseGroup()
        {

            return this;
        }

        private ContactHelper SubmitContactForm()
        {
            _driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        private ContactHelper UpdateContactForm()
        {
            _driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            _manager.Navigator.GoToHomePage();
            var cells = _driver.FindElements(By.Name("entry"))[index-1].FindElements(By.TagName("td"));
            var lastName = cells[1].Text;
            var firstName = cells[2].Text;
            var address = cells[3].Text;

            var allPhones = cells[5].Text;

            return new ContactData()
            {
                FirstName = firstName,
                LastName = lastName,
                CompanyAddress = address,
                AllPhones = allPhones
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            _manager.Navigator.GoToHomePage();
            InitContacModification(index);
            var firstName = _driver.FindElement(By.Name("firstname")).GetAttribute("value");
            var lastName = _driver.FindElement(By.Name("lastname")).GetAttribute("value");
            var address = _driver.FindElement(By.Name("address")).GetAttribute("value");

            var homePhone = _driver.FindElement(By.Name("home")).GetAttribute("value");
            var mobilePhone = _driver.FindElement(By.Name("mobile")).GetAttribute("value");
            var workPhone = _driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData()
            {
                FirstName = firstName,
                LastName = lastName,
                CompanyAddress = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }

        public int CetNumberSearchResults()
        {
            _manager.Navigator.GoToHomePage();
            var text = _driver.FindElement(By.TagName("label")).Text;
            var m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);

        }
    }
}
