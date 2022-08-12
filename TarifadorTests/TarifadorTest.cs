namespace TarifadorTests
{
    [TestFixture]
    public class TarifadorTest
    {
        private Tarifador tarifador;
        private IImpuesto impuesto;

        [SetUp]
        public void SetUp()
        {
            tarifador = new Tarifador();
            impuesto = new ImpuestoBoliviano();
        }

        [Test]
        public void addUsuarioTest()
        {
            IPlan plan = new PlanMensual();
            DateOnly fechaNacimiento = new DateOnly(2000, 12, 1);
            Usuario usuario = new Usuario(89898, "Juan", fechaNacimiento, "Estudiante", plan);
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
            List<Usuario> listaUsuariosSinAgregar = this.tarifador.getListaUsuario();
            IPlan plan = new PlanMensual();
            DateOnly fechaNacimiento = new DateOnly(2000, 12, 1);
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
                new Usuario(8988, "Test2", fechaNacimiento, "Estudiante", plan)
            };
            tarifador.addListaUsuarios(listaUsuarios);
            Assert.AreNotEqual(listaUsuariosSinAgregar, this.tarifador.getListaUsuario());
        }

        [Test]
        public void tarifarTest()
        {
            List<Usuario> usuarios = new List<Usuario>();
        }

        [Test]
        public void aniadirRegistroAUsuarioTest()
        {
            IVehiculo vehiculo = new Bicicleta();
            Registro registro = new Registro(vehiculo, 30);
            IPlan plan = new PlanMensual();
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
                new Usuario(1, "Pedro picapiedra", new DateOnly(2000, 08, 11), "plomero", plan),
                new Usuario(89898, "goku", new DateOnly(2000, 04, 20), "Estudiante", plan)
            };
            List<IDescuento>  descuento = new List<IDescuento>()
            {
                new DescuentoEstudiante()
            };
                       
            tarifador.addListaUsuarios(listaUsuarios);
            tarifador.aniadirRegistroAUsuario(89898, registro);
            tarifador.aniadirRegistroAUsuario(89898, registro);
            
            Assert.AreNotEqual(listaRegistros.Count,listaUsuarios[1].listaRegistros.Count);
        }

        [Test]
        public void aniadirRegistroAUsuarioNullTest()
        {
            IVehiculo vehiculo = new Bicicleta();
            Registro registro = new Registro(vehiculo, 30);
            IPlan plan = new PlanMensual();
            DateOnly fechaNacimiento = new DateOnly(2000, 12, 1);
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
                new Usuario(1, "Pedro picapiedra", new DateOnly(2000, 08, 11), "plomero", plan),
                new Usuario(89898, "goku", new DateOnly(2000, 04, 20), "Estudiante", plan)
            };
            List<Registro> listaRegistros = new List<Registro>();
            tarifador.addListaUsuarios(listaUsuarios);
            tarifador.aniadirRegistroAUsuario(00, registro);
            Assert.AreEqual(listaRegistros.Count, listaUsuarios[1].listaRegistros.Count);
        }


        [Test]
        public void tarifarConListaDeDescuentos()
        {
            IVehiculo vehiculo = new Scooter();
            Registro registro = new Registro(vehiculo, 30);
            IPlan plan = new PlanRegular();
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
            new Usuario(1, "Pedro", today, "plomero", plan),
            new Usuario(89898, "goku", new DateOnly(2000, 04, 20), "Estudiante", plan)
            };
            List<Registro> listaRegistros = new List<Registro>();
            listaRegistros.Add(registro);
            listaRegistros.Add(registro);
            tarifador.addListaUsuarios(listaUsuarios);
            tarifador.aniadirRegistroAUsuario(listaUsuarios[0].ci, listaRegistros[0]);
            tarifador.aniadirRegistroAUsuario(listaUsuarios[1].ci, listaRegistros[1]);

            List<IDescuento> descuentos = new List<IDescuento>(){
                new DescuentoCumple(),
                new DescuentoEstudiante()
            };
            tarifador.tarifar(descuentos);
            var output = new StringWriter();
            Console.SetOut(output);
            tarifador.mostrarMontoPorUsuario();
            Assert.That(output.ToString(), Is.EqualTo(string.Format(listaUsuarios[0].nombreCompleto + ", deuda: " + "14,7" + "\r\n" +
                                                                    listaUsuarios[1].nombreCompleto + ", deuda: " + "17,85" + "\r\n")));
        }

        [Test]
        public void tarifarConListaDeDescuentosVacia()
        {
            IVehiculo vehiculo = new Scooter();
            Registro registro = new Registro(vehiculo, 30);
            IPlan plan = new PlanRegular();
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
            new Usuario(1, "Pedro", today, "plomero", plan),
            new Usuario(89898, "goku", new DateOnly(2000, 04, 20), "Estudiante", plan)
            };
            List<Registro> listaRegistros = new List<Registro>();
            listaRegistros.Add(registro);
            listaRegistros.Add(registro);
            tarifador.addListaUsuarios(listaUsuarios);
            tarifador.aniadirRegistroAUsuario(listaUsuarios[0].ci, listaRegistros[0]);
            tarifador.aniadirRegistroAUsuario(listaUsuarios[1].ci, listaRegistros[1]);

            List<IDescuento> descuentos = new List<IDescuento>(){
            };
            tarifador.tarifar(descuentos);
            var output = new StringWriter();
            Console.SetOut(output);
            tarifador.mostrarMontoPorUsuario();
            Assert.That(output.ToString(), Is.EqualTo(string.Format(listaUsuarios[0].nombreCompleto + ", deuda: " + "21" + "\r\n" +
                                                                    listaUsuarios[1].nombreCompleto + ", deuda: " + "21" + "\r\n")));
        }
        [Test]
        public void mostrarMontoPorUsuarioTest(){
            double valor = 13.8;
            String str = valor.ToString();
            IVehiculo vehiculo = new Bicicleta();
            Registro registro = new Registro(vehiculo, 20);
            IPlan plan = new PlanMensual();
            DateOnly fechaNacimiento = new DateOnly(2000,12,1);
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
                new Usuario(1, "Pedro picapiedra", new DateOnly(2000, 08, 11), "plomero", plan),
                new Usuario(89898, "goku", new DateOnly(2000, 04, 20), "plomero", plan)
            };
            List<Registro> listaRegistros = new List<Registro>();
            Tarifador tarifadortest = new Tarifador();
            tarifadortest.addListaUsuarios(listaUsuarios);
            tarifadortest.aniadirRegistroAUsuario(1, registro);
            List<IDescuento> descuentos = new List<IDescuento>(){
                new DescuentoCumple(),
                new DescuentoEstudiante()
            };
            tarifadortest.tarifar(descuentos,impuesto);
            var output = new StringWriter();
            Console.SetOut(output);
            tarifadortest.mostrarMontoPorUsuario();
            Assert.That(output.ToString(), Is.EqualTo(string.Format(listaUsuarios[0].nombreCompleto + ", deuda: " + str + "\r\n" +
                                                                    listaUsuarios[1].nombreCompleto + ", deuda: " + "0" + "\r\n")));
        }
    }
}