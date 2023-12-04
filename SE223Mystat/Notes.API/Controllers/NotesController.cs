using Microsoft.AspNetCore.Mvc;
using Notes.API.Data;
using Notes.API.Models;

namespace Notes.API.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NotesController : ControllerBase
    {
        [HttpGet]
        public List<Note> GetNotes()
        {
            var result = NotesDataStore.Notes.ToList();
            return result;
        }

        [HttpGet("{id:int}")]
        public Note GetNote([FromRoute] int id)
        {
            var result = NotesDataStore.Notes.FirstOrDefault(x => x.Id == id);
            return result;
        }

        [HttpPost]
        public void AddNote([FromBody] Note model)
        {
            //TODO გადააწყეთ ეს კოდი ისე რომ არ მჭირდებოდეს ID - ის ხელით შეყვანა, პროგრამა თავისით უნდა ხვდებოდეს რომელია ბოლო და ზრდიდეს Id  - ს ავტომატურად ყოველი ახალი ჩანაწერისთვის.
            NotesDataStore.Notes.Add(model);
        }

        [HttpPut]
        public void UpdateNote([FromBody] Note model)
        {
            var note = NotesDataStore.Notes.FirstOrDefault(x => x.Id == model.Id);

            if (note != null)
            {
                note.Author = model.Author;
                note.Description = model.Description;
                note.Title = model.Title;
            }
        }

        [HttpDelete("{id:int}")]
        public void DeleteNote([FromRoute] int id)
        {
            var result = NotesDataStore.Notes.FirstOrDefault(x => x.Id == id);
            NotesDataStore.Notes.Remove(result);
        }

    }
}
