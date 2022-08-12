
public class Registro
{
    public IVehiculo ? vehiculo {get; set;}
    public int minutos {get; set;}
    public DateOnly fecha {get; set;} 
    public double montoRegistro {get; set;} = 0;

    public Registro( IVehiculo vehiculo, int minutos){
        this.fecha = DateOnly.FromDateTime(DateTime.Now);
        this.vehiculo = vehiculo;
        this.minutos = minutos;
    }

    public void calcularMontoRegistro(Usuario usuario, List<IDescuento> descuentos, IImpuesto impuesto)
    {
        double totalDescuentos = descuentos.Aggregate(0.0, (sumaDescuntos, descuento) => sumaDescuntos + descuento.getPorcentajeDescuento(usuario));
        montoRegistro = usuario.plan.cobroTotalPorMinuto(this.vehiculo) * minutos ;
        montoRegistro = montoRegistro - montoRegistro * totalDescuentos;
        montoRegistro = impuesto.applicarImpuesto(montoRegistro);
    }
}