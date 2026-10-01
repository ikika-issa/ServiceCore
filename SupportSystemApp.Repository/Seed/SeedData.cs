using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SupportSystemApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Repository.Seed
{
    public class SeedData
    {
        public static async Task SeedSites()
        {
             
        }

        public static async Task SeedSupportGroups()
        {

        }

        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            
        }

        public static async Task SeedTicketType(IServiceProvider serviceProvider)
        {

        }

        public static async Task SeedTicketStatus (IServiceProvider serviceProvider)
        {
            
        }

        public static async Task SeedTicketPriority(IServiceProvider serviceProvider)
        {

        }

        public static async Task SeedTicketMode (IServiceProvider serviceProvider)
        {

        }

        public static async Task SeedSystemsCAB(IServiceProvider serviceProvider)
        {

        }

        public static async Task SeedTicketImpact(IServiceProvider serviceProvider)
        {

        }


        public static async Task SeedTicketUrgency(IServiceProvider serviceProvider)
        {

        }

        public static async Task SeedServiceCategory(IServiceProvider serviceProvider)
        {

        }

        
        public static async Task SeedAdmin(IServiceProvider serviceProvider)
        {
            var userManager =
                serviceProvider.GetRequiredService<UserManager<SupportSystemAppUser>>();

            var adminEmail = "global.admin@servicecore.com";

            var admin = await userManager.FindByEmailAsync(adminEmail);

            if (admin == null)
            {
                var newAdmin = new SupportSystemAppUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Main",
                    LastName = "Admin",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(newAdmin, "Admin123!");

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(", ",
                        result.Errors.Select(x => x.Description)));
                }
                //await userManager.AddToRoleAsync(newAdmin, "Global_Admin");

            }
            else if (!admin.EmailConfirmed)
            {
                admin.EmailConfirmed = true;
                await userManager.UpdateAsync(admin);
            }   
        }
    }
}
