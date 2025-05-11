using Microsoft.AspNetCore.Mvc;
using SimpleNotes.Api.Interfaces;
using SimpleNotes.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleNotes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService) { 

            _noteService = noteService;
        }
        // GET: api/<NoteController>
        [HttpGet]
        public IActionResult GetAll() => Ok(_noteService.GetAll());

        // GET api/<NoteController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var note = _noteService.GetById(id);
            return note is null ? NotFound() : Ok(note);
        }

        // POST api/<NoteController>
        [HttpPost]
        public IActionResult Create(Note note)
        {
            var createdNote = _noteService.Add(note);
            return CreatedAtAction(nameof(Get), new { id = createdNote.Id }, createdNote);
        }

        // PUT api/<NoteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Note note)
        {
            _noteService.Update(note);
            return NoContent();
        }

        // DELETE api/<NoteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _noteService.Delete(id);
            return NoContent();
        }
    }
}
