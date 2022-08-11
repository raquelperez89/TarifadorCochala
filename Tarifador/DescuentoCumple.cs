public class DescuentoCumple : IDescuento
{
    private double porcentajeDescuento = 0.30;

    public double getPorcentajeDescuento(Usuario usuario)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        if(usuario.fechaNacimiento.Month == today.Month && usuario.fechaNacimiento.Day == today.Day)
        {
            return this.porcentajeDescuento;
        }
        return 0;
    }
    
}