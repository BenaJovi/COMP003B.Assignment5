using COMP003B.Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace COMP003B.Assignment5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private List<Student> _students = new List<Student>();
        public StudentsController() 
        {
            _students.Add(new Student { Id = 1, Name = "Student", MiddleName = "Number", LastName = "One" });
            _students.Add(new Student { Id = 2, Name = "Student", MiddleName = "Number", LastName = "Two" });
            _students.Add(new Student { Id = 3, Name = "Student", MiddleName = "Number", LastName = "Three"});
            _students.Add(new Student { Id = 4, Name = "Student", MiddleName = "Number", LastName = "Four" });
            _students.Add(new Student { Id = 5, Name = "Student", MiddleName = "Number", LastName = "Five" });

        }
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            return _students;
        }
        //Read
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student= _students.Find(s => s.Id==id);
            if (student==null)
            {
                return NotFound();
            }
            return student;
        }
        //Read
        [HttpPost]
        public ActionResult<Student> CreateStudent(Student student)
        {
            student.Id = _students.Max(s => s.Id) + 1;
            _students.Add(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id, student });
        }
        [HttpPut]
        public IActionResult UpdateStudent(int id, Student updatedStudent)
        {
            var student = _students.Find(s => s.Id == id);

            if (student== null)
            {
                return BadRequest();
            }
            student.Name= updatedStudent.Name;
            student.MiddleName= updatedStudent.MiddleName;
            student.LastName= updatedStudent.LastName;

            return NoContent();

        }
        //Delete
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var student= _students.Find(s=>s.Id==id);    
            
            if(student == null)
            {
                return NotFound();
            }
            _students.Remove(student);
            return NoContent();
        }
    }
}
