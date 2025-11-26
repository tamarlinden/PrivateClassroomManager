using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>();
        private static int nextId = 1;

        // GET /students - שליפת רשימת תלמידים
        [HttpGet]
        public ActionResult<List<Student>> GetAll()
        {
            return Ok(students);
        }

        // GET /students/{id} - שליפת תלמיד לפי מזהה
        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        // POST /students - הוספת תלמיד חדש
        [HttpPost]
        public ActionResult<Student> AddStudent(Student newStudent)
        {
            newStudent.Id = nextId++;
            students.Add(newStudent);
            return CreatedAtAction(nameof(GetById), new { id = newStudent.Id }, newStudent);
        }

        // PUT /students/{id} - עדכון תלמיד
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.Age = updatedStudent.Age;
            student.StudyField = updatedStudent.StudyField;
            student.Level = updatedStudent.Level;
            student.TeacherId = updatedStudent.TeacherId;

            return NoContent();
        }

        // DELETE /students/{id} - מחיקת תלמיד
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            students.Remove(student);
            return NoContent();
        }

        // PUT /students/{id}/level - עדכון רמת קושי
        [HttpPut("{id}/level")]
        public ActionResult UpdateLevel(int id, [FromBody] StudentLevelUpdate request)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            student.Level = request.NewLevel;
            return NoContent();
        }
    }
}
