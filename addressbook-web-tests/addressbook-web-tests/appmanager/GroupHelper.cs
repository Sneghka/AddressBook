using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using addressbook_web_tests.Model;
using OpenQA.Selenium;


namespace addressbook_web_tests.appmanager
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public GroupHelper Create(GroupData group)
        {
            _manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public int GetGroupCount()
        {
            return _driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper Modify(int i, GroupData newData)
        {
            _manager.Navigator.GoToGroupsPage();
            SelectGroup(i);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            _driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            _driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper Remove(int p)
        {
            _manager.Navigator.GoToGroupsPage();
            Thread.Sleep(2000);
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Remove(GroupData group)
        {
            _manager.Navigator.GoToGroupsPage();
            Thread.Sleep(2000);
            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }


        public GroupHelper InitGroupCreation()
        {
            _driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            _driver.FindElement(By.Name("group_name")).FillFormField(group.Name);
            _driver.FindElement(By.Name("group_header")).FillFormField(group.Header);
            _driver.FindElement(By.Name("group_footer")).FillFormField(group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            _driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            _driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            _driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(string id)
        {
            _driver.FindElement(By.XPath($"(//input[@name='selected[]' and @value='{id}'])")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            _driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{index + 1}]")).Click();
            return this;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                _manager.Navigator.GoToGroupsPage();
                var elements = _driver.FindElements(By.CssSelector("span.group"));
                foreach (var e in elements)
                {
                    groupCache.Add(new GroupData(e.Text)
                    {
                        Id = e.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupData>(groupCache);
        }

      
    }
}
