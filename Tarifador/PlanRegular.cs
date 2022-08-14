public class PlanRegular : IPlan
{
    private readonly double costoMinutoInicial = 0.5;

    public double cobroTotalPorMinuto(IVehiculo tipoVehiculo)
    {
        return costoMinutoInicial + tipoVehiculo.getTarifaAgregada();
    }

    public string getNombrePlan(){
        return "REGULAR";
    }

}

