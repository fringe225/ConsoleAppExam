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
            DepartmentName = departmentName;
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
                _salary = value;
                //Department tempDepartment=null;
                //int salarySum = 0;
                //HumanResourceManagerServices humanResorceManagerServices = new HumanResourceManagerServices(); // will be NULL DEPARTMENT HERE EVERY TIME CAUSE OF NEW INSTANCE
                //foreach (Department department in humanResorceManagerServices.Departments)
                //{
                //    if (department.Name.ToLower() == DepartmentName.ToLower())
                //    {

                //        tempDepartment = department;

                //    }
                //}

                //if (tempDepartment.GetEmployees() != null)
                //{
                //    foreach (Employee employee in tempDepartment.GetEmployees())
                //    {
                //        salarySum += employee.Salary;
                //    }
                //}

                //salarySum += value;
                //while (true)
                //{
                    //if (value == 0)
                    //{
                    //    Console.BackgroundColor = ConsoleColor.Red;
                    //    Console.ForegroundColor = ConsoleColor.White;
                    //    Console.WriteLine("Warrning!!! You Can't Create Employee with Salary - 0 or Edit Employee Salary to 0!");
                    //    Console.BackgroundColor = ConsoleColor.Black;
                    //    return;
                    //}
                    //if (value >= 250)
                    //{
                    //    _salary = value;
                    //    break;
                    //}
                    
                    //Console.BackgroundColor = ConsoleColor.Red;
                    //Console.ForegroundColor = ConsoleColor.White;
                    //Console.WriteLine($"Warning!!!Please Enter Salary Correctly!\n");
                    //Console.BackgroundColor = ConsoleColor.Black;

                    //int.TryParse(Console.ReadLine(), out value);

                //}
                //Console.WriteLine($"Warning!!! Salary Limit for {tempDepartment.Name} is {tempDepartment.SalaryLimit}!\n" +
                //                  $"Your Employees Salaries Sum is {salarySum - value}!\n" +
                //                  $"Enter Salary correctly!");

            }
            //set departament name == dep name =>salary Limit find

        }


        public override string ToString()
        {
            return $"Employee NO: {No}\n" +
                   $"Full Name: {FullName}\n" +
                   $"Position: {Position}\n" +
                   $"Salary: {Salary}\n" +
                   $"Department: {DepartmentName}\n";

        }
    }
}
