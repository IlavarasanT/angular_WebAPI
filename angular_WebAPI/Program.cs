using angular_WebAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


//db connection for my personal user table 
//builder.Services.AddDbContext<ApiDBContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnectionStrings")));

//db connection for angular project
builder.Services.AddDbContext<ApiDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnectionStrings")));

//enable cors policy for hitting api from different source
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});


var app = builder.Build();

app.UseCors(x => x
       .SetIsOriginAllowed(origin => true)
       .AllowAnyMethod()
       .AllowAnyHeader()
       .AllowCredentials());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


