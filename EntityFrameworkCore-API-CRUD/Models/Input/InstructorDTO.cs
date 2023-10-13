using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore_API_CRUD.Models.Input
{
    public class InstructorDTO
    {
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
    }
}
