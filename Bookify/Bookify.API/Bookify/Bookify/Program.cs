using AutoMapper;
using Bookify.Data;
using Bookify.Mapper;
using Bookify.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookifyDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookifyDbConnectionString")));

builder.Services.AddIdentityCore<User>(options => {
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<BookifyDbContext>();

builder.Services.AddAutoMapper(typeof(Program));

var mapperConfig = new MapperConfiguration(mc => {
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
