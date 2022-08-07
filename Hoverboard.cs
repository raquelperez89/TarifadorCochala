class Hoverboard : IVehiculo
{
    public readonly double montoRegular = 1;
    public readonly double montoMensual = 10;
    public readonly double montoAnual = 100;

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