using System.Text.Json.Serialization;


public class Usuario
{
    public int ci { get; set; }
    public string nombreCompleto { get; set; }
    [JsonConverter(typeof(TarifadorJson.DateOnlyJsonConverter))]
    public DateOnly fechaNacimiento { get; set; }
    public string ocupacion { get; set; }
    public IPlan plan { get; set; }
    public double montoPorPagar = 0;

    public readonly List<Registro> listaRegistros = new List<Registro>();

    public Usuario(int ci, string nombreCompleto, DateOnly fechaNacimiento, string ocupacion, IPlan plan)
    {
        this.ci = ci;
        this.nombreCompleto = nombreCompleto;
        this.fechaNacimiento = fechaNacimiento;
        this.ocupacion = ocupacion;
        this.plan = plan;
    }

    public void mostrarMontoPorPagar()
    {
        Console.WriteLine(string.Format(this.nombreCompleto + ", deuda: " + this.montoPorPagar));
    }

    public void agregarNuevoRegistro(Registro registro)
    {
        this.listaRegistros.Add(registro);
    }

    public void calcularMontoTotalRegistros(List<IDescuento> descuentos, IImpuesto impuesto)
    {
        this.listaRegistros.ForEach(registro =>
        {
            registro.calcularMontoRegistro(this, descuentos, impuesto);
            this.montoPorPagar = this.montoPorPagar + registro.montoRegistro;
        });
    }
    public void mostrarInformacion()
    {
        Console.WriteLine("---------Información del Usuario---------");
        Console.WriteLine("Ci:" + ci);
        Console.WriteLine("Nombre completo:" + nombreCompleto);
        Console.WriteLine("Fecha de nacimiento:" + fechaNacimiento);
        Console.WriteLine("Ocupacion: " + ocupacion);
        Console.WriteLine("Plan: " + plan.getNombrePlan());
        Console.WriteLine("Monto por pagar: " + montoPorPagar);
    }
}
