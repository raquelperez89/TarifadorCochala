public class PlanMensual : IPlan
{
    private readonly double costoMinutoInicial = 0.3;
    public double cobroTotalPorMinuto(IVehiculo tipoVehiculo)
    {
        return costoMinutoInicial + tipoVehiculo.getTarifaAgregada();
    }

    public String getNombrePlan()
    {
        return "MENSUAL";
    }
}
