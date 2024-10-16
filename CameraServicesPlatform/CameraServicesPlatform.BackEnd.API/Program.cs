using CameraServicesPlatform.BackEnd.API.Installers;
using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using CameraServicesPlatform.BackEnd.Data;
using CameraServicesPlatform.BackEnd.Infrastructure.ServerHub;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// CORS policy
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(p => p.AddPolicy(MyAllowSpecificOrigins, builder =>
{
    builder.WithOrigins("http://localhost:5173", "http://localhost:5174", "http://localhost:5175", "http://localhost:5275", "https://cameraserviceplatform.firebaseapp.com/__/auth/handler?apiKey=AIzaSyA2cV2sxqM4INpHxDLdNnDVTAnIupgJTTU&appName=%5BDEFAULT%5D&authType=signInViaPopup&redirectUrl=http%3A%2F%2Flocalhost%3A5173%2Flogin&v=10.13.2&eventId=8031253629&providerId=google.com&scopes=profile")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
}));
builder.Services.AddControllers();

 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InstallerServicesInAssembly(builder.Configuration); // Assuming this installs your services
 
// Configure DbContext with SQL Server (update your connection string as needed)
builder.Services.AddDbContext<CameraServicesPlatformDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBVPS")));



var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(op => op.SerializeAsV2 = false);
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = String.Empty;
    });


}

// Apply CORS policy
app.UseCors(MyAllowSpecificOrigins);

// Middleware configuration
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Map controllers
app.MapControllers();
app.MapHub<NotificationHub>(nameof(NotificationHub));

// Apply database migrations on startup
ApplyMigration();

app.Run();

void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        {
            var db = scope.ServiceProvider.GetRequiredService<CameraServicesPlatformDbContext>();
            if (db.Database.GetPendingMigrations().Any())
            {
                db.Database.Migrate();
            }
        }
    }
}