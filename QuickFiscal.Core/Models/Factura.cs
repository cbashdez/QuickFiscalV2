namespace QuickFiscal.Core.Models;

public class Factura
{
    public int Id { get; set; }

    public string? Rnc { get; set; }
    public string? Ncf { get; set; }
    public DateOnly? Fecha { get; set; }
    public decimal? Itbis { get; set; }
    public decimal? Total { get; set; }


    public EstadoFactura Estado
    {
        get
        {
            var faltaCritico = string.IsNullOrWhiteSpace(Rnc)
                || string.IsNullOrWhiteSpace(Ncf)
                || Fecha is null
                || Itbis is null
                || Total is null;

            return faltaCritico ? EstadoFactura.CamposFaltantes : EstadoFactura.Completa;
        }
    }


}
