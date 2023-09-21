using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RendicionViaticos.Account;
using RendicionViaticos.Data;
using RendicionViaticos.Services.Ldap;
using RendicionViaticos.Services.Unit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", config => 
    {
        config.Cookie.Name = "User.Cookie";
        config.LoginPath = "/Account/Login";
    });

builder.Services.Configure<LdapConfig>(builder.Configuration.GetSection("Ldap"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddDbContext<ApplicationRendicionDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PerDiemStatementImarpeRedConnection")));
builder.Services.AddDbContext<ApplicationPerDiemStatementDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PerDiemStatementTestConnection")));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<AccountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
