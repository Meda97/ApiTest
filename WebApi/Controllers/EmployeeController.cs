using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeData _employeeDataContext;
        public EmployeeController(EmployeeData employeeDataContext)
        {
            _employeeDataContext = employeeDataContext;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployee()
        {
            //Hämtar alla employee (Jsonformat)
            return Ok(_employeeDataContext.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public IActionResult GetEmployee(Guid Id)
        {
            //Hämtar employee
            var employee = _employeeDataContext.GetEmployee(Id);

            //Kollar om employee finns
            if (employee != null)
            {
                //Employee finns(hämtar employee)
                return Ok(employee);
            }
            //Employee finns inte!, skickar messege plus Id
            return NotFound($"Not found employee: {Id}");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeDataContext.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id,
                employee);
        }

        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        public IActionResult DeleteEmployee(Guid Id)
        {
            //Hämtar employee
            var employee = _employeeDataContext.GetEmployee(Id);

            //Kollar om employee finns
            if (employee != null)
            {
                //Raderas här
                _employeeDataContext.DeleteEmployee(employee);
                //Raderingen har gått genom
                return Ok();
            }

            //Notfound om den inte hitar employee
            return NotFound($"Not found employee: {Id}");
        }

        [HttpPatch]
        [Route("api/[controller]/{Id}")]
        public IActionResult EditEmployee(Guid Id, Employee employee)
        {
            //Hämtar Employee
            var FoundEmployee = _employeeDataContext.GetEmployee(Id);
            //Kollar om employee finns
            if (FoundEmployee != null)
            {
                //Ändrar employee
                employee.Id = FoundEmployee.Id;
                _employeeDataContext.EditEmployee(employee);
            }

            return Ok(employee);
        }
    }
}
