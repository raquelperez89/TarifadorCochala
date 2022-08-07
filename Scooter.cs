class Scooter : IVehiculo
{
    public readonly double montoRegular = 2;
    public readonly double montoMensual = 15;
    public readonly double montoAnual = 200;
    public double getMontoRegular()
    {
        return this.montoRegular;
    }
    public double getMontoMensual()
    {
        return this.montoMensual;
    }
    public double getMontoAnual()
    {
        return this.montoAnual;
    }
}