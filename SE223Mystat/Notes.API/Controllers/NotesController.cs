using Microsoft.AspNetCore.Mvc;
using Notes.API.Data;
using Notes.API.Models;
using System.Net;

namespace Notes.API.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NotesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<List<Note>> GetNotes()
        {
            var result = NotesDataStore.Notes.ToList();

            if (result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<Note> GetNote([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest();

            var result = NotesDataStore.Notes.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult AddNote([FromBody] Note model)
        {
            if (model == null)
                return NotFound();

            model.Id = NotesDataStore.Notes.Max(x => x.Id) + 1;
            NotesDataStore.Notes.Add(model);

            return Ok(model);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<Note> UpdateNote([FromBody] Note model)
        {
            if (model == null)
                return BadRequest();

            var note = NotesDataStore.Notes.FirstOrDefault(x => x.Id == model.Id);

            if (note == null)
                return NotFound();

            note.Author = model.Author;
            note.Description = model.Description;
            note.Title = model.Title;

            return Ok(note);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<Note> DeleteNote([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest();

            var result = NotesDataStore.Notes.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return NotFound();

            NotesDataStore.Notes.Remove(result);
            return Ok(result);
        }

    }
}
