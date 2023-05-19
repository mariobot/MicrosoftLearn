using BlazorSyncfusionCmr.Client.Pages;
using BlazorSyncfusionCmr.Server.Data;
using BlazorSyncfusionCmr.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor.Diagram;

namespace BlazorSyncfusionCmr.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly DataContext dataContext;

        public NotesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetAllNotes()
        {
            return await dataContext.Notes
                .Include(n => n.Contact)
                .OrderByDescending(n => n.DateCreated)
                .ToListAsync();
        }

        [HttpGet("{contactId}")]
        public async Task<ActionResult<List<Note>>> GetNotesFromContact(int contactId)
        {
            return await dataContext.Notes
                .Where(x => x.ContactId == contactId)
                .OrderByDescending(n => n.DateCreated)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<List<Note>>> CreateNotes(Note note)
        {
            dataContext.Notes.Add(note);
            await dataContext.SaveChangesAsync();

            return await dataContext.Notes
                .Where(x => x.ContactId == note.ContactId)
                .OrderByDescending(n => n.DateCreated)
                .ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Note>>> DeleteNote(int id)
        {
            var dbNote = await dataContext.Notes.FindAsync(id);
            if (dbNote is null) 
            {
                return BadRequest("Note not found.");
            }

            this.dataContext.Notes.Remove(dbNote);
            await dataContext.SaveChangesAsync();

            return await dataContext.Notes
                .Where(x => x.ContactId == dbNote.ContactId)
                .OrderByDescending(n => n.DateCreated)
                .ToListAsync();
        }
    }
}
