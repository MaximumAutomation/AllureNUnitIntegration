using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumNUnit.TestCases
{
    public class CustomNamingDemo
    {
        private readonly string _firstName;
        private readonly string _lastname;
        private readonly string _middleName;
        public int MyProperty { get; set; }
        public CustomNamingDemo(string FirstName, string Lastname, string MiddleName, string Suffix)
        {
            _firstName = FirstName;
            _lastname = Lastname;
            _middleName = MiddleName;
        }
    }
}
