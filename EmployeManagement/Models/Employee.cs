using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeManagement.Services;

namespace EmployeManagement.Models
{
    internal class Employee
    {
        

        private string _fullName;

        private string _position;

        private int _salary;

        public string DepartmentName { get; set; }

        public string No { get; set; }


        public Employee(string fullName, string position, int salary, string departmentName)
        {
            DepartmentName = $"{departmentName[0].ToString().ToUpper()}{departmentName.Substring(1).ToLower()}";
            FullName =fullName;
            Position =position;
            Salary=salary;
            
            
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
                                _fullName += item[0].ToString().ToUpper() + item.Substring(1).ToLower() + " ";
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
                        _position = value[0].ToString().ToUpper() + value.Substring(1).ToLower();
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
            set
            {
                
                while (true)
                {
                    if (value >= 250)
                    {
                        _salary = value;
                        break;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Warning!!! Minimum Salary is 250!\n");
                        Console.BackgroundColor = ConsoleColor.Black;
                        int.TryParse(Console.ReadLine(), out value);
                    }
                }
                

                

              

            }
           

        }


        public override string ToString()
        {
            return $" ---------------------------------------\n" +
                   $"| Employee NO: {No}\r\t\t\t\t\t|\n" +
                   $"| Full Name: {FullName}\r\t\t\t\t\t|\n" +
                   $"| Position: {Position}\r\t\t\t\t\t|\n" +
                   $"| Salary: {Salary}\r\t\t\t\t\t|\n" +
                   $"| Department: {DepartmentName}\r\t\t\t\t\t|\n" +
                   $" ---------------------------------------\n";

        }
    }
}
