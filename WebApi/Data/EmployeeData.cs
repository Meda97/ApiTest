using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public interface EmployeeData
    {
        List<Employee> GetEmployees();

        //Hämtar enstaka Employee
        Employee GetEmployee(Guid Id);

        //Lägger till employee
        Employee AddEmployee(Employee employee);

        //Tar bort employee
        void DeleteEmployee(Employee employee);

        //Ändrar Employee
        Employee EditEmployee(Employee employee);
    }
}
