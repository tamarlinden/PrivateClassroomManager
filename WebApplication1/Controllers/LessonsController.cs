using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonsController : ControllerBase
    {
        private static List<Lesson> lessons = new List<Lesson>();
        private static int nextId = 1;

        // GET /lessons - שליפת רשימת שיעורים
        [HttpGet]
        public ActionResult<List<Lesson>> GetAll()
        {
            return Ok(lessons);
        }

        // GET /lessons/{id} - שליפת שיעור לפי מזהה
        [HttpGet("{id}")]
        public ActionResult<Lesson> GetById(int id)
        {
            var lesson = lessons.FirstOrDefault(l => l.Id == id);
            if (lesson == null)
                return NotFound();
            return Ok(lesson);
        }

        // POST /lessons - הוספת שיעור חדש
        [HttpPost]
        public ActionResult<Lesson> AddLesson(Lesson newLesson)
        {
            newLesson.Id = nextId++;
            lessons.Add(newLesson);
            return CreatedAtAction(nameof(GetById), new { id = newLesson.Id }, newLesson);
        }

        // PUT /lessons/{id} - עדכון שיעור
        [HttpPut("{id}")]
        public ActionResult UpdateLesson(int id, Lesson updatedLesson)
        {
            var lesson = lessons.FirstOrDefault(l => l.Id == id);
            if (lesson == null)
                return NotFound();

            lesson.StudentId = updatedLesson.StudentId;
            lesson.TeacherId = updatedLesson.TeacherId;
            lesson.Date = updatedLesson.Date;
            lesson.Topic = updatedLesson.Topic;
            lesson.Status = updatedLesson.Status;

            return NoContent();
        }

        // DELETE /lessons/{id} - מחיקת שיעור
        [HttpDelete("{id}")]
        public ActionResult DeleteLesson(int id)
        {
            var lesson = lessons.FirstOrDefault(l => l.Id == id);
            if (lesson == null)
                return NotFound();

            lessons.Remove(lesson);
            return NoContent();
        }

        // PUT /lessons/{id}/status - שינוי סטטוס שיעור
        [HttpPut("{id}/status")]
        public ActionResult UpdateStatus(int id, [FromBody] string newStatus)
        {
            var lesson = lessons.FirstOrDefault(l => l.Id == id);
            if (lesson == null)
                return NotFound();

            lesson.Status = newStatus;
            return NoContent();
        }
    }
}
