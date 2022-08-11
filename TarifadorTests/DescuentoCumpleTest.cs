global using UsuarioN;

namespace TarifadorTests
{
    [TestFixture]
    public class DescuentoCumpleTest
    {
        private DescuentoCumple descuentoCumple;
        [SetUp]
        public void Setup()
        {
            descuentoCumple = new DescuentoCumple();
        }

        [Test]
        public void getPorcentajeDescuentoTest()
        {
            IPlan plan = new PlanMensual();
            DateOnly fechaNacimiento = new DateOnly(2000,12,1);
            Usuario usuario = new Usuario(89898, "Test", fechaNacimiento, "Estudiante", plan);
            double result = descuentoCumple.getPorcentajeDescuento(usuario);
            Assert.AreEqual(result, 0);
        }
    }
}