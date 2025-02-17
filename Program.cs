// using IdGenerator;
using TimeFourthe.Configurations;
using TimeFourthe.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// IdGeneratorClass IdGenerator = new IdGeneratorClass();
// MongoDB Settings
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<TimetableService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<PendingUserService>();

// Controllers
builder.Services.AddControllers();
var app = builder.Build();

// app.MapGet("/", () => IdGenerator.IdGenerator("student"));

app.UseCors("AllowAll");
app.MapControllers();
app.Run();