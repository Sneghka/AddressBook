using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using NUnit.Framework;

namespace addressbook_web_tests.Model
{
    [Table(Name="addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name="firstname")]
        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        public string NickName { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string CompanyAddress { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Anniversary { get; set; }
        public string Group { get; set; }
        public string SecondaryAddress { get; set; }
        public string SecondaryHomePhone { get; set; }
        public string Notes { get; set; }
        public string PathToPhoto { get; set; }
        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                return (Cleanup(HomePhone) + Cleanup(MobilePhone) + Cleanup(WorkPhone)).Trim();
            }
            set {  allPhones = value; }
        }


        public ContactData()
        {
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        private string Cleanup(string phone)
        {
            if (phone == null) return "";
            return Regex.Replace(phone, "[ -()]" , "") + "\r\n";
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null)) return false;
            if (object.ReferenceEquals(this, other)) return true;

            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + FirstName;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null)) return 1;

            return FirstName.CompareTo(other.FirstName);
        }

       
    }
}
