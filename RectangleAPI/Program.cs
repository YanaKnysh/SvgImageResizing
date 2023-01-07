using RectangleAPI.Interfaces;
using RectangleAPI.Services;

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
builder.Services.AddSingleton<IBackgroundProcessor, BackgroundProcessor>();
builder.Services.AddSingleton<IWriter, FileWriter>();

var app = builder.Build();

app.MapControllers();
app.UseCors("MyAllowSpecificOrigins");

app.Run("http://localhost:5131");