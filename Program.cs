using AppointmentBookingSystem.Application.Interfaces;
using AppointmentBookingSystem.Application.Services;
using AppointmentBookingSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();
//app.UseSwagger();
// ? Add Swagger Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "Appointment Booking API",
		Version = "v1",
		Description = "API for booking appointments with sales managers"
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	// ? Ensure Swagger is used only in Development
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Appointment Booking API v1");
		c.RoutePrefix = string.Empty; // This ensures Swagger UI is loaded directly at the root (i.e., index.html will open directly)
	});
}

app.UseSwaggerUI();
app.MapControllers();
app.Run();