namespace TarifadorTests
{
    [TestFixture]
    public class TarifadorTest
    {
        private Tarifador tarifador;
        private IImpuesto impuesto;
        private IPlan planMensual, planRegular;
        private DateOnly fechaNacimiento;
        private DateOnly today;
        private Usuario usuario;
        private IVehiculo bicicleta, scooter;
        private IDescuento descuentoCumple, descuentoEstudiante;

        [SetUp]
        public void SetUp()
        {
            tarifador = new Tarifador();
            impuesto = new ImpuestoBoliviano();
            planMensual = new PlanMensual();
            planRegular = new PlanRegular();
            fechaNacimiento = new DateOnly(2000, 12, 1);
            usuario = new Usuario(89898, "Juan", fechaNacimiento, "Estudiante", planMensual);
            bicicleta = new Bicicleta();
            scooter = new Scooter();
            descuentoCumple = new DescuentoCumple();
            descuentoEstudiante = new DescuentoEstudiante();
            today = DateOnly.FromDateTime(DateTime.Now);
        }

        [Test]
        public void addUsuarioTest()
        {
            tarifador.addUsuario(usuario);
            Assert.AreEqual(89898, tarifador.getListaUsuarios()[0].ci);
            Assert.AreEqual("Juan", tarifador.getListaUsuarios()[0].nombreCompleto);
            Assert.AreEqual(fechaNacimiento, tarifador.getListaUsuarios()[0].fechaNacimiento);
            Assert.AreEqual("Estudiante", tarifador.getListaUsuarios()[0].ocupacion);
            Assert.AreEqual(89898, tarifador.getListaUsuarios()[0].ci);
            Assert.IsInstanceOf(typeof(IPlan), tarifador.getListaUsuarios()[0].plan);

        }

        [Test]
        public void getListaUsuariosTest()
        {
            Assert.IsInstanceOf(typeof(List<Usuario>), tarifador.getListaUsuarios());
        }

        [Test]
        public void addListaUsuariosTest()
        {
            List<Usuario> listaUsuariosSinAgregar = this.tarifador.getListaUsuarios();
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
                usuario
            };
            tarifador.addListaUsuarios(listaUsuarios);
            Assert.AreNotEqual(listaUsuariosSinAgregar, this.tarifador.getListaUsuarios());
        }

        [Test]
        public void aniadirRegistroAUsuarioTest(){
            Registro registro = new Registro(bicicleta, 30);
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
                new Usuario(1, "Pedro picapiedra", new DateOnly(2000, 08, 11), "plomero", planMensual),
                new Usuario(89898, "goku", new DateOnly(2000, 04, 20), "Estudiante", planMensual)
            };
            List<IDescuento>  descuento = new List<IDescuento>()
            {
                descuentoEstudiante
            };
                       
            tarifador.addListaUsuarios(listaUsuarios);
            tarifador.aniadirRegistroAUsuario(89898, registro);
            tarifador.aniadirRegistroAUsuario(89898, registro);
            listaUsuarios[1].calcularMontoTotalRegistros(descuento, impuesto);

            List<Registro> listaRegistros = new List<Registro>();
            double result = listaUsuarios[1].montoPorPagar;

