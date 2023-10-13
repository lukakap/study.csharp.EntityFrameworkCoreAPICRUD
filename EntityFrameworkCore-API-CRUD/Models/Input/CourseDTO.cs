using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore_API_CRUD.Models.Input
{
    public class CourseDTO
    {
        public int CourseID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        [Range(0, 5)]
        public int Credits { get; set; }
        public int? DepartmentID { get; set; }
    }
}
