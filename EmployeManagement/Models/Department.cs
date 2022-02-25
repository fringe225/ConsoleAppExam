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
        private int _addedEmployes = 0;

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
                        _name = value[0].ToString().ToUpper() + value.Substring(1).ToLower();
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
                while (true) // can make some changes here for better code: while(tryparse && value>1)
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
                while (true) // can make some changes here for better code: while(tryparse && value>250)
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
            int salaryResult = 1;

            if (CurrentEmployeeSize() < WorkerLimit)
            {
                while (salaryResult != 0)
                {
                    if (CalcSalaryAverage() * CurrentEmployeeSize() + employee.Salary <= SalaryLimit ||
                        (employee.Salary <= SalaryLimit && Employees.Length == 0))
                    {
                        for (int i = 0; i < Employees.Length; i++)
                        {
                            if (Employees[i] == null)
                            {
                                employee.No = $"{employee.DepartmentName[0..2].ToUpper()}{1000 + _addedEmployes + 1}";
                                _addedEmployes++;
                                Employees[i] = employee;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"Employee created with NO {employee.No} !");
                                Console.BackgroundColor = ConsoleColor.Black;
                                return;
                            }
                        }

                        Array.Resize(ref Employees, Employees.Length + 1);
                        employee.No = $"{employee.DepartmentName[0..2].ToUpper()}{1000 + _addedEmployes + 1}";
                        _addedEmployes++;
                        Employees[^1] = employee;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Employee created with NO {employee.No} !");
                        Console.BackgroundColor = ConsoleColor.Black;
                        return;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Warning!!! Salary Limit for {Name} is {SalaryLimit}!\n" +
                                          $"Your Employees Salaries Sum is {CalcSalaryAverage() * CurrentEmployeeSize()}!\n" +
                                          $"You can set Salary only between 250 - {SalaryLimit - CalcSalaryAverage() * CurrentEmployeeSize()}");
                        Console.BackgroundColor = ConsoleColor.Black;
                        int.TryParse(Console.ReadLine(), out salaryResult);
                        employee.Salary = salaryResult == 0 ? employee.Salary : salaryResult;
                    }
                }
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
            int count = 0;
            foreach (Employee employee in Employees)
            {
                if (employee != null)
                {
                    average += employee.Salary;
                    count++;
                }
            }

            return (double) average / count;
        }

        public int CurrentEmployeeSize()
        {
            int count = 0;
            foreach (Employee employee in Employees)
            {
                if (employee != null)
                {
                    count++;
                }
            }

            return count;
        }

        public int EditSalary(Employee employee, int newSalary)
        {
            int salaryResult = newSalary;
            while (salaryResult != 0)
            {
                if (CalcSalaryAverage() * CurrentEmployeeSize() + salaryResult- employee.Salary <= SalaryLimit)
                {
                    return salaryResult;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Warning!!! Salary Limit for {Name} is {SalaryLimit}!\n" +
                                      $"Your Employees Salaries Sum is {CalcSalaryAverage() * CurrentEmployeeSize()-employee.Salary}!\n" +
                                      $"You can set Salary only between 250 - {SalaryLimit - (CalcSalaryAverage() * CurrentEmployeeSize()-employee.Salary)}");
                    Console.BackgroundColor = ConsoleColor.Black;
                    int.TryParse(Console.ReadLine(), out salaryResult);
                    //employee.Salary = salaryResult == 0 ? employee.Salary : salaryResult;
                }
            }

            return 0;
        }

        public override string ToString()
        {
            return $"------------------------------------\n" + $"Department Name: {Name}             |\n" +
                   $"Worker Limit: {WorkerLimit}         |\n" + $"Salary Limit: {SalaryLimit}         |\n" +
                   $"Employees in Department: {Employees.Length}|\n" + $"------------------------------------\n";
        }
    }
}