class PlanAnual
{
    private readonly double costoMinuto ;
    private readonly double costoInicial ;
    private IVehiculo vehiculo;
    double planConVehiculo;

    public PlanAnual(IVehiculo vehiculo){
        this.costoMinuto = 0.5;
        this.costoInicial = 800;
        this.vehiculo = vehiculo;
        this.planConVehiculo = this.vehiculo.getMontoMensual() + this.costoInicial;
    }
}
