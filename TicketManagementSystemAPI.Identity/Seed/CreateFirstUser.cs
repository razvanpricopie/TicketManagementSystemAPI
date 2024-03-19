using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Identity.Models;

namespace TicketManagementSystemAPI.Identity.Seed
{
    public static class UserCreator
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                UserName = "admin@admin.com",
                EmailConfirmed = true,
            };

            if (await userManager.FindByEmailAsync(applicationUser.Email) == null)
            {
                await userManager.CreateAsync(applicationUser, "Pa$$word123");
                await userManager.AddToRoleAsync(applicationUser, "Admin");
            }
        }
    }
}
