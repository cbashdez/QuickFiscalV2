namespace QuickFiscal.Core.Models;

public class Factura
{
    public int Id { get; set; }

    /// <summary>
    /// RNC del VENDEDOR. Nunca el de la empresa compradora (ver Empresa.Rnc).
    /// </summary>
    public string? Rnc { get; set; }
    public string? Ncf { get; set; }
    public DateOnly? Fecha { get; set; }
    public decimal? Itbis { get; set; }
    public decimal? Total { get; set; }
    public List<DudaCampo> Dudas { get; set; } = [];

    public EstadoFactura Estado
    {
        get
        {
            var faltaCritico = string.IsNullOrWhiteSpace(Rnc)
                || string.IsNullOrWhiteSpace(Ncf)
                || Fecha is null
                || Itbis is null
                || Total is null;

            if (faltaCritico) return EstadoFactura.CamposFaltantes;

            return Dudas.Count > 0 ? EstadoFactura.RevisarDudas : EstadoFactura.Completa;
        }
    }


}
