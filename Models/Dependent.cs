using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models
{
    [PrimaryKey("EmployeeSsn" , "DependentName")]
    public class Dependent
    {
        [ForeignKey("employee")]
        public int? EmployeeSsn { get; set; }
        public string DependentName { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Relationship { get; set; }

        public Employee employee { get; set; }
    }
}
