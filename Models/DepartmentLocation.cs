using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models
{
    [PrimaryKey("DepartmentNumber", "Location")]
    public class DepartmentLocation
    {

        [ForeignKey("department")]
        public int? DepartmentNumber { get; set; }
        public String Location { get; set; }
        public Department department { get; set; }



    }
}
