using BlazorSyncfusionCmr.Server.Data;
using BlazorSyncfusionCmr.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorSyncfusionCmr.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ContactsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts() 
        {
            return await this.dataContext.Contacts.Where(c => !c.IsDeleted).ToListAsync();        
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            var result = await this.dataContext.Contacts.FindAsync(id);

            if (result is null)
            {
                return NotFound("Contact not found");
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContacts(Contact contact)
        {
            this.dataContext.Contacts.Add(contact);
            await this.dataContext.SaveChangesAsync();

            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> UpdateContacts(int id, Contact contact)
        {
            var result = await this.dataContext.Contacts.FindAsync(id);

            if (result is null)
            {
                return NotFound("Contact not found");
            }

            result.FirstName = contact.FirstName;
            result.LastName = contact.LastName;
            result.NickName = contact.NickName;
            result.DateOfBirth = contact.DateOfBirth;
            result.Place = contact.Place;
            result.DateUpdated = DateTime.Now;

            await this.dataContext.SaveChangesAsync();

            return result;
        }
    }
}
