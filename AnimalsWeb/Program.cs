using AnimalsWeb.Data;
using AnimalsWeb.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<AnimalContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;

}).AddEntityFrameworkStores<AnimalContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();

    var userMngr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleMngr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    //ctx.Database.EnsureDeleted(); 
    //ctx.Database.EnsureCreated();

    var adminRole = new IdentityRole("Admin");
    if (!ctx.Roles.Any())
    {
        // Create role
        roleMngr.CreateAsync(adminRole).GetAwaiter().GetResult();
    }

    if (!ctx.Users.Any(u => u.UserName == "Admin"))
    {
        var adminUser = new IdentityUser
        {
            UserName = "Admin",
            Email = "admin@test.com",
        };
        var result = userMngr.CreateAsync(adminUser, "123456aA").GetAwaiter().GetResult();
        // add role to user
        userMngr.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
    }

}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Index");
}

app.UseRouting();
app.UseAuthentication();
app.UseStaticFiles();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run(async (content) =>
{
    await content.Response.WriteAsync("Sorry, cant serve your request");
});

app.Run();