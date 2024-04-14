
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using PracticeTracker.Services.Authorization;
using PracticeTracker.Services.Authorization.Validate;
using PracticeTracker.Services.Authorization.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<AuthValidator>();

builder.Services.AddTransient<PracticeTracker.Services.Authorization.Interfaces.IAuthorizationService, AuthorizationService>();
builder.Services.AddTransient<IAuthorizationRepository, AuthorizationRepository>();

var app = builder.Build();

app.UseAuthentication();   // добавление middleware аутентификации 
app.UseAuthorization();   // добавление middleware авторизации 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.MapControllers();

app.Run();