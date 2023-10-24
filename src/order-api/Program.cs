using Microsoft.EntityFrameworkCore;
using OrderAPI.Database;
using OrderAPI.Repositories;
using OrderAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
var configuration = new ConfigurationBuilder()
                                .AddJsonFile($"appsettings.json");

var config = configuration.Build();
var connectionString = config.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<OrderDbContext>(options =>
            options.UseSqlServer(connectionString));
// Add services to the container.

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IOrdersRepository, OrdersSqlRepository>();
builder.Services.AddTransient<IOrdersService, OrdersService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
