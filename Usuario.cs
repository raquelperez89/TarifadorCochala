class Usuario{
    public int ci{get; set;}
    public string nombreCompleto{get; set;}
    public DateOnly fechaNacimiento{get; set;}
    public string ocupacion{get; set;}
    public IPlan plan {get; set;}

    public Usuario(int ci, string nombreCompleto, DateOnly fechaNacimiento, string ocupacion, IPlan plan){
        this.ci = ci;
        this.nombreCompleto = nombreCompleto;
        this.fechaNacimiento = fechaNacimiento;
        this.ocupacion = ocupacion;
        this.plan = plan;
    }
}