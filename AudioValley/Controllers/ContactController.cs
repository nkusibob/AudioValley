using AudioValley.Business.Models;
using AudioValley.Business.Operations;
using AudioValley.ViewModel;
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
        public async Task <List<ContactInfo>> ListContact()
        {
            List<ContactInfo> contactInfo = new List<ContactInfo>();
            var contact= await _contactOperations.FindAllAsync();
            foreach (var item in contact)
            {
                contactInfo.Add(new ContactInfo
                {
                    Adresses = _contactOperations.GetByContacIdAsync(item.ContactId),
                    LastName = item.LastName,
                    FirstName = item.FirstName,
                    Email = item.Email,
                    ContactId = item.ContactId

                });

            }
            return contactInfo;

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
        /// DELETE A CONTACT
        /// </summary>
        [HttpDelete("contact")]
        [SwaggerResponse(200, "removing a contact", typeof(List<Contact>))]
        public bool Delete(int contactID)
        {

            return  _contactOperations.RemoveContactAsync(contactID);

        }
        #endregion
    }

   
}
