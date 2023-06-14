using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MyPortfoliio.Interface;
using MyPortfoliio.Models;
using MyPortfoliio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton(builder.Configuration.GetSection("MailSettings").Get<MailSettings>());

builder.Services.AddScoped<IMailService, MailService>();

builder.Services.AddScoped<NotifyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
