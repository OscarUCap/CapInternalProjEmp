using System.Collections.Generic;
using CapInternalProjEmp.Models;

namespace CapInternalProjEmp.Infra
{
    public interface IEmployeeRepository
    {
         

        Employee GetEmployee(int id);

        IEnumerable<Employee> GetAllEmployees(); //IEnumerable is a behavior, List is an implementation of that behavior
                                                  // EInumberble gives the compiler a chance to defer work until later.

        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employeeChanes);
        Employee Delete(int id);
    }
}