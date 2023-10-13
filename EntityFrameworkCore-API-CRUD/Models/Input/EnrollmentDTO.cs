namespace EntityFrameworkCore_API_CRUD.Models.Input
{
    public class EnrollmentDTO
    {
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
    }
}
