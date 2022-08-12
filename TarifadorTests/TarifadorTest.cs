using Moq;

namespace TarifadorTests
{
    [TestFixture]
    public class TarifadorTest
    {
        private Tarifador tarifador;

        [SetUp]
        public void SetUp()
        {
            tarifador = new Tarifador();
        }

        [Test]
        public void addUsuarioTest(){
            IPlan plan = new PlanMensual();
            DateOnly fechaNacimiento = new DateOnly(2000,12,1);
            Usuario usuario = new Usuario(89898, "Test", fechaNacimiento, "Estudiante", plan);
            tarifador.addUsuario(usuario);
        }

        [Test]
        public void addListaUsuariosTest(){
            List<Usuario> usuarios = new List<Usuario>();        
            tarifador.addListaUsuarios(usuarios);
        }

        [Test]
        public void tarifarTest(){
            List<Usuario> usuarios = new List<Usuario>();
            List<IDescuento> descuento = new List<IDescuento>();
            tarifador.tarifar(descuento);
        }
        [Test]
        public void aniadirRegistroAUsuarioTest(){
            IVehiculo vehiculo = new Bicicleta();
            Registro registro = new Registro(vehiculo, 30);
            IPlan plan = new PlanMensual();
            DateOnly fechaNacimiento = new DateOnly(2000,12,1);
            Usuario usuario = new Usuario(89898, "Test", fechaNacimiento, "Estudiante", plan);
            //tarifador.aniadirRegistroAUsuario(usuario.ci, registro);

            var mock = new Mock<Usuario>();

            var usuario1 = new Usuario(89898, "Test", fechaNacimiento, "Estudiante", plan);
            usuario1.agregarNuevoRegistro(registro);

            mock.Verify(x => usuario1.agregarNuevoRegistro(registro), Times.Never());
        }
        [Test]
        public void mostrarMontoPorUsuario(){
            tarifador.mostrarMontoPorUsuario();
        }
    }
}