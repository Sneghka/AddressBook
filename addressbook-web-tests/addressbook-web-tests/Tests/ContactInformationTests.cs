using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            var fromTable = app.Contacts.GetContactInformationFromTable(1);
            var fromForm = app.Contacts.GetContactInformationFromEditForm(1);

            Assert.AreEqual(fromTable,fromForm);
            Assert.AreEqual(fromTable.CompanyAddress, fromForm.CompanyAddress);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);

            //verification
        }

    }
}
