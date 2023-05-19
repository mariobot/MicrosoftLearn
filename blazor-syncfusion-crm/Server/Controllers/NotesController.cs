using BlazorSyncfusionCmr.Server.Data;
using BlazorSyncfusionCmr.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
