using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using UserApp.Models;

namespace UserApp.TagHelper
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("td", Attributes = "i-role")]
    public class RoleUsersTH : ITagHelper
    {
        private UserManager<AppUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public RoleUsersTH(UserManager<AppUser> usermgr, RoleManager<IdentityRole> rolemgr)
        {
            userManager = usermgr;
            roleManager = rolemgr;
        }

        [HtmlAttributeName("i-role")]
        public string Role { get; set; }

        int ITagHelperComponent.Order => throw new NotImplementedException();

        //public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        //{}

        void ITagHelperComponent.Init(TagHelperContext context)
        {
            throw new NotImplementedException();
        }

        async Task ITagHelperComponent.ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
                List<string> names = new List<string>();
                IdentityRole role = await roleManager.FindByIdAsync(Role);
                if (role != null)
                {
                    foreach (var user in userManager.Users)
                    {
                        if (user != null && await userManager.IsInRoleAsync(user, role.Name))
                            names.Add(user.UserName);
                    }
                }
                output.Content.SetContent(names.Count == 0 ? "No Users" : string.Join(", ", names));
            
        }
    }
}
