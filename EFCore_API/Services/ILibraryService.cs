using EFCore_API.Model;

namespace EFCore_API.Services
{
    public interface ILibraryService
    {
        // Students Services
        Task<List<Students>> GetStudentAsync(); // GET All Student
        Task<Students> GetStudentsAsync(int id, bool includeBooks = false); // GET Single Student
        Task<Students> AddStudentsAsync(Students students); // POST New student
        Task<Students> UpdateStudentAsync(Students students); // PUT student
        Task<(bool, string)> DeleteStudentAsync(Students students); // DELETE student

        // Courses Services
        Task<List<Courses>> GetCoursesAsync(); // GET All Courses
        Task<Courses> GetCoursesAsync(int id); // Get Single Courses
        Task<Courses> AddCoursesAsync(Courses courses); // POST New Courses
        Task<Courses> UpdateCoursesAsync(Courses courses); // PUT Courses
        Task<(bool, string)> DeleteCoursesAsync(Courses courses); // DELETE Courses
    }
}
