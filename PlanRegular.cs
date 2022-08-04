class PlanRegular{
    private readonly double costoMinuto;
    private readonly double costoInicial;
    private IVehiculo vehiculo; 
    double planConVehiculo;
    public PlanRegular(IVehiculo vehiculo){
        this.costoMinuto = 0.8;
        this.costoInicial = 5;
        this.vehiculo = vehiculo;
    } 
    public double agregarMonto(){
        //Se agregara esta parte cuando vehiculo tenga el metodo getMontoRegular();
        //planConVehiculo = this.costoInicial + this.vehiculo.getMontoRegular();
        return planConVehiculo;
    }
}

