
public class Bicicleta : IVehiculo
{
    private double tarifaAgregadaMinuto = 0.30;

    public double getTarifaAgregada()
    {
        return this.tarifaAgregadaMinuto;
    }
    
}
