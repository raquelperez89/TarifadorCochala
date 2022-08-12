public class ImpuestoBoliviano : IImpuesto
{
    private readonly double PORCENTAJE_IMPUESTO = 0.15;

    public double applicarImpuesto(double monto)
    {
        return monto + (PORCENTAJE_IMPUESTO * monto);
    }
}