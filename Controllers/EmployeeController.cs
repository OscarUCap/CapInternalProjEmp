using CapInternalProjEmp.Models;
using CapInternalProjEmp.Infra;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Ganss.Excel;

namespace CapInternalProjEmp.Controllers
{
    public class EmployeeController : Controller
    {
        
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public IActionResult DownloadTemplate(){


            // var employees = new List<Employee>
            // {
            //     new Employee() { Id = 1, Name = "Mary", Department = Dept.None, Email = "mary@cap.com" },
            //     new Employee() { Id = 2, Name = "John", Department = Dept.JrDev, Email = "john@cap.com" },
            //     new Employee() { Id = 3, Name = "Sam", Department = Dept.Director, Email = "sam@cap.com" }
            // };

            new ExcelMapper().Save("employeesTemplate.xlsx", _employeeRepository.GetAllEmployees(), "Employees");

            var employees = new ExcelMapper("employeesTemplate.xlsx").Fetch<Employee>();

            foreach(var employee in employees){
                _employeeRepository.AddEmployee(employee);
            }

            return RedirectToAction("List");
        }


//////////////////////////////////////////
        // public async Task<IActionResult> Import(IFormFile file){

        //     var employees = new List<Employee>();

        //     using (var stream = new MemoryStream()){
        //         await file.CopyToAsync(stream);

        //     }
        // }
/////////////////////////////////////////////

        public ViewResult List()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }

        public ViewResult Details(int id){
            Employee employee = _employeeRepository.GetEmployee(id);
            return View(employee); 
        }

        [HttpGet]
        public ViewResult Edit(int id){
            Employee employee = _employeeRepository.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee){
            _employeeRepository.UpdateEmployee(employee);
            //_employeeRepository.AddEmployee(employee);
            return RedirectToAction("List");
        }


        [HttpGet]
        public ViewResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee){
            
            if(ModelState.IsValid){
                Employee newEmployee = _employeeRepository.AddEmployee(employee);
                return RedirectToAction("List");
                //return RedirectToAction("Details", new { id = newEmployee.Id });
            }

            return View();
        }



        [HttpGet]
        public IActionResult Delete(int id){
            _employeeRepository.Delete(id);
            return RedirectToAction("List");
        }


        
    }
}