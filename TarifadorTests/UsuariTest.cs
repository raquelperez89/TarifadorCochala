
namespace TarifadorTests
{
    [TestFixture]
    class UsuariTest
    {
        private Usuario usuario;

        [SetUp]
        public void SetUp()
        {
            IPlan planRegular = new PlanRegular();
            usuario =  new Usuario(2, "goku", new DateOnly(2000, 04, 20), "Estudiante", planRegular);
        }

        [Test]
        public void mostrarMontoPorPagarTest()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            usuario.mostrarMontoPorPagar();
            Assert.That(output.ToString(), Is.EqualTo(string.Format(this.usuario.nombreCompleto + ", deuda: " + this.usuario.montoPorPagar + "\r\n")));
        }
        [Test]
        public void agregarNuevoRegistroTest()
        {
            List<Registro> listaVacia = new List<Registro>(); 
            IVehiculo scooter = new Scooter();
            Registro nuevoRegistro = new Registro(scooter, 40);
            this.usuario.agregarNuevoRegistro(nuevoRegistro);
            Assert.AreNotEqual(listaVacia, this.usuario.listaRegistros);
        }
        [Test]
        public void calcularMontoTotalRegistrosTest()
        {
            double montoAntesDeCalculo = this.usuario.montoPorPagar; 
            IVehiculo scooter = new Scooter();
            Registro nuevoRegistro = new Registro(scooter, 40);
            List<IDescuento> descuentos = new List<IDescuento>(){
                new DescuentoCumple(),
                new DescuentoEstudiante()
            };
            this.usuario.agregarNuevoRegistro(nuevoRegistro);
            this.usuario.calcularMontoTotalRegistros(descuentos);
            Assert.AreNotEqual(montoAntesDeCalculo, this.usuario.montoPorPagar);
        }

    }
}