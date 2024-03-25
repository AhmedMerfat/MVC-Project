using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models
{
    public class Department
    {
        [Key]
        public int DepartmentNumber { get; set; }
        public String Name { get; set; }
        [ForeignKey("manager")]
        public int? ManagerSsn { get; set; }
        public DateTime? ManagerStartDate { get; set; }
        public List<Employee> employees { get; set; }
        public Employee manager { get; set; }
    }
}
