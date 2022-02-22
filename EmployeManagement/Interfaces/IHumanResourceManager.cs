using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeManagement.Models;

namespace EmployeManagement.Interfaces
{
    internal interface IHumanResourceManager
    {
        Department[] Departments { get; }
        void AddDepartment(string name, int workerLimit, int salaryLimit);
        Department[] GetDepartments();

        void EditDepartments(string departmentName, int workerLimit);
        void EditDepartments(int salarylimit,string departmentName);
        void EditDepartments(string departmentName, string departmentNewName);
        void AddEmployee(string departmentName, string fullName, string position, int salary);

        void RemoveEmployee(string departmentName, string employeeNo);
        void EditEmployee(string employeeNo, int newSalary);
        void EditEmployee(string employeeNo, string newPosition);

        Employee[] GetEmployeesByDepartmentName(string departmentName);

        Employee[] SearchEmployee(string search);


    }
}
