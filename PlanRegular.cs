class PlanRegular{
    private readonly double costoMinuto;
    private readonly double costoInicial;
    private IVehiculo vehiculo; 
    double planConVehiculo;
    public PlanRegular(IVehiculo vehiculo){
        this.costoMinuto = 0.8;
        this.costoInicial = 5;
        this.vehiculo = vehiculo;
        this.planConVehiculo = this.vehiculo.getMontoMensual() + this.costoInicial;
    } 
}

