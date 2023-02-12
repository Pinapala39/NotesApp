using EnteryourWorld.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NotesApp.Controllers
{
    public class NoteApiController : Controller
    {
        private readonly List<Note> notes = new();
        private int currentid = 0;
     
        [HttpGet]
        [Route("api/GetListofNotes")]
        public ActionResult<List<Note>> GetAllNotes()
        {
            return notes;
        }

        [HttpGet]
        [Route("api/GetNotes/{id}")]
        public ActionResult<Note> GetNoteById(int id)
        {
            var note = notes.Find(n => n.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/CreateNotes")]
        public ActionResult<Note> CreateNewNotes(Note note)
        {
            note.Id = ++currentid;
            notes.Add(note);
            return CreatedAtAction(nameof(GetNoteById), new { id = note.Id }, note);
        }

        [HttpPut]
        [Route("api/UpdateNotes/{id}")]
        public ActionResult UpdateNote(int id, Note note)
        {
            var existingNote = notes.Find(n => n.Id == id);
            if (existingNote == null)
            {
                return NotFound();
            }
            existingNote.Title = note.Title;
            existingNote.Description = note.Description;
            return NoContent();
        }


        [HttpDelete]
        [Route("api/DeleteNote/{id}")]
        public ActionResult DeleteNote(int id)
        {
            var existingNote = notes.Find(n => n.Id == id);
            if (existingNote == null)
            {
                return NotFound();
            }
            notes.Remove(existingNote);
            return NoContent();
        }

      
        }
    }

