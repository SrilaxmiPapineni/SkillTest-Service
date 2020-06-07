using SkillTestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTestAPI.Interfaces
{
    public interface IContactRepository
    {
        Task<List<ContactViewModel>> GetContacts();

        Task<ContactViewModel> GetContact(int? id);

        Task<int> AddContact(Contact contact);

        Task<int> DeleteContact(int? contactId);

        Task UpdateContact(Contact contact);
    }
}
