using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeManagement.Models
{
    internal class Employee
    {
        private static int _count=1000;

        private string _fullName;

        private string _position;

        private int _salary;

        public string DepartmentName { get; set; }

        public string No { get; set; }


        public Employee(string fullName, string position, int salary, string departmentName)
        {
            FullName=fullName;
            Position=position;
            Salary=salary;
            DepartmentName=departmentName;
            _count++;
            No = $"{DepartmentName[0..2].ToUpper()}{_count}";
        }

        public string FullName
        {
            get => _fullName;
            set
            {
                string[] arr;
                while (true)
                {
                    value = value.Trim();
                    arr = value.Split(" ");
                    if (arr.Length > 1 && arr.Length <= 3)
                    {
                        foreach (string item in arr)
                        {
                            if (!string.IsNullOrWhiteSpace(item))
                            {
                                _fullName += item[0].ToString().ToUpper() + item.Substring(1) + " ";
                            }

                        }
                        break;
                    }
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Warning!!! Please Enter Full Name Correctly!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    value = Console.ReadLine()??"";
                }
            }
        }

        public string Position
        {
            get => _position;

            set
            {
                while (true)
                {
                    value = value.Trim();
                    if (value.Length>1 && !string.IsNullOrWhiteSpace(value))
                    {
                        _position = value[0].ToString().ToUpper() + value.Substring(1);
                        break;
                    }
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Warning!!! Please Enter Position Correctly!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    value = Console.ReadLine();
                }
            }
        }

        public int Salary
        {
            get => _salary;
            set => _salary = value;
            //set departament name == dep name =>salary Limit find

        }


        public override string ToString()
        {
            return $"Employee NO: {No}\n" +
                   $"Full Name: {FullName}\n" +
                   $"Position: {Position}\n" +
                   $"Salary: {Salary}\n" +
                   $"Department: {DepartmentName}";

        }
    }
}
