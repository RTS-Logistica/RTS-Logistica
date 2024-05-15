using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Application.Services;
using Infraestructure.Persistence;
using Infraestructure.Query;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AppDbContext>();

// Repositories
builder.Services.AddTransient<IBatchCardQuery, BatchCardQuery>();

// Services
builder.Services.AddTransient<IBatchCardService, BatchCardService>();

builder.Services.AddCors(Options =>
{
    Options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

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
