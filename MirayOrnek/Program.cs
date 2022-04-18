<<<<<<< Updated upstream
=======
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
>>>>>>> Stashed changes
using Microsoft.EntityFrameworkCore;
using MirayOrnek.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.

builder.Services.AddControllers();
<<<<<<< Updated upstream
=======
//builder.Services.AddMvc();
>>>>>>> Stashed changes
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API", Version = "v1" });
    x.ResolveConflictingActions(c => c.First());
}
  
    );
builder.Services.AddTransient<IRepository, Repository>();
<<<<<<< Updated upstream
=======
builder.Services.AddTransient<IBasketRepository, BasketRepository>();
builder.Services.AddTransient<ILoggers, LogWriter>();

>>>>>>> Stashed changes
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
    app.UseDeveloperExceptionPage();
    //app.UseSwagger(x=>
    //{
    //    x.RouteTemplate = "/swagger/v1/swagger.json";
    //});
    app.UseSwagger();
    app.UseSwaggerUI(x=>x.SwaggerEndpoint("./v1/swagger.json","API v1"));

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
