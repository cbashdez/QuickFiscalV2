using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickFiscal.Core.Models;

namespace QuickFiscal.Infrastructure.Persistencia.Configuraciones;

public class FacturaConfiguracion : IEntityTypeConfiguration<Factura>
{
    public void Configure(EntityTypeBuilder<Factura> builder)
    {
        builder.ToTable("Facturas");
        builder.HasKey(f => f.Id);

        //  RNC: 9 digitos (empresa) u 11 (cedula)
        builder.Property(f => f.Rnc).HasMaxLength(11);

        // NCF: 11 caracteres (B01...) o 13 (e-CF, E31...)
        builder.Property(f => f.Ncf).HasMaxLength(13);

        builder.Property(f => f.Categoria).HasMaxLength(100).IsRequired();
        builder.Property(f => f.FormaPago).HasMaxLength(100).IsRequired();

        // Estado se calcula al vuelo; no es una columna
        builder.Ignore(f => f.Estado);

        // Las dudas se guardan como JSON en una sola columna
        builder.ComplexCollection(f => f.Dudas, d => d.ToJson());

        // Un mismo vendedor no puede repetir un NCF
        builder.HasIndex(f => new { f.Rnc, f.Ncf }).IsUnique();
    }
}