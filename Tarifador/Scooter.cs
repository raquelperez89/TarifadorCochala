[Serializable]
public class Scooter : IVehiculo
{
    private double tarifaAgregadaMinuto = 0.20;

    public double getTarifaAgregada()
    {
        return this.tarifaAgregadaMinuto;
    }
}