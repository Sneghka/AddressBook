using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace addressbook_web_tests.Model
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("Addressbook")
        {
        }

        public ITable<GroupData> Groups => GetTable<GroupData>();
        public ITable<ContactData> Contacts => GetTable<ContactData>();
    }
}
