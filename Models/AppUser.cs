using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UserApp.Models
{
    public enum Country {Poland, UK, Germany, France, Spain, Italy}
    public enum Gender {Male, Female, Nonbinary, Other}
    public class AppUser : IdentityUser
    {
        //public byte[] UserPhoto { get; set; }
        public Country Country { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public AppUser()
        {
            Messages = new HashSet<Message>();
            
        }
    }
}
