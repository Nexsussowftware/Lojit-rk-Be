using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services;
using Services.Manager.Auth;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<ApplicationDbContext>();

// add SignalR
builder.Services.AddSignalR();

// Add Services
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureApplicationServices();
builder.Services.AddMyIdentity();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IAuthService, AuthService>();

// Localizer
builder.Services.AddLocalization();
builder.Services.AddControllersWithViews().AddViewLocalization();


//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


// Jwt Service
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddAuthorization();




//Eklenecek olan kayýt satýrý.
builder.Services.AddTransient<IAuthService, AuthService>();



//Cross-Origin Resource Sharing
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("https://crm.alderi.co") // Angular uygulamas?n?n URL'si
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials(); // Kimlik bilgilerine izin ver
    });
});

// if development
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigins", policy =>
        {
            policy.WithOrigins("http://localhost:2014") // Angular uygulamas?n?n URL'si
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials(); // Kimlik bilgilerine izin ver
        });
    });
}

// Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Alderi_CRM_Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: '{token}'"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Alderi_CRM_Api");
        x.DisplayRequestDuration();
    });
}
// Images Folder
//string imagesPath = Path.Combine(app.Environment.ContentRootPath, "Images");
//string userPath = Path.Combine(imagesPath, "User");
//string meetingPath = Path.Combine(imagesPath, "Meeting");
//string productPath = Path.Combine(imagesPath, "Product");
//string uploadsPath = Path.Combine(imagesPath, "Email-Uploads");
//foreach (var path in new string[] { imagesPath, userPath, meetingPath, productPath, uploadsPath })
//{
//    if (!Directory.Exists(path))
//    {
//        Directory.CreateDirectory(path);
//    }
//}

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseRouting();
app.UseRequestLocalization();
app.UseHttpsRedirection();



app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
});
// Cross-Origin Resource Sharing
app.UseCors("AllowSpecificOrigins");
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

// SignalR Hub
app.MapHub<NotificationHub>("/notificationHub").RequireCors("AllowSpecificOrigins");

app.UseSwaggerUI(app =>
{
    app.SwaggerEndpoint("/swagger/v1/swagger.json", "Alderi_CRM_Api");
    app.DisplayRequestDuration();
});
app.SeedData();
await app.RunAsync();
