using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BankingSystem.DataAccess.Sql;
using BankingSystem.DataAccess.Sql.Repository.Interfaces;
using BankingSystem.DataAccess.Sql.Repository.Services;
using BankingSystem.UserInterface.Kendo.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IRepoAppSettings, RepoAppSettings>();
builder.Services.AddScoped<IRepoAccounts, RepoAccounts>();
builder.Services.AddScoped<IRepoRecurrings, RepoRecurrings>();
builder.Services.AddScoped<IRepoTransactions, RepoTransactions>();
builder.Services.AddScoped<IRepoUsers, RepoUsers>();
builder.Services.AddScoped<SelectHelper>();
builder.Services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddKendo();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
        };

        options.Events = new JwtBearerEvents
        {
            OnChallenge = async context =>
            {
                // Call this to skip the default logic and avoid using the default response
                context.HandleResponse();
                // Write to the response in any way you wish
                context.Response.StatusCode = 401;
                context.Response.Headers.Append("Token-Status", "Invalid or Expired. You are not authorized to access this resource.");
                await context.Response.WriteAsync("Access Denied. You are not authorized to access this resource.");
            }
        };
    });

builder.Services.Configure<MvcViewOptions>(options =>
    options.HtmlHelperOptions.CheckBoxHiddenInputRenderMode =
        CheckBoxHiddenInputRenderMode.None);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();