using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Negocio.Data;
using Negocio.Services;
using WebApi.Dto;

var builder = WebApplication.CreateBuilder(args);

//seguridad
var builderSeguridad = builder.Services.AddIdentityCore<UsuarioEntity>();
builderSeguridad = new IdentityBuilder(builderSeguridad.UserType, builderSeguridad.Services);
builderSeguridad.AddEntityFrameworkStores<SeguridadDbContext>();
builderSeguridad.AddSignInManager<SignInManager<UsuarioEntity>>();
builder.Services.AddAuthentication();

//Automapper
builder.Services.AddAutoMapper(typeof(MappingProfiles));

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<SeguridadDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("IdentitySeguridad")));
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

//Ejecuta el controlador error. 
app.UseStatusCodePagesWithReExecute("/error");
//app.UseStatusCodePagesWithReExecute("/error", "?code{0}"); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
