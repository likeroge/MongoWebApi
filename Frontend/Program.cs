using Frontend.Configurations;
using Frontend.Data;
using Frontend.Data.Context;
using Frontend.Repos;
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

//HttpClient
// builder.Services.AddHttpClient("MainHttpClient",client=> client.BaseAddress = new Uri("http://localhost:5010"));
builder.Services.AddScoped(serviceProvider => new HttpClient{BaseAddress = new Uri("http://localhost:5000")} );

//Database
builder.Services.AddSingleton<MongoDbContext>();

//Cors
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

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

string dbSettings = app.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>().ConnectionString;
Console.WriteLine(dbSettings);

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();