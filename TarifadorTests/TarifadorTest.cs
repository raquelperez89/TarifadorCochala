using TarifadorMain;
using UsuarioN;

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
            Usuario usuario = new Usuario(89898, "Juan", fechaNacimiento, "Estudiante", plan);
            tarifador.addUsuario(usuario);
            Assert.AreEqual(89898,tarifador.getListaUsuarios()[0].ci);
            Assert.AreEqual("Juan", tarifador.getListaUsuarios()[0].nombreCompleto);
            Assert.AreEqual(fechaNacimiento, tarifador.getListaUsuarios()[0].fechaNacimiento);
            Assert.AreEqual("Estudiante",tarifador.getListaUsuarios()[0].ocupacion);
            Assert.AreEqual(89898,tarifador.getListaUsuarios()[0].ci);
            Assert.IsInstanceOf(typeof(IPlan),tarifador.getListaUsuarios()[0].plan);

        }

        [Test]
        public void getListaUsuariosTest(){
            Assert.IsInstanceOf(typeof(List<Usuario>),tarifador.getListaUsuarios());

        }

        [Test]
        public void addListaUsuariosTest(){
            List<Usuario> listaUsuariosSinAgregar = this.tarifador.getListaUsuario();
            IPlan plan = new PlanMensual();
            DateOnly fechaNacimiento = new DateOnly(2000,12,1);
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
                new Usuario(8988, "Test2", fechaNacimiento, "Estudiante", plan)
            };
            tarifador.addListaUsuarios(listaUsuarios);
            Assert.AreNotEqual(listaUsuariosSinAgregar, this.tarifador.getListaUsuario());
        }

        [Test]
        public void tarifarTest(){
            List<Usuario> usuarios = new List<Usuario>();
        }
    }
}