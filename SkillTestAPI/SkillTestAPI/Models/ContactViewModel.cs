using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTestAPI.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Tel { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
