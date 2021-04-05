﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace UserApp.Models
{
    public class RoleEdit
    {
        
        public IdentityRole Role { get; set; }
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<AppUser> NonMembers { get; set; }
        
        public RoleEdit()
        {
        }
    }
}
