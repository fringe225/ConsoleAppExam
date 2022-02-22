using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeManagement.Interfaces;
using EmployeManagement.Models;

namespace EmployeManagement.Services
{
    internal class HumanResourceManagerServices : IHumanResourceManager
    {
        private Department[] _departments;
        public Department[] Departments => _departments;

        public HumanResourceManagerServices()
        {
            _departments = new Department[0];
        }

        public void AddDepartment(string name, int workerLimit, int salaryLimit)
        {
            Department department = new Department(name, workerLimit, salaryLimit);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;
        }

        public Department[] GetDepartments() => _departments; // return all departments

        public void EditDepartments(string departmentName, int workerLimit)
        {
            Department department = FindDepartment(departmentName);

            if (department != null)
            {
                int temp = department.WorkerLimit;
                department.WorkerLimit = workerLimit;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Worker Limit for Department {departmentName} has been changed" +
                                  $" from {temp} to {department.WorkerLimit}.");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Warning!!! Department Name doesn't exist!");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void EditDepartments(int salarylimit, string departmentName)
        {
            Department department = FindDepartment(departmentName);

            if (department != null)
            {
                int temp = department.SalaryLimit;
                department.SalaryLimit = salarylimit;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Salary Limit for Department {departmentName} has been changed" +
                                  $" from {temp} to {department.SalaryLimit}.");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Warning!!! Department Name doesn't exist!");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void EditDepartments(string departmentName, string departmentNewName)
        {
            Department department = FindDepartment(departmentName);

            if (department != null)
            {
                string temp = department.Name;
                department.Name = departmentNewName;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Department Name for Department {departmentName} has been changed" +
                                  $" from {temp} to {department.Name}.");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Warning!!! Department Name doesn't exist!");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void AddEmployee(string departmentName, string fullName, string position, int salary)
        {
            Department department = FindDepartment(departmentName);
            if (department != null)
            {
                Employee employee = new Employee(fullName, position, salary, departmentName);
                department.AddEmployee(employee);
                return;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Warning!!! Department Name doesn't exist!");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void RemoveEmployee(string departmentName, string employeeNo) //have to add some changes with REF
        {
            Department department = FindDepartment(departmentName);
            Employee[] employeeArr = new Employee[department.GetEmployees().Length - 1];
            if (department != null)
            {
                int temp = 0;
                for (int i = 0; i < department.GetEmployees().Length; i++)
                {
                    if (department.GetEmployees()[i].No == employeeNo)
                    {
                        temp = i;
                    }
                }

                for (int i = 0; i < temp; i++)
                {
                    employeeArr[i] = department.GetEmployees()[i];
                }

                for (int i = temp + 1; i < employeeArr.Length; i++)
                {
                    employeeArr[i] = department.GetEmployees()[i];
                }

                department.EmployeesProp = employeeArr;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Warning!!! Department Name doesn't exist!");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void EditEmployee(string employeeNo, int newSalary)
        {
            foreach (Department department in Departments)
            {
                if (department != null)
                {
                    foreach (Employee employee in department.GetEmployees())
                    {
                        if (employee.No == employeeNo)
                        {
                            int temp = employee.Salary;
                            employee.Salary = newSalary;
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Salary for Employee {employee.FullName} has been changed" +
                                              $" from {temp} to {employee.Salary}.");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Warning!!! Employee with NO-{employeeNo} doesn't exist!");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }

        public void EditEmployee(string employeeNo, string newPosition)
        {
            foreach (Department department in Departments)
            {
                if (department != null)
                {
                    foreach (Employee employee in department.GetEmployees())
                    {
                        if (employee.No == employeeNo)
                        {
                            string temp = employee.Position;
                            employee.Position = newPosition;
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Position for Employee {employee.FullName} has been changed" +
                                              $" from {temp} to {employee.Position}.");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                       
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Warning!!! Employee with NO-{employeeNo} doesn't exist!");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }

        public Employee[] GetEmployeesByDepartmentName(string departmentName)
        {
            Department department = FindDepartment(departmentName);
            if (department != null)
            {
                return department.GetEmployees();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Warning!!! Department Name doesn't exist!");
                Console.BackgroundColor = ConsoleColor.Black;
                return null;
            }
        }

        public Employee[] SearchEmployee(string search)
        {
            Employee[] findEmployees = new Employee[0];
            foreach (Department department in Departments)
            {
                if (department != null)
                {
                    foreach (Employee employee in department.GetEmployees())
                    {
                        if (employee != null && (employee.FullName.ToLower().Contains(search.ToLower()) ||
                                                 employee.No.ToLower().Contains(search.ToLower()) ||
                                                 employee.Position.ToLower().Contains(search.ToLower()) ||
                                                 employee.Salary.ToString().ToLower().Contains(search.ToLower()) ||
                                                 employee.DepartmentName.ToString()
                                                     .ToLower()
                                                     .Contains(search.ToLower())))
                        {
                            Array.Resize(ref findEmployees, findEmployees.Length + 1);
                            findEmployees[findEmployees.Length - 1] = employee;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Warning!!! Can't Find Any Employee with that Information!");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                    }
                }
            }

            return findEmployees;
        }

        private Department FindDepartment(string departmentName)
        {
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == departmentName.ToLower())
                {
                    return item;
                }
            }

            return null;
        }
    }
}