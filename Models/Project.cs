using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models
{
    public class Project
    {

        public String Name { get; set; }
        [Key]
        public int ProjectNumber { get; set; }
        public String Location { get; set; }
        [ForeignKey("department")]
        public int? DepartmentNumber { get; set; }

        public Department department { get; set; }
        public virtual List<WorksOn> WorksOns { get; set; } = new List<WorksOn>();


    }
}
