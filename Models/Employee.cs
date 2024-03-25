using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models
{
    public class Employee
    {
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        [Key]
        public int Ssn { get; set; }
        public DateTime? BirthDate { get; set; }
        public String Address { get; set; }
        public char Sex { get; set; }
        [Column(TypeName ="money")]
        public decimal Salary { get; set; }
        [ForeignKey("supervisor")]
        public int? SupuervisorSsn { get; set; }
        [ForeignKey("department")]
        public int? DepartmentNumber { get; set; }
        [InverseProperty("employees")]
        public Department? department { get; set; }
        [InverseProperty("manager")]
        public List<Department> departments { get; set; }

        [InverseProperty("group")]
        public Employee supervisor { get; set; }

        public List<Employee> group { get; set; } = new List<Employee>();

        public List<WorksOn> worksOns { get; set; } = new List<WorksOn>();
        public List<Dependent> dependent { get; set; } = new List<Dependent>();
    }
}
