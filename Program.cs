using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using User.SDK.Services.UserServices;
//using System.Web.Http.Cors;
//using Newtonsoft.Json.Serialization;
//using System.Net.Http;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*var corsPolicy = "corsPolicy";
builder.Services.AddCors(option =>
{
    option.AddPolicy(corsPolicy, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});*/
builder.Services.AddScoped<DbContext>();
//builder.Services.AddScoped<IUserServices, UserServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseCors(corsPolicy);
}
else
{



    app.UseHttpsRedirection();

    app.UseAuthorization();
}

app.MapControllers();

app.Run();
