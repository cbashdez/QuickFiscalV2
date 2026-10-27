namespace QuickFiscal.Core.Constantes;

public static class CodigosDgii606
{

    public const string CategoriaPorDefecto = "02-GASTOS POR TRABAJOS, SUMINISTROS Y SERVICIOS";
    public const string FormaPagoPorDefecto = "02 - CHEQUES/TRANSFERENCIAS/DEPÓSITO";

    public static readonly IReadOnlyList<string> TiposBienesYServicios =
    [
        "01-GASTOS DE PERSONAL",
        CategoriaPorDefecto,
        "03-ARRENDAMIENTOS",
        "04-GASTOS DE ACTIVOS FIJO",
        "05 -GASTOS DE REPRESENTACIÓN",
        "06 -OTRAS DEDUCCIONES ADMITIDAS",
        "07 -GASTOS FINANCIEROS",
        "08 -GASTOS EXTRAORDINARIOS",
        "09 -COMPRAS Y GASTOS QUE FORMARAN PARTE DEL COSTO DE VENTA",
        "10 -ADQUISICIONES DE ACTIVOS",
        "11- GASTOS DE SEGUROS"
    ];

    public static readonly IReadOnlyList<string> FormasDePago =
    [
        "01 - EFECTIVO",
        FormaPagoPorDefecto,
        "03 - TARJETA CRÉDITO/DÉBITO",
        "04 - COMPRA A CREDITO",
        "05 - PERMUTA",
        "06 - NOTA DE CREDITO",
        "07 - MIXTO"
    ];
}