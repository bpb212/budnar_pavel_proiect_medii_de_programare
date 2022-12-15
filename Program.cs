using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using budnar_pavel_proiect_medii_de_programare.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<budnar_pavel_proiect_medii_de_programareContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("budnar_pavel_proiect_medii_de_programareContext") ?? throw new InvalidOperationException("Connection string 'budnar_pavel_proiect_medii_de_programareContext' not found.")));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
