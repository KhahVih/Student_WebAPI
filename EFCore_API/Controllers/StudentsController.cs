using EFCore_API.Model;
using EFCore_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly ILibraryService _libraryService;

        public StudentsController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _libraryService.GetStudentAsync();

            if (students == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No student in database");
            }

            return StatusCode(StatusCodes.Status200OK, students);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetStudent(int id, bool includeBooks = false)
        {
            Students students = await _libraryService.GetStudentsAsync(id, includeBooks);

            if (students == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Author found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, students);
        }

        [HttpPost]
        public async Task<ActionResult<Students>> AddStudents(Students students)
        {
            var dbStudents = await _libraryService.AddStudentsAsync(students);

            if (dbStudents == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{students.Name} could not be added.");
            }

            return CreatedAtAction("GetStudent", new { id = students.StudentId }, students);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateStudents(int id, Students students)
        {
            if (id != students.StudentId)
            {
                return BadRequest();
            }

            Students dbstudents = await _libraryService.UpdateStudentAsync(students);

            if (dbstudents == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{students.Name} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteStudents(int id)
        {
            var student = await _libraryService.GetStudentsAsync(id, false);
            (bool status, string message) = await _libraryService.DeleteStudentAsync(student);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, student);
        }
    }
   
}
