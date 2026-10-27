namespace QuickFiscal.Core.Models;

public class Factura
{
    public int Id { get; set; }

    public string? Rnc { get; set; }
    public string? Ncf { get; set; }
    public DateOnly? Fecha { get; set; }
    public decimal? Itbis { get; set; }
    public decimal? Total { get; set; }

}
