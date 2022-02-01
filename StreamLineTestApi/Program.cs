using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StreamLineTestApi;
using StreamLineTestApi.Client.Profiles;
using StreamLineTestApi.Data.Context;
using StreamLineTestApi.Data.Repository;
using StreamLineTestApi.Domain.Models;
using StreamLineTestApi.Middlewares;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<StreamLineDbContext>(options =>
{
    var config = "Server=(localdb)\\mssqllocaldb;Database=StreamLineData;Trusted_Connection=True;MultipleActiveResultSets=true";
    options.UseSqlServer(config);
});

builder.Services.AddAuthentication(options => {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // указывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = true,
            // строка, представляющая издателя
            ValidIssuer = AuthOptions.ISSUER,
            // будет ли валидироваться потребитель токена
            ValidateAudience = true,
            // установка потребителя токена
            ValidAudience = AuthOptions.AUDIENCE,
            // будет ли валидироваться время существования
            ValidateLifetime = true,
            // установка ключа безопасности
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Test>, TestRepository>();
builder.Services.AddScoped<IRepository<Question>, QuestionRepository>();
builder.Services.AddScoped<IRepository<QuestionsAnswer>, QuestionsAnswerRepository>();

builder.Services.AddAutoMapper(typeof(AnswerProfile).GetTypeInfo().Assembly);
builder.Services.AddCors();
builder.Services.AddTransient<HTTPpipeline>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:3000")
    .AllowCredentials();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always
});

app.UseMiddleware<HTTPpipeline>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();