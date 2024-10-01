using crudApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// MongoDb Connection
// Register MongoDbContext for DI
//builder.Services.AddSingleton<MongoDbContext>(sp =>
//{
//    var connectionString = builder.Configuration.GetConnectionString("MongoDBConnection");
//    var dbName = builder.Configuration.GetSection("MongoDbSettings:DatabaseName").Value;
//    return new MongoDbContext(connectionString, dbName);
//});

// PostgreSql Connection
builder.Services.AddDbContext<PostgreSqlDbContext>(e =>
    e.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlCon"))
);

builder.Services.AddCors(option => option.AddPolicy("AllowAllOrigins", builder =>
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
