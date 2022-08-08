class Registro
{
    public int usuarioCi {get; set;}
    public IVehiculo ? vehiculo {get; set;}
    public int minutos {get; set;}
    public DateOnly fecha {get; set;} 

    public Registro(){
        this.fecha = DateOnly.FromDateTime(DateTime.Now);
    }

    public double calcularMontoRegistro(Usuario usuario)
    {
        return usuario.plan.cobroTotalMinutos(vehiculo) * minutos;
    }
}