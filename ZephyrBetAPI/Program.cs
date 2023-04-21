//Could make use of global usings

using Microsoft.EntityFrameworkCore;
using ZephyrBetAPI;
using ZephyrBetAPI.Data;
using ZephyrBetAPI.Services.AuthService;
using ZephyrBetAPI.Services.PlayerService;
using ZephyrBetAPI.Services.UserService;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
//Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IAuthService, AuthService>();

//Stripe
builder.Services.AddStripeInfrastructure(builder.Configuration);

//Database
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySQL(connectionString));
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