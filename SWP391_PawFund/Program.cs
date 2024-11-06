
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RepositoryLayer;
using RepositoryLayer.UnitOfWork;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using System.Text;
using SWP391_PawFund.AppStarts;
using Twilio.Clients;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Http.Features;
using Google.Apis.Json;
using System.Text.Json;
using ModelLayer.Entities;
using ModelLayer.Entities.Momo;

var builder = WebApplication.CreateBuilder(args);

//Twilio setting
builder.Services.Configure<SmsMessage>(builder.Configuration.GetSection("Twilio"));

builder.Services.Configure<MomoOptionModel>(builder.Configuration.GetSection("MomoAPI"));

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();

var firebaseConfig = Environment.GetEnvironmentVariable("FIREBASE_CONFIG");

if (!string.IsNullOrEmpty(firebaseConfig))
{
    // If deployed, use the environment variable for Firebase configuration
    FirebaseApp.Create(new AppOptions()
    {
        Credential = GoogleCredential.FromJson(firebaseConfig)
    });
}
else
{
    // If running locally, use the local service account file
    FirebaseApp.Create(new AppOptions()
    {
        Credential = GoogleCredential.FromFile("firebase-adminsdk.json"),
    });
}


builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600; // 100 MB file limit
});
//builder.Services.AddSingleton<IVnPayService, VnPayService>();

// Install DI and dbcontext
builder.Services.InstallService(builder.Configuration);
// Swagger config
//builder.Services.ConfigureSwaggerServices("SWPProject");
builder.Services.ConfigureAuthService(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen(c =>
//{
//	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//	c.IncludeXmlComments(xmlPath);
//});

builder.Services.AddSwaggerGen(c =>
{
    //c.OperationFilter<SnakecasingParameOperationFilter>();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PawFund API",
        Version = "v1"
    });


    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        securitySchema, new string[] { "Bearer" }
        }
    });
});
// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .WithOrigins("https://localhost:7293", "http://localhost:3000", "https://abandonedpets.ddns.net")
        );
});

var configuration = builder.Configuration;
var app = builder.Build();




//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PawFund API");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
