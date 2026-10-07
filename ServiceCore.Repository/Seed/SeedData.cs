using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Domain.Domain_Models;
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
        public static async Task SeedSites(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Sites.Any())
            {
                var sites = new List<Site>
                {
                    new Site
                    {
                        Name = "Not Specified",
                        Location = "Not Specified"
                    },
                    new Site
                    {
                        Name = "Skopje",
                        Location = "Macedonia"
                    },
                    new Site
                    {
                        Name = "Stokholm",
                        Location = "Sweden"
                    },
                    new Site
                    {
                        Name = "London",
                        Location = "United Kingdom"
                    },
                    new Site
                    {
                        Name = "Toronto",
                        Location = "Canada"
                    },
                    new Site
                    {
                        Name = "Home Based",
                        Location = "Home Based"
                    }
                };

                await context.Sites.AddRangeAsync(sites);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedImpact (IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            if (!context.Impacts.Any())
            {
                var impacts = new List<Impact>
                {
                    new Impact
                    {
                        Name = "Not Specified"
                    },
                    new Impact
                    {
                        Name = "Low"
                    },
                    new Impact
                    {
                        Name = "Medium"
                    },
                    new Impact
                    {
                        Name = "High"
                    }
                };
                await context.Impacts.AddRangeAsync(impacts);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedSupportGroups(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.SupportGroups.Any())
            {
                var supportGroups = new List<SupportGroup>
                {
                    new SupportGroup
                    {
                        Name = "Not Specified"
                    },
                    new SupportGroup
                    {
                        Name = "Internal support"
                    },
                    new SupportGroup
                    {
                        Name = "Infrastructure"
                    },
                    new SupportGroup
                    {
                        Name = "R&D Systems"
                    },
                    new SupportGroup
                    {
                        Name = "Systems"
                    },
                    new SupportGroup
                    {
                        Name = "Office support"
                    },
                    new SupportGroup
                    {
                        Name = "SecOps"
                    }
                };

                await context.SupportGroups.AddRangeAsync(supportGroups);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles =
            {
                "Global Admin",
                "Admin",
                "Guest User",
                "Technitian"
            };

            foreach(var roleName in roles)
            {
                if(!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        public static async Task SeedCategories(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category
                    {
                        Name = "Not specified"
                    }
                };
                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedTicketType(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.TicketTypes.Any())
            {
                var types = new List<TicketType>
                {
                    new TicketType
                    {
                        Name = "Not Specified"
                    },
                    new TicketType
                    {
                        Name = "Automated Request"
                    },
                    new TicketType
                    {
                        Name = "Information Request"
                    },
                    new TicketType
                    {
                        Name = "Service Request"
                    },
                    new TicketType
                    {
                        Name = "Incident"
                    },
                    new TicketType
                    {
                        Name = "Enhancement"
                    }
                };

                await context.TicketTypes.AddRangeAsync(types);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedTicketStatus (IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if(!context.TicketStatuses.Any())
            {
                var statuses = new List<TicketStatus>
                {
                    new TicketStatus
                    {
                        Name = "Open"
                    },
                    new TicketStatus
                    {
                        Name = "In Progress"
                    },
                    new TicketStatus
                    {
                        Name = "On Hold"
                    },
                    new TicketStatus
                    {
                        Name = "Resolved"
                    },
                    new TicketStatus
                    {
                        Name = "Closed"
                    },
                    new TicketStatus
                    {
                        Name = "Pending Investigation"
                    },
                    new TicketStatus
                    {
                        Name = "Assigned"
                    },
                    new TicketStatus
                    {
                        Name = "Monitoring"
                    }
                };

                await context.TicketStatuses.AddRangeAsync(statuses);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedTicketPriority(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.TicketPriorities.Any())
            {
                var priorities = new List<TicketPriority>
                {
                    new TicketPriority
                    {
                        Name = "Not Specified"
                    },
                    new TicketPriority
                    {
                        Name = "Low"
                    },
                    new TicketPriority
                    {
                        Name = "Medium"
                    },
                    new TicketPriority
                    {
                        Name = "High"
                    }
                };

                await context.TicketPriorities.AddRangeAsync(priorities);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedTicketMode (IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.TicketModes.Any())
            {
                var modes = new List<TicketMode>
                {
                    new TicketMode
                    {
                        Name = "Not Specified"
                    },
                    new TicketMode
                    {
                        Name = "Chat"
                    },
                    new TicketMode
                    {
                        Name = "E-mail"
                    },
                    new TicketMode
                    {
                        Name = "Maintenance"
                    },
                    new TicketMode
                    {
                        Name = "Phone call"
                    },
                    new TicketMode
                    {
                        Name = "Web Form"
                    }
                };

                await context.TicketModes.AddRangeAsync(modes);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedSystemsCAB(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.SystemsCABs.Any())
            {
                var systemsCAB = new List<SystemsCAB>
                {
                    new SystemsCAB
                    {
                        Name = "Not Required"
                    },
                    new SystemsCAB
                    {
                        Name = "Required"
                    },
                    new SystemsCAB
                    {
                        Name = "Pending review"
                    }
                };
                await context.SystemsCABs.AddRangeAsync(systemsCAB);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedTicketUrgency(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if(!context.Urgencies.Any())
            {
                var urgencies = new List<Urgency>
                {
                    new Urgency
                    {
                        Name = "Not Specified"
                    },
                    new Urgency
                    {
                        Name = "Low"
                    },
                    new Urgency
                    {
                        Name = "Medium"
                    },
                    new Urgency
                    {
                        Name = "High"
                    }
                };

                await context.Urgencies.AddRangeAsync(urgencies);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedServiceCategory(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if(!context.ServiceCategories.Any())
            {
                var serviceCategories = new List<Service_Category>
                {
                    new Service_Category
                    {
                        Name = "Not Specified"
                    },
                    new Service_Category
                    {
                        Name = "Hardware"
                    },
                    new Service_Category
                    {
                        Name = "Facilities"
                    },
                    new Service_Category
                    {
                        Name = "Network"
                    },
                    new Service_Category
                    {
                        Name = "Security"
                    },
                    new Service_Category
                    {
                        Name = "Application Support"
                    }
                };
                await context.ServiceCategories.AddRangeAsync(serviceCategories);
                await context.SaveChangesAsync();
            }
        }


        public static async Task SeedSubcategory(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            var notSpecifiedCategory = await context.Categories
                .FirstOrDefaultAsync(c => c.Name == "Not Specified");

            if (notSpecifiedCategory == null)
            {
                throw new Exception("Not Specified category must be seeded first.");
            }

            if (!await context.SubCategories
                .AnyAsync(s => s.Name == "Not Specified"))
            {
                var subcategory = new Subcategory
                {
                    Name = "Not Specified",
                    CategoryId = notSpecifiedCategory.Id
                };

                context.SubCategories.Add(subcategory);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedCategoryItems(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            var notSpecifiedSubcategory = 
                await context.SubCategories.FirstOrDefaultAsync(c => c.Name == "Not Specified");


            if (notSpecifiedSubcategory == null)
            {
                throw new Exception("No subcategories seeded");
            }

            if (!await context.CategoryItems.
                AnyAsync(s => s.Name == "Not Specified"))
            {
                var categoryItem = new CategoryItem
                {
                    Name = "Not Specified",
                    SubcategoryId = notSpecifiedSubcategory.Id
                };

                context.CategoryItems.Add(categoryItem);
                await context.SaveChangesAsync();
            }
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

                await userManager.AddToRoleAsync(newAdmin, "Global Admin");
            }
            else if (!admin.EmailConfirmed)
            {
                admin.EmailConfirmed = true;
                await userManager.UpdateAsync(admin);
            }   
        }
    }
}
