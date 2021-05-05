using AudioValley.Business.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<Adress> GetByContacIdAsync(int contactId)
        {
            if (contactId <= 0)
                throw new ArgumentException(nameof(contactId));

            return _context.Adresses.Where(o => o.ContactId == contactId).ToList();
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
            List<SqlParameter> parms = new List<SqlParameter>
    {
        // Create parameter(s)    
         new SqlParameter { ParameterName = "@Password", Value = contact.Password },
         new SqlParameter { ParameterName = "@LastName", Value = contact.LastName },
          new SqlParameter { ParameterName = "@FirstName", Value = contact.FirstName},

          new SqlParameter { ParameterName = "@Email", Value = contact.Email },
          new SqlParameter { ParameterName = "@responseMessage", Value = "out" }



    };


           
            string sql = "EXEC dbo.addContact @Password ,@Email ,@LastName,@FirstName,@responseMessage";

  

            var result = _context.Contacts.FromSqlRaw<Contact>(sql, parms.ToArray());
            await _context.SaveChangesAsync();

            return contact;
        }
        public bool RemoveContactAsync(int contactID)
        {
            var Contact = _context.Contacts.Where(i => i.ContactId == contactID).FirstOrDefault();
            if (Contact.ContactId <= 0)
                throw new ArgumentNullException(nameof(Contact));

            _context.Remove(Contact);
            _context.SaveChanges(); 

            return true;
        }

        #endregion
    }
}
