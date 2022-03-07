using Microsoft.EntityFrameworkCore;
using MirayOrnek.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRepository, Repository>();
// IConfiguration configuration = app.Configuration;

var connectionString = builder.Configuration.GetConnectionString("ConnectionString");

builder.Services.AddDbContext<MirayDbContext>(cfg =>
{
    cfg.UseSqlServer(connectionString);
}
);


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
