using System.Collections.Generic;
using System.Linq;
using CapInternalProjEmp.Models;

namespace CapInternalProjEmp.Infra
{
    public class MockEmployeeRepository : IEmployeeRepository
    {

        private List<Employee> _employeeList;

        public MockEmployeeRepository(){
            _employeeList = new List<Employee>(){
                new Employee() { Id = 1, Name = "Mary", Department = Dept.None, Email = "mary@cap.com" },
                new Employee() { Id = 2, Name = "John", Department = Dept.None, Email = "john@cap.com" },
                new Employee() { Id = 3, Name = "Sam", Department = Dept.None, Email = "sam@cap.com" }
            };
        }

        public Employee AddEmployee(Employee employee)
        {
            // System.Console.WriteLine(employee.Name);
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);

            return employee;
        }

        public Employee Delete(int id)
        {
            var emp = _employeeList.FirstOrDefault(e => e.Id == id);
            if(emp != null){
                _employeeList.Remove(emp);
            }
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
            
        }

        public Employee UpdateEmployee(Employee employeeChanes)
        {
            var emp = _employeeList.FirstOrDefault(e => e.Id == employeeChanes.Id);
            if(emp != null){
                emp.Id = employeeChanes.Id;
                emp.Name = employeeChanes.Name;
                emp.Department = employeeChanes.Department;
                emp.Email = employeeChanes.Email;
            }

            return emp;
        }
    }
}