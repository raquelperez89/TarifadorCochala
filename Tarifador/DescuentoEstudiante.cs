public class DescuentoEstudiante: IDescuento
{
    private double porcentajeDescuento = 0.15;
    public double getPorcentajeDescuento(Usuario usuario){
        
        if (usuario.ocupacion == "Estudiante"){

            return this.porcentajeDescuento;
        }
        return 0;
    }
}