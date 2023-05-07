using EmployeeWebApp.Models;
using EmployeeWebApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        //Creating a contructor for IWebHostEnvironment
        public EmployeesController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        //public JsonResult Add(AddEmployeeViewModel addEmployeeRequest)
        public IActionResult Add(AddEmployeeViewModel addEmployeeRequest)
        {
            if(!ModelState.IsValid) 
            {
                return View();
            }
            var employee = new Employee()
            {
                firstName = addEmployeeRequest.firstName,
                lastName = addEmployeeRequest.lastName
            };
            var serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(employee);
            string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "Json");
            var fileName = Guid.NewGuid().ToString() + ".json";
            string filePath = Path.Combine(uploadDir, fileName);
            
            //using(StreamWriter sw = new StreamWriter(filePath))
            //{
            //    sw.Write(serializedObject);
            //}
            
            System.IO.File.WriteAllText(filePath,serializedObject.ToString());
                         
            TempData["AlertMessage"] = "Success! Json file saved successfully in the application root path.";
            
            ModelState.Clear();
            //return Json(employee);
            
            return View();
        }        
    }
}
