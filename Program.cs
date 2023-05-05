using DailyNote.data;
using DailyNote.DataAccess.Category;
using DailyNote.DataAccess.Note;
using DailyNote.DataAccess.User;
using DailyNote.Filters;
using DailyNote.Services.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Services.AddControllersWithViews( options =>
{
    options.Filters.Add<AuthFilter>();
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();


builder.Services.AddDbContext<ApplicationDBContext>( options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

/*
 * registration repository services
 */
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<NoteRepository>();


/*
 *  registration business logic services
 */
builder.Services.AddScoped<IUserService,UserService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCookiePolicy();
app.UseAuthentication();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name : "default",
    pattern : "{controller=User}/{action=Login}/{id?}"
);

app.Run();
