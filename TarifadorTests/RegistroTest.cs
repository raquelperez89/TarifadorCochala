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
            double montoTotal = registro.montoRegistro;

            Assert.AreEqual(8.05, montoTotal);
        }

        [Test]
        public void calcularMontoRegistroEstudiante()
        {
            PlanRegular planRegular = new PlanRegular();
            IImpuesto impuesto = new ImpuestoBoliviano();
            Usuario usuario = new Usuario(1, "Pedro", new DateOnly(2000, 08, 10), "Estudiante", planRegular);
            List<IDescuento> descuentos = new List<IDescuento>(){
            new DescuentoCumple(),
            new DescuentoEstudiante()};

            registro.calcularMontoRegistro(usuario, descuentos, impuesto);
            double montoTotal = registro.montoRegistro;

            Assert.AreEqual(6.8425, montoTotal);
        }

        [Test]
        public void calcularMontoRegistroEstudianteConDescuentoCumpleaño()
        {
            PlanRegular planRegular = new PlanRegular();
            IImpuesto impuesto = new ImpuestoBoliviano();
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            Usuario usuario = new Usuario(1, "Pedro", today, "Estudiante", planRegular);
            List<IDescuento> descuentos = new List<IDescuento>(){
            new DescuentoCumple(),
            new DescuentoEstudiante()};

            registro.calcularMontoRegistro(usuario, descuentos, impuesto);
            double montoTotal = registro.montoRegistro;

            Assert.AreEqual(4.4275, montoTotal);
        }

        [Test]
        public void calcularMontoRegistroConDescuentoDel90PorCiento()
        {
            PlanRegular planRegular = new PlanRegular();
            IImpuesto impuesto = new ImpuestoBoliviano();
            Usuario usuario = new Usuario(1, "Pedro", new DateOnly(2000, 08, 12), "Estudiante", planRegular);
            List<IDescuento> descuentos = new List<IDescuento>(){
            new DescuentoCumple(),
            new DescuentoEstudiante(),
            new DescuentoEstudiante(),
            new DescuentoEstudiante(),
            new DescuentoEstudiante()};

            registro.calcularMontoRegistro(usuario, descuentos, impuesto);
            double monto = registro.montoRegistro;

            Assert.AreEqual(4.025, monto);
        }
        
    }
}