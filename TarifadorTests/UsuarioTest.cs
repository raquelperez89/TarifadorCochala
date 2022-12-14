namespace UsuarioTests
{
    [TestFixture]
    class UsuarioTest
    {
        private Usuario usuario;
        private IImpuesto impuesto;

        [SetUp]
        public void SetUp()
        {
            IPlan planRegular = new PlanRegular();
            impuesto= new ImpuestoBoliviano();
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
        [TestCase("Scooter", 40,32.2)]
        [TestCase("Hooverboard",0,0)]
        [TestCase("Bicicleta",20,18.4)]
        public void calcularMontoTotalRegistrosTest(String tipoVehiculo, int minutosRegistro, double esperado)
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
            this.usuario.calcularMontoTotalRegistros(descuentos,impuesto);
            Assert.AreEqual(this.usuario.montoPorPagar, esperado);
        }

        [Test]
        public void mostrarInfoTest()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            usuario.mostrarInformacion();
            Assert.That(output.ToString(), Is.EqualTo(string.Format("---------Informaci??n del Usuario---------"+"\r\n" +
                                                                    "Ci:" + usuario.ci +  "\r\n" +
                                                                    "Nombre completo:" + usuario.nombreCompleto + "\r\n" +
                                                                    "Fecha de nacimiento:" + usuario.fechaNacimiento + "\r\n" +
                                                                    "Ocupacion: " + usuario.ocupacion + "\r\n" +
                                                                    "Plan: " + usuario.plan.getNombrePlan() + "\r\n" +
                                                                    "Monto por pagar: " + usuario.montoPorPagar + "\r\n")));
        }

    }
}