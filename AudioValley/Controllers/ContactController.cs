using AudioValley.Business.Models;
using AudioValley.Business.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace AudioValley.Controllers
{
    public class ContactController : Controller
    {
        #region Dependency Injections
        private readonly AudioValleyContext _context;

        private readonly ContactOperations _contactOperations;

        public ContactController(AudioValleyContext context,ContactOperations contactOperations)
        {
            _context = context;
            _contactOperations = contactOperations;
        }
        #endregion
        #region Routes
        /// <summary>
        /// Get the list of contact'info including adress
        /// </summary>
        [HttpGet("contact")]
        [SwaggerResponse(200, "The list of contact", typeof(List<Contact>))]
        public async Task <List<Contact>> ListContact()
        {
            return await _contactOperations.FindAllAsync();

        }
        /// <summary>
        /// ADDING CONTACT
        /// </summary>
        [HttpPost("contact")]
        [SwaggerResponse(200, "ADDING CONTACT", typeof(List<Contact>))]
        public async Task<Contact> AddContact(Contact contact)
        {
            return await _contactOperations.AddContactAsync( contact);

        }
        /// <summary>
        /// DELETE ACONTACT
        /// </summary>
        [HttpDelete("contact")]
        [SwaggerResponse(200, "removing a contact", typeof(List<Contact>))]
        public bool Delete(Contact contact)
        {
            return  _contactOperations.RemoveContactAsync(contact);

        }
        #endregion
    }

   
}
