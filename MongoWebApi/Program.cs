using MongoWebApi.Configurations;
using MongoWebApi.Data.Context;
using MongoWebApi.Repos;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error()
    .Enrich.FromLogContext()
    .WriteTo.File(new Serilog.Formatting.Json.JsonFormatter(), "Logs/myapp.json", rollingInterval: RollingInterval.Day)
    .CreateLogger();


// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddSingleton<MongoDbContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

//Services
builder.Services.AddScoped<UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }
    
string dbSettings = app.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>().ConnectionString;
Console.WriteLine(dbSettings);

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();