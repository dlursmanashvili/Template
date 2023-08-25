using Template.Api;
using Template.Infrastructure.DataBaseHelper;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContext");
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
//DI.DependecyResolver(builder.Services);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();



var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContext");
var services = builder.Services;

services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
DI.DependecyResolver(services);

// Add services to the container.
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); // This will apply any pending migrations
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();