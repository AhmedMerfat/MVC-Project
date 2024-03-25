using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    public class EmployeeController : Controller
    {
        public MyDBContext context;
        public EmployeeController()
        {
            context = new();
        }
        public IActionResult Index()
        {

            List<Employee> employees = context.Employees.Include(d => d.department).ToList();
            List<Department> departments = context.departments.ToList();
            ViewBag.departments = departments ;
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            Employee? employee = context.Employees.Find(id);
            return View(employee);
        }

        public IActionResult getaddform()
        {
            List<Department> departments = context.departments.ToList();
            return View(departments);
        }
        public IActionResult getformData(string fname,String mname , String lname ,String address ,String Sex , decimal salary, int deptId) {
            Employee employee = new Employee { FirstName = fname, LastName = lname, MiddleName = mname, Address = address, DepartmentNumber = deptId, Salary = salary };
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
