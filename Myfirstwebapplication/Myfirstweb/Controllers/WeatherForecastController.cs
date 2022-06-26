using Microsoft.AspNetCore.Mvc;

namespace Myfirstweb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

         readonly ILogger<WeatherForecastController> _logger;
        private List<Employee> Employees = new List<Employee>();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [HttpPost("{id},{name},{Address}")]
        public ActionResult AddEmployee(int id, string Name, string Address)
        {
            Employee employee = new Employee();
            employee.Id = id;
            employee.Name = Name;
            employee.Address = Address;
            Employees.Add(employee);
            return Ok(Employees);
        }



        [HttpGet]
        public ActionResult GetAllEmployee()
        {
            
            return Ok(Employees);
        }




        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            int search = 0;
            for (int i = 0; i < Employees.Count; i++)
            {
                Employee employee = Employees[i];
                if (employee.Id == id)
                {
                    Employees.Remove(employee);
                    search = 1;
                }
            }
            if (search == 0)
            {
                return Ok("Record not found to delete ");
            }
            return Ok("Deleted");
        }


        [HttpPatch("{id},{name},{address}")]
        public ActionResult AlsoAddnewEmployee(int id, string name, string address)
        {
            Employee employee = new Employee { Id = id, Name = name, Address = address };
            Employees.Add(employee);
            return Ok("Employee Added");
        }



        [HttpPut("{UpdateId},{name},{Address}")]
        public ActionResult UpdateEmployee(int UpdateId, string name, string Address)
        {
            int search = 0;
            for (int i = 0; i < Employees.Count; i++)
            {
                Employee employee = Employees[i];
                if (employee.Id == UpdateId)
                {
                    employee.Name = name;
                    employee.Address = Address;
                }
            }
            if (search == 0)
            {
                return Ok("Record not found to updated ");
            }
            return Ok("Updated");
        }

    }
    }
