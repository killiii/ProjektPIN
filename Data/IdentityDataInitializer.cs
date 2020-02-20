using Microsoft.AspNetCore.Identity;
using PIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIN.Data
{
    public static class IdentityDataInitializer
    {
        public static void SeedData(UserManager<AppUser> userManager,RoleManager<MyIdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<AppUser> userManager)
        {
            if (userManager.FindByEmailAsync("guest@localhost").Result == null)
            {
                AppUser user = new AppUser();
                user.UserName = "guest@localhost";
                user.Email = "guest@localhost";
                user.FirstName = "Guest";
                user.LastName="Guest";
                user.Education = "VSS";
                user.Adress = "xxx";
                user.EmailConfirmed = true;
                

                IdentityResult result = userManager.CreateAsync
                (user, "Guest1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "NormalUser").Wait();
                }
            }


            if (userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                AppUser user = new AppUser();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";
                user.FirstName = "Admin";
                user.LastName = "Admin";
                user.Education = "VSS";
                user.Adress = "xxx";
                user.EmailConfirmed = true;
                
               
              

                IdentityResult result = userManager.CreateAsync(user, "Admin1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Administrator").Wait();
                }
            }

        }

        public static void SeedRoles(RoleManager<MyIdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                MyIdentityRole role = new MyIdentityRole();
                role.Name = "NormalUser";
                role.Description = "Perform normal operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                MyIdentityRole role = new MyIdentityRole();
                role.Name = "Administrator";
                role.Description = "Perform all the operations.";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}