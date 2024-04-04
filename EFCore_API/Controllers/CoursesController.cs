using EFCore_API.Model;
using EFCore_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public CoursesController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _libraryService.GetCoursesAsync();
            if (courses == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No books in database.");
            }

            return StatusCode(StatusCodes.Status200OK, courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            Courses courses = await _libraryService.GetCoursesAsync(id);

            if (courses == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No book found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, courses);
        }

        [HttpPost]
        public async Task<ActionResult<Courses>> AddCourses(Courses courses)
        {
            var dbBook = await _libraryService.AddCoursesAsync(courses);

            if (dbBook == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{courses.CourseName} could not be added.");
            }

            return CreatedAtAction("GetCourse", new { id = courses.CourseId }, courses);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourses(int id, Courses courses)
        {
            if (id != courses.CourseId)
            {
                return BadRequest();
            }

            Courses dbcourses = await _libraryService.UpdateCoursesAsync(courses);

            if (dbcourses == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{courses.CourseName} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var courses = await _libraryService.GetCoursesAsync(id);
            (bool status, string message) = await _libraryService.DeleteCoursesAsync(courses);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, courses);
        }
    }
}
