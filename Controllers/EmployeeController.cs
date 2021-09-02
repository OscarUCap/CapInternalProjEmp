using CapInternalProjEmp.Models;
using CapInternalProjEmp.Infra;
using Microsoft.AspNetCore.Mvc;

namespace CapInternalProjEmp.Controllers
{
    public class EmployeeController : Controller
    {
        
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


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