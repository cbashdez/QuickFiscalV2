using Microsoft.EntityFrameworkCore;
using QuickFiscal.Infrastructure.Persistencia;
using QuickFiscal.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var cadenaConexion = builder.Configuration.GetConnectionString("QuickFiscal")
    ?? throw new InvalidOperationException("Falta la cadena de conexión 'QuickFiscal' en appsettings.");

builder.Services.AddInfraestructura(cadenaConexion, builder.Environment.ContentRootPath);

var app = builder.Build();

// Aplica las migraciones pendientes al arrancar
using (var scope = app.Services.CreateScope())
{
    var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
    using var db = factory.CreateDbContext();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
