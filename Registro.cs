class Registro
{
    public int usuarioCi {get; set;}
    public IVehiculo ? vehiculo {get; set;}
    public int minutos {get; set;}
    public DateOnly fecha {get; set;} 

    public Registro(int usuarioCi, IVehiculo vehiculo, int minutos){
        this.fecha = DateOnly.FromDateTime(DateTime.Now);
        this.usuarioCi = usuarioCi;
        this.vehiculo = vehiculo;
        this.minutos = minutos;
    }

    public void calcularMontoRegistro(Usuario usuario)
    {
        usuario.agregarMontoPorPagar( usuario.plan.cobroTotalPorMinuto(this.vehiculo) * minutos );
    }
}