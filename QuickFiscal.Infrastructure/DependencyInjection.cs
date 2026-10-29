using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuickFiscal.Infrastructure.Persistencia;

namespace QuickFiscal.Infrastructure.Persistencia;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructura(
        this IServiceCollection services,
        string cadenaConexion,
        string rutaBase)

    {
        // Convierte "App_Data/quickfiscal.db" en una ruta absoluta
        var csb = new SqliteConnectionStringBuilder(cadenaConexion);
        csb.DataSource = Path.Combine(rutaBase, csb.DataSource);

        // SQLite crea el archivo .db, pero NO la carpeta
        Directory.CreateDirectory(Path.GetDirectoryName(csb.DataSource)!);

        services.AddDbContextFactory<AppDbContext>(options =>
            options.UseSqlite(csb.ToString()));

        return services;
    }
}
