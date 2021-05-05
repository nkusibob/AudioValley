using AudioValley.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AudioValley.Business.Operations
{
    public  class ContactOperations
    {
        #region Dependency Injections

        private readonly AudioValleyContext _context;

        public ContactOperations (AudioValleyContext context)
        {
            _context = context;
        }

        #endregion

        // ============================================================================================================

        #region Get/Search/List
        public async Task<List<Contact>> FindAllAsync()
        {
            return await _context.Contacts
                .Include(s => s.Adresses)
                .ToListAsync();
        }

        #endregion

        // ============================================================================================================

        #region Create/UpdateAsync

        /// <summary>
        /// Create a new contact
        /// </summary>
        public async Task<Contact> AddContactAsync(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return contact;
        }
        public bool RemoveContactAsync(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            _context.Contacts.Remove(contact);
             _context.SaveChangesAsync();

            return true;
        }

        #endregion
    }
}
