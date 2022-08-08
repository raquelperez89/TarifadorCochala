class Usuario{
    public int ci{get; set;}
    public string nombreCompleto{get; set;}
    public DateOnly fechaNacimiento{get; set;}
    public string ocupacion{get; set;}
    public IPlan plan {get; set;}
    public double montoPorPagar = 0;

    public Usuario(int ci, string nombreCompleto, DateOnly fechaNacimiento, string ocupacion, IPlan plan){
        this.ci = ci;
        this.nombreCompleto = nombreCompleto;
        this.fechaNacimiento = fechaNacimiento;
        this.ocupacion = ocupacion;
        this.plan = plan;
    }
    public void agregarMontoPorPagar(double monto)
    {
        this.montoPorPagar = this.montoPorPagar + monto;
    }

    public void mostrarMontoPorPagar(){
        Console.WriteLine(this.nombreCompleto + ", deuda: " + this.montoPorPagar);
    }

}