global using IPlanN;
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
        }
    }
}