global using UsuarioN;

namespace TarifadorTests
{
    [TestFixture]
    public class DescuentoCumpleTest
    {
        private DescuentoCumple descuentoCumple;
        private DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        [SetUp]
        public void Setup()
        {
            descuentoCumple = new DescuentoCumple();
        }

        [TestCase(08, 11, 0.3)]
        [TestCase(01, 11, 0)]
        [TestCase(08, 11, 0.3)]
        [TestCase(08, 18, 0)]
        public void getPorcentajeDescuentoTest(int mes, int dia, double expected)
        {
            IPlan plan = new PlanMensual();
            DateOnly fechaNacimiento = new DateOnly(2000,mes,dia);
            Usuario usuario = new Usuario(89898, "Test", fechaNacimiento, "Estudiante", plan);
            double result = descuentoCumple.getPorcentajeDescuento(usuario);
            Assert.AreEqual(result, expected);
        }
    }
}