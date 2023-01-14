using Microsoft.EntityFrameworkCore;
using UserClientApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Nadanie dostêpu do localhosta u¿ywanego przez angulara
builder.Services.AddCors(options => options.AddPolicy(name: "UserClientOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    }));

// Po³¹czenie z baz¹ danych
builder.Services.AddDbContext<DataContext>(
        option => option
        .UseSqlServer(builder.Configuration.GetConnectionString("MyAppConnectionString"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("UserClientOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
