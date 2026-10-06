using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SupportSystemApp.Domain.Identity;
using SupportSystemApp.Repository;
using SupportSystemApp.Repository.Seed;
using SupportSystemApp.Service.Implementation;
using SupportSystemApp.Service.Interface;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();

//IDENTITY
builder.Services
    .AddDefaultIdentity<SupportSystemAppUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddTransient<INoteService, NoteService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ISubcategoryService, SubcategoryService>();
builder.Services.AddTransient<ITicketExportService, TicketExportService>();
builder.Services.AddTransient<ISiteService, SiteService>();
builder.Services.AddTransient<ICategoryItemService, CategoryItemService>();
builder.Services.AddTransient<ISupportGroupService, SupportGroupService>();
builder.Services.AddTransient<IAttachmentService, AttachmentService>();
builder.Services.AddTransient<ITicketTaskService, TicketTaskService>();
builder.Services.AddTransient<IPriorityService, PriorityService>();
builder.Services.AddTransient<IStatusService, StatusService>();
builder.Services.AddTransient<ITicketModeService, TicketModeService>();
builder.Services.AddTransient<IService_CategoryService, Service_CategoryService>();
builder.Services.AddTransient<ITicketTypeService, TicketTypeService>();
builder.Services.AddTransient<IImpactService, ImpactService>();
builder.Services.AddTransient<IUrgencyService, UrgencyService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await SeedData.SeedRoles(services);
    await SeedData.SeedAdmin(services);

    await SeedData.SeedSupportGroups(services);
    await SeedData.SeedSites(services);
    await SeedData.SeedSystemsCAB(services);
    await SeedData.SeedServiceCategory(services);
    await SeedData.SeedTicketMode(services);
    await SeedData.SeedTicketPriority(services);
    await SeedData.SeedTicketStatus(services);
    await SeedData.SeedTicketType(services);
    await SeedData.SeedTicketUrgency(services);
    await SeedData.SeedImpact(services);
    await SeedData.SeedCategories(services);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
