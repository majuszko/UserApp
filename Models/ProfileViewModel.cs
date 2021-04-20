using System;
using System.ComponentModel.DataAnnotations;

namespace UserApp.Models
{
    public class ProfileViewModel
    {
        [Display(Name = "UserPhoto")]
        public byte[] UserPhoto { get; set; }

        public string Name
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
        public Country Country { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }


        public ProfileViewModel()
        {
        }
    }
}
