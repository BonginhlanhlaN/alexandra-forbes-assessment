using crunch.api.ui.Services.Abstration;
using crunch.api.ui.Services.Implemenation;
using System.IO.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();


builder.Services.AddCors(p => p.AddPolicy("corsapp",builder =>
{

    builder.WithOrigins("*").AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();

}));

builder.Services.AddTransient<ICruchFileManipulator, CruchFileManipulator>();

builder.Services.AddTransient<IStringCruncher, StringCruncher>();
builder.Services.AddTransient<ICrunchIO, CrunchIO>();
builder.Services.AddTransient<ICrunchValidator, CrunchValidator>();

builder.Services.AddTransient<IFileSystem, FileSystem>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
app.UseCors("corsapp");

app.Run();
