
using System.Collections.Generic;
using addressbook_web_tests.Model;
using NUnit.Framework;


namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            var newData = new GroupData("modified");
            newData.Header = "xxx";
            newData.Footer = "zzz";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            var oldData = oldGroups[0];

            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = "modified";
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (var group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                } 
            }
        }
    }
}
