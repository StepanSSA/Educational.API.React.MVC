using Educational.Identity;
using Educational.Identity.Data;
using Educational.Identity.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetValue<string>("DbConnection");

builder.Services.AddDbContext<IdentityDataBaseContext>(options =>
{
    options.UseSqlite(connectionString);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});


builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 4;
    options.User = new UserOptions()
    {
        RequireUniqueEmail = true,
        AllowedUserNameCharacters = AllowedCharacters.Characters
    };
}).AddEntityFrameworkStores<IdentityDataBaseContext>()
  .AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<AppUser>()
    .AddInMemoryApiResources(Configuration.apiResources)
    .AddInMemoryApiScopes(Configuration.apiScopes)
    .AddInMemoryIdentityResources(Configuration.identityResources)
    .AddInMemoryClients(Configuration.clients)
    .AddDeveloperSigningCredential();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "Educ.Identity.Cookie";
    config.LoginPath = "/Auth/Login";
    config.LogoutPath = "/Auth/Logout";
});

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseIdentityServer();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    DataHelper.Seed(scope.ServiceProvider);
}

app.Run();
