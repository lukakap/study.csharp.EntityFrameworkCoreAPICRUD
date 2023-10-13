  using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore_API_CRUD.Models
{
    public class Student
    {
        // By default, EF interprets a property that's named ID or classnameID as the primary key
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [Column("FirstName")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        // Navigation property for related enrollments
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
