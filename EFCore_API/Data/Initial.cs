using EFCore_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EFCore_API.Data
{
    public class Initial
    {
        private readonly ModelBuilder _builder;
        public Initial(ModelBuilder builder)
        {
            _builder = builder;
        }
        public void Seed()
        {
            _builder.Entity<Students>(a =>
            {
                a.HasData(new Students
                {
                    StudentId = 1,
                    Name = "J.K. Rowling"

                });

                a.HasData(new Students
                {
                    StudentId = 2,
                    Name = "Walter Isaacson"

                });
                a.HasData(new Students
                {
                    StudentId = 3,
                    Name = " Isaacson"
                });
            });

            _builder.Entity<Courses>(b =>
            {
                b.HasData(new Courses
                {
                    CourseId = 1,
                    CourseName = "Harry Potter and the Sorcerer's Stone",
                    Description = "Harry Potter's life is miserable. His parents are dead and he's stuck with his heartless relatives, who force him to live in a tiny closet under the stairs."

                });
                b.HasData(new Courses
                {
                    CourseId = 2,
                    CourseName = "Harry Potter and the Chamber of Secrets",
                    Description = "Ever since Harry Potter had come home for the summer, the Dursleys had been so mean and hideous that all Harry wanted was to get back to the Hogwarts School for Witchcraft and Wizardry. "

                });
                b.HasData(new Courses
                {
                    CourseId = 3,
                    CourseName = "Steve Jobs",
                    Description = "Walter Isaacson’s “enthralling” (The New Yorker) worldwide bestselling biography of Apple cofounder Steve Jobs."

                });
            });
            _builder.Entity<StudentCourse>(c =>
            {
                c.HasData(new StudentCourse
                {
                    StudentId = 1,
                    CourseId = 2

                });
                c.HasData(new StudentCourse
                {
                    StudentId = 2,
                    CourseId = 3

                });
                c.HasData(new StudentCourse
                {
                    StudentId = 1,
                    CourseId = 3

                });
            }
            );

        }
    
    }
}
