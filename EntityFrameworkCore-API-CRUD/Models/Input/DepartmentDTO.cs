using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore_API_CRUD.Models.Input
{
    public class DepartmentDTO
    {
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public int? InstructorID { get; set; }

    }
}
