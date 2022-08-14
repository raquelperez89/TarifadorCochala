namespace RegistroTests
{
    public class RegistroTest
    {
        private Registro registro;
        private IVehiculo vehiculo = new Scooter();
        private int minutosDeUso = 10;
        private IImpuesto impuesto;
        private IPlan planRegular;

        [SetUp]
        public void Setup()
        {

            registro = new Registro(vehiculo, minutosDeUso);
            impuesto = new ImpuestoBoliviano();
            planRegular = new PlanRegular();
        }

        [Test]
        public void calcularMontoRegistro()
        {
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