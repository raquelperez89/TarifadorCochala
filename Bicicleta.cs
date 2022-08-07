class Bicicleta : IVehiculo
{
    private double montoMensual = 30;
    private double montoRegular = 3;
    private double montoAnual = 300;    

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