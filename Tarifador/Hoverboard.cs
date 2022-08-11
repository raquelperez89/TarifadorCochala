
public class Hoverboard : IVehiculo
{
    private double tarifaAgregadaMinuto = 0.25;

    public double getTarifaAgregada()
    {
        return this.tarifaAgregadaMinuto;
    }
}