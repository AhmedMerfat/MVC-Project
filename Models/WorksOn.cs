using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models
{
    [PrimaryKey("EmployeeSsn" , "ProjectNumber")]
    public class WorksOn
    {

        [ForeignKey("employee")]
        public int? EmployeeSsn { get; set; }
        [ForeignKey("project")]
        public int? ProjectNumber { get; set; }
        public int Hours { get; set; }
        public Employee employee { get; set; }
        public Project project { get; set; }


    }
}
