using System;
using System.Data;
using EmployeManagement.Models;
using EmployeManagement.Services;

namespace EmployeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManagerServices humanResourceManagerServices = new HumanResourceManagerServices();

            do
            {
                Console.Clear();
                Console.Title = "Main Menu";
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Welcome!\n");
                Console.ResetColor();
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Show Departments\r\t\t\t\t|");
                Console.WriteLine("2. Create Department\r\t\t\t\t|");
                Console.WriteLine("3. Edit Department\r\t\t\t\t|");
                Console.WriteLine("4. Show Employees\r\t\t\t\t|");
                Console.WriteLine("5. Show Employees in Department\r\t\t\t\t|");
                Console.WriteLine("6. Add Employee\r\t\t\t\t|");
                Console.WriteLine("7. Edit Employee\r\t\t\t\t|");
                Console.WriteLine("8. Remove Employee\r\t\t\t\t|");
                Console.WriteLine("9. Search Employee\r\t\t\t\t|");
                Console.WriteLine("10. Exit\r\t\t\t\t|");
                Console.WriteLine("--------------------------------");
                int choose;
                while (!int.TryParse(Console.ReadLine(), out choose) || choose < 1 || choose > 10)
                {
                    Console.WriteLine("Make choose right!");
                }

                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        ShowDepartaments(humanResourceManagerServices);
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        AddDepartment(humanResourceManagerServices);
                        Console.ReadLine();
                        break;
                    case 3:
                        ChangeDepartmentInfoMenu(humanResourceManagerServices);
                        break;
                    case 4:
                        Console.Clear();
                        ShowEmployees(humanResourceManagerServices);
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        ShowDepartmentEmployees(humanResourceManagerServices); // we have get Employe By department name
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        AddEmployee(humanResourceManagerServices);
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.Clear();
                        ChangeEmployeeInfoMenu(humanResourceManagerServices);
                        Console.ReadLine();
                        break;
                    case 8:
                        Console.Clear();
                        DeleteEmployee(humanResourceManagerServices);
                        Console.ReadLine();
                        break;
                    case 9:
                        Console.Clear();
                        FindEmployees(humanResourceManagerServices);
                        Console.ReadLine();
                        break;
                    case 10:
                        Console.WriteLine("Shutting down...");
                        return;
                }
            } while (true);
        }

        public static void ShowDepartaments(HumanResourceManagerServices humanResourceManagerServices)
        {
            Console.Title = "Show Department";
            foreach (Department department in humanResourceManagerServices.GetDepartments())
            {
                if (department != null)
                {
                    Console.WriteLine(department);
                }
            }

            humanResourceManagerServices.GetDepartments();
        }
        public static void AddDepartment(HumanResourceManagerServices humanResourceManagerServices)
        {
            Console.Title = "Add Department";
            Console.WriteLine("Name of Department: ");
            string name = Console.ReadLine();
            Console.WriteLine("Worker limit: ");
            int.TryParse(Console.ReadLine(), out int workerLimit);
            Console.WriteLine("Salary Limit: ");
            int.TryParse(Console.ReadLine(), out int salarylimit);

            humanResourceManagerServices.AddDepartment(name,workerLimit,salarylimit);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Department has been created!");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void ChangeDepartmentInfoMenu(HumanResourceManagerServices humanResourceManagerServices)
        {
            Console.Title = "Edit Department Menu";
            int choose;
            string name;
            while (true)
            {
                Console.Clear();
                ShowDepartaments(humanResourceManagerServices);
                Console.WriteLine("Enter Department name: ");
                name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("1. Change Department Name");
                Console.WriteLine("2. Change Department Work Limit");
                Console.WriteLine("3. Change Department Salary Limit");
                Console.WriteLine("4. Back to the Main Menu");
                int.TryParse(Console.ReadLine(), out choose);

                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter New Department Name: ");
                        humanResourceManagerServices.EditDepartments(name,Console.ReadLine());
                        Console.ReadLine();
                        return;
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter new Work Limit: ");
                        int.TryParse(Console.ReadLine(), out int workerLimit);
                        humanResourceManagerServices.EditDepartments(name,workerLimit);
                        Console.ReadLine(); // Can be moved to Service Class for each
                        return;
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter new Salary Limit");
                        int.TryParse(Console.ReadLine(), out int salaryLimit);
                        humanResourceManagerServices.EditDepartments(salaryLimit,name);
                        Console.ReadLine();
                        return;
                        break;
                    case 4:
                        return;
                }
            }
        }

        public static void AddEmployee(HumanResourceManagerServices humanResourceManagerServices)
        {
            Console.Title = "Add Employee";
            if (humanResourceManagerServices.Departments.Length > 0)
            {
               
                foreach (Department department  in humanResourceManagerServices.Departments)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine("Create Department First!");
                return;
            }

            Console.WriteLine("\nEnter Department Name");
            string departmentName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter Full Name: ");
            string employeeName = Console.ReadLine();

            Console.WriteLine("Enter Position: ");
            string position = Console.ReadLine();

            Console.WriteLine("Enter Salary: ");
            int.TryParse(Console.ReadLine(), out int salary);

            humanResourceManagerServices.AddEmployee(departmentName,employeeName,position,salary);
        }

        public static void ShowEmployees(HumanResourceManagerServices humanResourceManagerServices)
        {
            Console.Title = "Employees Information List";
            foreach (Department department in humanResourceManagerServices.Departments)
            {
                if (department != null)
                {
                    foreach (Employee employee in department.GetEmployees())
                    {
                        Console.WriteLine(employee);
                    }
                }
            }
        }

        public static void ShowDepartmentEmployees(HumanResourceManagerServices humanResourceManagerServices)
        {
            Console.Title = "Employees List by Department";
            if (humanResourceManagerServices.Departments.Length > 0)
            {
                foreach (Department department in humanResourceManagerServices.Departments)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine("Create Department First!");
                return;
            }
            Console.WriteLine("Enter Department Name");
            Console.Clear();
            string departmentName = Console.ReadLine();
            if (humanResourceManagerServices.GetEmployeesByDepartmentName(departmentName) != null)
            {
                foreach (Employee employee in humanResourceManagerServices.GetEmployeesByDepartmentName(departmentName))
                {
                    Console.WriteLine(employee);
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Department doesn't exist! ");
                Console.BackgroundColor = ConsoleColor.Black;
            }

              

          // NEED!!! ADD CW DOESNT EXIST DEPARTMENT!!!
            //foreach (Employee employee in humanResourceManagerServices.GetEmployeesByDepartmentName(departmentName)) // need to test
            //{
            //    Console.WriteLine(employee);
            //}  //test HAS BEEN CRUSHED! :(  NEED TO CHECK WHY???
        }

        public static void ChangeEmployeeInfoMenu(HumanResourceManagerServices humanResourceManagerServices)
        {
            Console.Title = "Edit Employee Information Menu";
            int choose;
            string employeeNo;
            while (true)
            {
                Console.Clear();
                ShowEmployees(humanResourceManagerServices);
                Console.WriteLine("Enter Employee No: ");
                employeeNo = Console.ReadLine();
                Console.WriteLine("1. Change Employee Position");
                Console.WriteLine("2. Change Employee Salary");
                Console.WriteLine("3. Back to main Menu");
                int.TryParse(Console.ReadLine(), out choose);

                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter New position: "); // for {employe no} maybe ?
                        humanResourceManagerServices.EditEmployee(employeeNo, Console.ReadLine());
                        Console.ReadLine();
                        return;
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter new Salary: ");
                        int.TryParse(Console.ReadLine(), out int newSalary);
                        humanResourceManagerServices.EditEmployee(employeeNo,newSalary);
                        Console.ReadLine(); // Can be moved to Service Class for each
                        return;
                        break;
                    case 3:
                        return;
                }
            }
        }

        public static void DeleteEmployee(HumanResourceManagerServices humanResourceManagerServices)
        {
            Console.Title = "Remove Employee from Department";
            if (humanResourceManagerServices.Departments.Length > 0)
            {
                
                foreach (Department department in humanResourceManagerServices.Departments)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine("Create Department First!");
                return;
            }
            Console.WriteLine("Enter Department Name");
            string departmentName = Console.ReadLine();
            Console.Clear();

            //show employees in department - use method to extract for each loop printing
            if (humanResourceManagerServices.GetEmployeesByDepartmentName(departmentName) != null)
            {
                foreach (Employee employee in humanResourceManagerServices.GetEmployeesByDepartmentName(departmentName))
                {
                    if (employee != null)
                    {
                        Console.WriteLine(employee);
                    }
                    
                }
            }
            else
            {
                return;
            }
            

            Console.WriteLine("Enter EmployeeNo: ");
            string employeeNo = Console.ReadLine();

            humanResourceManagerServices.RemoveEmployee(departmentName,employeeNo);

            
        }

        public static void FindEmployees(HumanResourceManagerServices humanResourceManagerServices)
        {
            Console.Title = "Search Employees by Information";
            Console.WriteLine("Enter information about Employee: Name, Surename, Position, EmployeeNo.");
            string search = Console.ReadLine()??" ";


            if (humanResourceManagerServices.SearchEmployee(search)!=null)
            {
                foreach (Employee employee in humanResourceManagerServices.SearchEmployee(search))
                {
                    if (employee != null)
                    {
                        Console.WriteLine(employee);
                    }
                }
            }
        }
    }
}