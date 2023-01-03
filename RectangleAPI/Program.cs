using Microsoft.AspNetCore.Mvc;
[assembly: ApiController]
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
        policy  =>
        {
            policy.WithOrigins("http://localhost:4200/");
        });
});

var app = builder.Build();

app.MapControllers();
app.UseCors("MyAllowSpecificOrigins");

app.Run("http://localhost:5131");