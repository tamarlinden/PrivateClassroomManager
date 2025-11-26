using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : ControllerBase
    {
        private static List<Teacher> teachers = new List<Teacher>();
        private static int nextId = 1;

        // GET /teachers - שליפת רשימת מורים
        [HttpGet]
        public ActionResult<List<Teacher>> GetAll()
        {
            return Ok(teachers);
        }

        // GET /teachers/{id} - שליפת מורה לפי מזהה
        [HttpGet("{id}")]
        public ActionResult<Teacher> GetById(int id)
        {
            var teacher = teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
                return NotFound();
            return Ok(teacher);
        }

        // POST /teachers - הוספת מורה חדש
        [HttpPost]
        public ActionResult<Teacher> AddTeacher(Teacher newTeacher)
        {
            newTeacher.Id = nextId++;
            teachers.Add(newTeacher);
            return CreatedAtAction(nameof(GetById), new { id = newTeacher.Id }, newTeacher);
        }

        // PUT /teachers/{id} - עדכון מורה
        [HttpPut("{id}")]
        public ActionResult UpdateTeacher(int id, Teacher updatedTeacher)
        {
            var teacher = teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
                return NotFound();

            teacher.FirstName = updatedTeacher.FirstName;
            teacher.LastName = updatedTeacher.LastName;
            teacher.Subjects = updatedTeacher.Subjects;
            teacher.Availability = updatedTeacher.Availability;
            teacher.Status = updatedTeacher.Status;

            return NoContent();
        }

        // DELETE /teachers/{id} - מחיקת מורה
        [HttpDelete("{id}")]
        public ActionResult DeleteTeacher(int id)
        {
            var teacher = teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
                return NotFound();

            teachers.Remove(teacher);
            return NoContent();
        }

        // PUT /teachers/{id}/availability - עדכון זמינות מורה
        [HttpPut("{id}/availability")]
        public ActionResult UpdateAvailability(int id, [FromBody] string newAvailability)
        {
            var teacher = teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
                return NotFound();

            teacher.Availability = newAvailability;
            return NoContent();
        }
    }
}
