using NUnit.Framework;

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
            usuario =  new Usuario(1, "Pedro picapiedra", new DateOnly(2000, 08, 11), "plomero", planRegular);
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
            Assert.AreEqual(this.usuario.listaRegistros[0],nuevoRegistro);
        }
        [TestCase("Scooter", 40,28)]
        [TestCase("Hooverboard",0,0)]
        [TestCase("Bicicleta",20,16)]
        
        public void calcularMontoTotalRegistrosTest(String tipoVehiculo, int minutosRegistro, int esperado)
        {
            double montoAntesDeCalculo = this.usuario.montoPorPagar; 
            IVehiculo vehiculo = null;
            switch (tipoVehiculo)
            {
                case "Bicicleta":
                    vehiculo = new Bicicleta();
                    break;
                case "Triciclo":
                    vehiculo = new Triciclo();
                    break;
                case "Scooter":
                    vehiculo = new Scooter();
                    break;
                case "Hooverboard":
                    vehiculo = new Hoverboard();
                    break;
                default:
                    break;
            }
            Registro nuevoRegistro = new Registro(vehiculo, minutosRegistro);
            List<IDescuento> descuentos = new List<IDescuento>(){
                new DescuentoCumple(),
                new DescuentoEstudiante()
            };
            this.usuario.agregarNuevoRegistro(nuevoRegistro);
            this.usuario.calcularMontoTotalRegistros(descuentos);
            Assert.AreEqual(this.usuario.montoPorPagar, esperado);
        }

    }
}