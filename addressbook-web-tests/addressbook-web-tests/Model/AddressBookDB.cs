using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using MySql.Data.MySqlClient;

namespace addressbook_web_tests.Model
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {



        public AddressBookDB() : base("AddressBook")
        {
         

        }

        public ITable<GroupData> Groups => GetTable<GroupData>();
        public ITable<ContactData> Contacts => GetTable<ContactData>();
    }
}
