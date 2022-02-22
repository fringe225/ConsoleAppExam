using System;
using System.Data;
using EmployeManagement.Models;
using EmployeManagement.Interfaces;
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
                Console.WriteLine("Seciminizi Edin");
                Console.WriteLine("1. Departameantlerin siyahisini gostermek");
                Console.WriteLine("2. Departamenet yaratmaq");
                Console.WriteLine("3. Departmanetde deyisiklik etmek");
                Console.WriteLine("4. Iscilerin siyahisini gostermek");
                Console.WriteLine("5. Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine("6. Isci elave etmek");
                Console.WriteLine("7. Isci uzerinde deyisiklik etmek");
                Console.WriteLine("8. Departamentden isci silinmesi");
                Console.WriteLine("9. exit");

                int choose;
                while (!int.TryParse(Console.ReadLine(), out choose) || choose < 1 || choose > 9)
                {
                    Console.WriteLine("Duzgun Secim Edin");
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
                        Console.WriteLine("Tesekkurler Sagolun");
                        return;
                }
            } while (true);
        }

        public static void ShowDepartaments(HumanResourceManagerServices humanResourceManagerServices)
        {
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
            Console.WriteLine("Name of Department: ");
            string name = Console.ReadLine();
            Console.WriteLine("Worker limit: ");
            int.TryParse(Console.ReadLine(), out int workerLimit);
            Console.WriteLine("Salary Limit: ");
            int.TryParse(Console.ReadLine(), out int salarylimit);

            humanResourceManagerServices.AddDepartment(name,workerLimit,salarylimit);
            Console.WriteLine("Department have been Created!");
        }

        public static void ChangeDepartmentInfoMenu(HumanResourceManagerServices humanResourceManagerServices)
        {
            int choose;
            string name;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter Department name: ");
                name = Console.ReadLine();
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
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter new Work Limit: ");
                        int.TryParse(Console.ReadLine(), out int workerLimit);
                        humanResourceManagerServices.EditDepartments(name,workerLimit);
                        Console.ReadLine(); // Can be moved to Service Class for each
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter new Salary Limit");
                        int.TryParse(Console.ReadLine(), out int salaryLimit);
                        humanResourceManagerServices.EditDepartments(salaryLimit,name);
                        Console.ReadLine();
                        break;
                    case 4:
                        return;
                }
            }
        }

        public static void AddEmployee(HumanResourceManagerServices humanResourceManagerServices)
        {
            if (humanResourceManagerServices.Departments.Length > 0)
            {
                Console.WriteLine("Enter Department Name");
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

            string departmentName = Console.ReadLine();

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
            if (humanResourceManagerServices.Departments.Length > 0)
            {
                Console.WriteLine("Enter Department Name");
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

            string departmentName = Console.ReadLine();

            foreach (Department department in humanResourceManagerServices.Departments)
            {
                if (department.Name == departmentName)
                {
                    foreach (Employee employee in department.GetEmployees())
                    {
                        Console.WriteLine(employee);
                    }

                    break;
                }
            } // NEED!!! ADD CW DOESNT EXIST DEPARTMENT!!!
            //foreach (Employee employee in humanResourceManagerServices.GetEmployeesByDepartmentName(departmentName)) // need to test
            //{
            //    Console.WriteLine(employee);
            //}  //test HAS BEEN CRUSHED! :(  NEED TO CHECK WHY???
        }

        public static void ChangeEmployeeInfoMenu(HumanResourceManagerServices humanResourceManagerServices)
        {
            int choose;
            string employeeNo;
            while (true)
            {
                Console.Clear();
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
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter new Salary: ");
                        int.TryParse(Console.ReadLine(), out int newSalary);
                        humanResourceManagerServices.EditEmployee(employeeNo,newSalary);
                        Console.ReadLine(); // Can be moved to Service Class for each
                        break;
                    case 3:
                        return;
                }
            }
        }

        public static void DeleteEmployee(HumanResourceManagerServices humanResourceManagerServices)
        {
            if (humanResourceManagerServices.Departments.Length > 0)
            {
                Console.WriteLine("Enter Department Name");
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

            string departmentName = Console.ReadLine();

            //show employees in department - use method to extract for each loop printing

            Console.WriteLine("Enter EmployeeNo: ");
            string employeeNo = Console.ReadLine();

            humanResourceManagerServices.RemoveEmployee(departmentName,employeeNo);
        }
    }
}