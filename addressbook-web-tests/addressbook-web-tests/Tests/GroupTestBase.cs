using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUi_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                var fromUI = app.Groups.GetGroupList();
                var fromDb = GroupData.GetAll();
                fromDb.Sort();
                fromUI.Sort();
                Assert.AreEqual(fromUI, fromDb);
            }
            
        }
    }
}
