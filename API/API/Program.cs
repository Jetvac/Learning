using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();

// Add services to the container.
builder.Services.AddDbContext<LearningContext>(options =>
     options.UseSqlServer("Server =.\\SQLEXPRESS; Database = Learning; Trusted_Connection = True;"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc().AddRazorPagesOptions(options => {
    //Отключение защиты от CSFR
    options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
});

var app = builder.Build();

app.UseStaticFiles();

app.UseCors(builder => builder
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