            Assert.AreNotEqual(listaRegistros.Count, listaUsuarios[1].listaRegistros.Count);
            Assert.AreEqual(35.19, result);
        }

        [Test]
        public void aniadirRegistroAUsuarioNullTest()
        {
            Registro registro = new Registro(bicicleta, 30);
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
                new Usuario(1, "Pedro picapiedra", new DateOnly(2000, 08, 11), "plomero", planMensual),
                new Usuario(89898, "goku", new DateOnly(2000, 04, 20), "Estudiante", planMensual)
            };
            List<Registro> listaRegistros = new List<Registro>();
            tarifador.addListaUsuarios(listaUsuarios);
            tarifador.aniadirRegistroAUsuario(00, registro);
            Assert.AreEqual(listaRegistros.Count, listaUsuarios[1].listaRegistros.Count);
        }


        [Test]
        public void tarifarConListaDeDescuentos()
        {
            Registro registro = new Registro(scooter, 30);
            
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
            new Usuario(1, "Pedro", today, "plomero", planRegular),
            new Usuario(89898, "goku", new DateOnly(2000, 04, 20), "Estudiante", planRegular)
            };
            List<Registro> listaRegistros = new List<Registro>();
            listaRegistros.Add(registro);
            listaRegistros.Add(registro);
            tarifador.addListaUsuarios(listaUsuarios);
            tarifador.aniadirRegistroAUsuario(listaUsuarios[0].ci, listaRegistros[0]);
            tarifador.aniadirRegistroAUsuario(listaUsuarios[1].ci, listaRegistros[1]);

            List<IDescuento> descuentos = new List<IDescuento>(){
                descuentoCumple,
                descuentoEstudiante
            };

            double valorUsuario0 = 16.904999999999998;
            String deudaUsuario0 = valorUsuario0.ToString();
            double valorUsuario1 = 20.527500000000003;
            String deudaUsuario1 = valorUsuario1.ToString();

            tarifador.tarifar(descuentos,impuesto);
            var output = new StringWriter();
            Console.SetOut(output);
            tarifador.mostrarMontoPorUsuario();
            Assert.That(output.ToString(), Is.EqualTo(string.Format(listaUsuarios[0].nombreCompleto + ", deuda: " + deudaUsuario0 + "\r\n" +
                                                                    listaUsuarios[1].nombreCompleto + ", deuda: " + deudaUsuario1 + "\r\n")));
        }

        [Test]
        public void tarifarConListaDeDescuentosVacia()
        {
            Registro registro = new Registro(scooter, 30);
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
                new Usuario(1, "Pedro", today, "plomero", planRegular),
                new Usuario(89898, "goku", new DateOnly(2000, 04, 20), "Estudiante", planRegular)
            };
            List<Registro> listaRegistros = new List<Registro>();
            listaRegistros.Add(registro);
            listaRegistros.Add(registro);
            tarifador.addListaUsuarios(listaUsuarios);
            tarifador.aniadirRegistroAUsuario(listaUsuarios[0].ci, listaRegistros[0]);
            tarifador.aniadirRegistroAUsuario(listaUsuarios[1].ci, listaRegistros[1]);

            List<IDescuento> descuentos = new List<IDescuento>(){
            };

            double valor = 24.15;
            String deuda = valor.ToString();

            tarifador.tarifar(descuentos, impuesto);
            var output = new StringWriter();
            Console.SetOut(output);
            tarifador.mostrarMontoPorUsuario();
            Assert.That(output.ToString(), Is.EqualTo(string.Format(listaUsuarios[0].nombreCompleto + ", deuda: " + deuda + "\r\n" +
                                                                    listaUsuarios[1].nombreCompleto + ", deuda: " + deuda + "\r\n")));
        }
        [Test]
        public void mostrarMontoPorUsuarioTest(){
            double valor = 13.8;
            String deuda = valor.ToString();
            Registro registro = new Registro(bicicleta, 20);
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
                new Usuario(1, "Pedro picapiedra", new DateOnly(2000, 08, 11), "plomero", planMensual),
                new Usuario(89898, "goku", new DateOnly(2000, 04, 20), "plomero", planMensual)
            };
            List<Registro> listaRegistros = new List<Registro>();
            Tarifador tarifadortest = new Tarifador();
            tarifadortest.addListaUsuarios(listaUsuarios);
            tarifadortest.aniadirRegistroAUsuario(1, registro);
            List<IDescuento> descuentos = new List<IDescuento>(){
                descuentoCumple,
                descuentoEstudiante
            };
            tarifadortest.tarifar(descuentos,impuesto);
            var output = new StringWriter();
            Console.SetOut(output);
            tarifadortest.mostrarMontoPorUsuario();
            Assert.That(output.ToString(), Is.EqualTo(string.Format(listaUsuarios[0].nombreCompleto + ", deuda: " + deuda + "\r\n" +
                                                                    listaUsuarios[1].nombreCompleto + ", deuda: " + "0" + "\r\n")));
        }
    }
}