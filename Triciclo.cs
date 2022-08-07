class Triciclo : IVehiculo
{
    public readonly double montoRegular = 5;
    public readonly double montoMensual = 80;
    public readonly double montoAnual = 700;

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