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
    public class AdressController
    {
        #region Dependency Injections
        private readonly AudioValleyContext _context;

        private readonly AdressOperations _adressOperations;

        public AdressController(AudioValleyContext context, AdressOperations adressOperations)
        {
            _context = context;
            _adressOperations = adressOperations;
        }
        #endregion
        #region Routes
        /// <summary>
        /// Get the list of contact'info including adress
        /// </summary>
        [HttpGet("adress")]
        [SwaggerResponse(200, "adding adress to a contact", typeof(List<Adress>))]
        public async Task<Adress> AddAdressToContact(Adress adress,Contact contact)
        {
            return await _adressOperations.AddAddressAsync(adress,contact);

        }
        #endregion
    }
}
