
namespace TarifadorTests
{
    public class RegistroTest
    {
        private Registro registro;
        private IVehiculo vehiculo = new Scooter();
        private int minutosDeUso = 10;

        [SetUp]
        public void Setup()
        {

            registro = new Registro(vehiculo, minutosDeUso);
        }

        [Test]
        public void calcularMontoRegistro()
        {
            IImpuesto impuesto = new ImpuestoBoliviano();
            PlanRegular planRegular = new PlanRegular();
            Usuario usuario = new Usuario(1, "Pedro picapiedra", new DateOnly(2000, 08, 10), "plomero", planRegular);
            List<IDescuento> descuentos = new List<IDescuento>(){
            new DescuentoCumple(),
            new DescuentoEstudiante()};
            
             registro.calcularMontoRegistro(usuario, descuentos, impuesto);
            double monto = registro.montoRegistro;

            Assert.AreEqual(7.0, monto);
        }
    }
}