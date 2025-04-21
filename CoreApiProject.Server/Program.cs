using CoreApiProject.Server.DataService;
using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;
using CoreApiProject.Server.DataService;
using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;
using CoreApiProject.Server.Controllers;
using CoreApiProject.Server.DataService;
using CoreApiProject.Server.Habib.HabibInterFace;
using CoreApiProject.Server.Habib.HabibService;
using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;

using CoreApiProject.Server.DataService;
using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });
// Add services to the container.
builder.Services.AddDbContext<MyDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnectionString")));

// Swagger & DB
// Add distributed cache FIRST (required for session)
builder.Services.AddDistributedMemoryCache(); // <-- THIS IS THE CRUCIAL MISSING LINE

// Session configuration
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
	options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAllOrigins",
		builder =>
		{
			builder.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader();
		});
});

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnectionString")));

// Swagger & DB







builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});







builder.Services.AddHttpContextAccessor();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDataservaceUser, DataserviceUsercs>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnectionString")));

builder.Services.AddScoped<IData, DataS>();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnectionString")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Services
builder.Services.AddScoped<IPrivateBookingService, PrivateBookingService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPrivateRoomService, PrivateRoomService>();
builder.Services.AddScoped<IBookingService, BookingService>();

//builder.Services.AddScoped<IBookingService, BookingService>();


builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnectionString")));

// Services
builder.Services.AddScoped<IPrivateBookingService, PrivateBookingService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPrivateRoomService, PrivateRoomService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

//builder.Services.AddScoped<IBookingService, BookingService>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseCors("AllowAllOrigins");


app.UseDefaultFiles();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAllOrigins");

// IMPORTANT MIDDLEWARE ORDER
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();      // 1. Routing first
app.UseSession();      // 2. Then session
app.UseAuthorization(); // 3. Then authorization
app.UseCors("AllowAllOrigins"); 

app.UseCors("AllowAllOrigins");

app.UseSession();
app.UseAuthorization();
app.UseCors("AllowAllOrigins");

app.MapControllers();
app.MapFallbackToFile("/index.html");
//app.MapFallbackToFile("/index.html");


app.Run();