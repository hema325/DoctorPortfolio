using Ibrahim.DoctorPortfolio.Data;
using Ibrahim.DoctorPortfolio.Extensions;
using Ibrahim.DoctorPortfolio.Extensions.DependencyInjection;
using Ibrahim.DoctorPortfolio.Handlers;
using Ibrahim.DoctorPortfolio.Services.Jwt;
using Ibrahim.DoctorPortfolio.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// orm
builder.Services
    .AddDbContext<ApplicationDbContext>(o => 
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// identity
builder.Services
    .AddIdentity<IdentityUser, IdentityRole>(o => o.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// services
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwagger()
    .AddExceptionHandler<GlobalExceptionHandler>()
    .AddProblemDetails()
    .AddAutoMapper(Assembly.GetExecutingAssembly())
    .AddHttpContextAccessor()
    .AddJWT(builder.Configuration)
    .AddMemoryCache();

// dependency injection
builder.Services
    .AddScoped<IJwtProvider, JwtProvider>()
    .AddScoped<ApplicationDbContextInitialiser>();

// configurations
builder.Services
    .ConfigureApiBehaviorOptions()
    .Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.SectionName))
    .Configure<DefaultUserSettings>(builder.Configuration.GetSection(DefaultUserSettings.SectionName))
    .Configure<CacheSettings>(builder.Configuration.GetSection(CacheSettings.SectionName));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.Services.InitialiseDbAsync();

app.Run();
