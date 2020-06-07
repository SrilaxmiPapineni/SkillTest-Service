using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillTestAPI.Interfaces;
using SkillTestAPI.Models;

namespace SkillTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IContactRepository contactRepository;
        public ContactController(IContactRepository _contactRepository)
        {
            contactRepository = _contactRepository;
        }

      
        [HttpGet]
        [Route("get-contacts")]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                var contacts = await contactRepository.GetContacts();
                if (contacts == null)
                {
                    return NotFound();
                }

                return Ok(contacts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("get-contact")]
        public async Task<IActionResult> GetContact(int? contactId)
        {
            if (contactId == null)
            {
                return BadRequest();
            }

            try
            {
                var contact = await contactRepository.GetContact(contactId);

                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add-contact")]
        public async Task<IActionResult> AddContact([FromBody] Contact model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var contactId = await contactRepository.AddContact(model);
                    if (contactId > 0)
                    {
                        return Ok(contactId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("delete-contact")]
        public async Task<IActionResult> DeleteContact(int? contactId)
        {
            int result = 0;

            if (contactId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await contactRepository.DeleteContact(contactId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost]
        [Route("update-contact")]
        public async Task<IActionResult> Updatecontact([FromBody] Contact model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await contactRepository.UpdateContact(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
