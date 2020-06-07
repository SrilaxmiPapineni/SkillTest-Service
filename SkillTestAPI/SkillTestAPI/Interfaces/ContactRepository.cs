using Microsoft.EntityFrameworkCore;
using SkillTestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTestAPI.Interfaces
{
    public class ContactRepository : IContactRepository
    {
        MYDBContext db;
        public ContactRepository(MYDBContext _db)
        {
            db = _db;
        }

        public async Task<List<ContactViewModel>> GetContacts()
        {
            if (db != null)
            {
                return await (from p in db.Contact
                              select new ContactViewModel
                              {
                                  Id = p.Id,
                                  FirstName = p.FirstName,
                                  SurName = p.SurName,
                                  Tel = p.Tel,
                                  Cell = p.Cell,
                                  Email = p.Email,
                                  UpdatedDate = p.UpdatedDate
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<ContactViewModel> GetContact(int? id)
        {
            if (db != null)
            {
                return await ( from c in db.Contact
                              where c.Id == id
                              select new ContactViewModel
                              {
                                  Id = c.Id,
                                  FirstName = c.FirstName,
                                  SurName = c.SurName,
                                  Tel = c.Tel,
                                  Cell = c.Cell,
                                  Email = c.Email,
                                  UpdatedDate = c.UpdatedDate
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> AddContact(Contact contact)
        {
            if (db != null)
            {
                contact.UpdatedDate = DateTime.UtcNow;
                await db.Contact.AddAsync(contact);
                await db.SaveChangesAsync();

                return contact.Id;
            }

            return 0;
        }

        public async Task<int> DeleteContact(int? contactId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var post = await db.Contact.FirstOrDefaultAsync(x => x.Id == contactId);

                if (post != null)
                {
                    //Delete that post
                    db.Contact.Remove(post);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task UpdateContact(Contact contact)
        {
            if (db != null)
            {
                contact.UpdatedDate = DateTime.UtcNow;
                //Delete that post
                db.Contact.Update(contact);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
