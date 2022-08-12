
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

            registro.calcularMontoRegistro(usuario, descuentos);
            double montoTotal = registro.montoRegistro;

            Assert.AreEqual(7.0, montoTotal);
        }

        [Test]
        public void calcularMontoRegistroEstudiante()
        {
            PlanRegular planRegular = new PlanRegular();
            Usuario usuario = new Usuario(1, "Pedro", new DateOnly(2000, 08, 10), "Estudiante", planRegular);
            List<IDescuento> descuentos = new List<IDescuento>(){
            new DescuentoCumple(),
            new DescuentoEstudiante()};

            registro.calcularMontoRegistro(usuario, descuentos);
            double montoTotal = registro.montoRegistro;

            Assert.AreEqual(5.95, montoTotal);
        }

        [Test]
        public void calcularMontoRegistroEstudianteConDescuentoCumpleaño()
        {
            PlanRegular planRegular = new PlanRegular();
            Usuario usuario = new Usuario(1, "Pedro", new DateOnly(2000, 08, 12), "Estudiante", planRegular);
            List<IDescuento> descuentos = new List<IDescuento>(){
            new DescuentoCumple(),
            new DescuentoEstudiante()};

            registro.calcularMontoRegistro(usuario, descuentos);
            double montoTotal = registro.montoRegistro;

            Assert.AreEqual(3.8500000000000005d, montoTotal);
        }

        [Test]
        public void calcularMontoRegistroConDescuentoDel90PorCiento()
        {
            PlanRegular planRegular = new PlanRegular();
            Usuario usuario = new Usuario(1, "Pedro", new DateOnly(2000, 08, 12), "Estudiante", planRegular);
            List<IDescuento> descuentos = new List<IDescuento>(){
            new DescuentoCumple(),
            new DescuentoEstudiante(),
            new DescuentoEstudiante(),
            new DescuentoEstudiante(),
            new DescuentoEstudiante()};

            registro.calcularMontoRegistro(usuario, descuentos);
            double monto = registro.montoRegistro;

            Assert.AreEqual(3.5, monto);
        }
        
    }
}