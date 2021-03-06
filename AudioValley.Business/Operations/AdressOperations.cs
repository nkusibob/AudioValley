using AudioValley.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioValley.Business.Operations
{
    public class AdressOperations
    {
        #region Dependency Injections

        private readonly AudioValleyContext _context;

        public AdressOperations(AudioValleyContext context)
        {
            _context = context;
        }

        #endregion

        // ============================================================================================================

        #region Get/Search/List
      
        #endregion

        // ============================================================================================================

        #region Create/UpdateAsync

        /// <summary>
        /// Create a new address
        /// </summary>
        public async Task<Adress> AddAddressAsync(Adress address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));
           

            _context.Adresses.Add(address);
            await _context.SaveChangesAsync();

            return address;
        }

        #endregion
    }
}
