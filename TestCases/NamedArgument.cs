using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumNUnit.TestCases
{
    public class NamedArgument
    {
        //public static void Main(string[] args)
        //{
        //    PrintEmployeeDetail("John", 11, 2323);
        //}


        static void PrintEmployeeDetail(string name, int age, int empid)
        {
            Console.WriteLine("Name : {name}, Age : {age}, Employee ID : {empid}");
        }
    }
}
