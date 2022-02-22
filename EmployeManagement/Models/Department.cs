using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeManagement.Models
{
    internal class Department
    {
        private string _name;
        private int _workerLimit;
        private int _salaryLimit;
        private Employee[] Employees;

        public Department(string name, int workerLimit, int salaryLimit)
        {
            Name = name;
            WorkerLimit = workerLimit;
            SalaryLimit = salaryLimit;
            Employees = new Employee[0];
        }
        public string Name
        {
            get => _name;

            set
            {
                while (true)
                {
                    value = value.Trim();
                    if (value.Length > 1 && !string.IsNullOrWhiteSpace(value))
                    {
                        _name = value[0].ToString().ToUpper() + value.Substring(1);
                        break;
                    }
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Warning!!! Please Enter Department Name Correctly!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    value = Console.ReadLine();
                }
            }
        }

        public int WorkerLimit
        {
            get => _workerLimit;

            set
            {
                while (true)  // can make some changes here for better code: while(tryparse && value>1)
                {
                    if (value > 1) 
                    {
                        _workerLimit = value;
                        break;
                    }
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Warning!!! Please Enter Worker Limit Correctly!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    int.TryParse(Console.ReadLine(), out value);
                }
            }
        }

        public int SalaryLimit
        {
            get => _salaryLimit;

            set
            {
                while (true)  // can make some changes here for better code: while(tryparse && value>250)
                {
                    if (value > 250)
                    {
                        _salaryLimit = value;
                        break;
                    }
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Warning!!! Please Enter Salary Limit Correctly!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    int.TryParse(Console.ReadLine(), out value);
                }
            }
        }

        public void AddEmployee(Employee employee)
        {
            if (Employees.Length < WorkerLimit)
            {
                Array.Resize(ref Employees, Employees.Length + 1);
                Employees[Employees.Length - 1] = employee;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Warning!!! Department is Full!");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public Employee[] GetEmployees() => Employees; // return array of Employees in this department

        public double CalcSalaryAverage()
        {
            double average = 0;
            foreach (Employee employee in Employees)
            {
                average+=employee.Salary;
            }

            return average / Employees.Length;
        }
        public override string ToString()
        {
            return $"Department Name: {Name}\n" +
                   $"Worker Limit: {WorkerLimit}\n" +
                   $"Salary Limit: {SalaryLimit}\n" +
                   $"Employees in Department: {Employees.Length}";
        }

        public int EmployeeSize()
        {
            return Employees.Length+1;
        }

    }
}
