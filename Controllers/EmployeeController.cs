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


        
    }
}