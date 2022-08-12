
public class Registro
{
    public IVehiculo? vehiculo { get; set; }
    public int minutos { get; set; }
    public DateOnly fecha { get; set; }
    public double montoRegistro { get; set; } = 0;

    private double limiteDescuento = 0.50;

    public Registro(IVehiculo vehiculo, int minutos)
    {
        this.fecha = DateOnly.FromDateTime(DateTime.Now);
        this.vehiculo = vehiculo;
        this.minutos = minutos;
    }

    private double limitarDescuentos(double limiteDescuento, double totalDescuentos)
    {
        if (totalDescuentos > limiteDescuento)
        {
            return limiteDescuento;
        }
        return totalDescuentos;
    }
    public void calcularMontoRegistro(Usuario usuario, List<IDescuento> descuentos)
    {
        double totalDescuentos = descuentos.Aggregate(0.0, (sumaDescuntos, descuento) => sumaDescuntos + descuento.getPorcentajeDescuento(usuario));
        totalDescuentos = limitarDescuentos(limiteDescuento, totalDescuentos);
        montoRegistro = usuario.plan.cobroTotalPorMinuto(this.vehiculo) * minutos;
        montoRegistro = montoRegistro - montoRegistro * totalDescuentos;
    }
}