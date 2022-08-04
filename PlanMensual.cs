class PlanMensual
{
    private readonly double costoMinuto ;
    private readonly double costoInicial ;
    private IVehiculo vehiculo;
    double planConVehiculo;

    public PlanMensual(IVehiculo vehiculo){
        this.costoMinuto = 0.7;
        this.costoInicial = 70;
        this.vehiculo = vehiculo;
    }
    public void agregarMonto(){
    }  
}
