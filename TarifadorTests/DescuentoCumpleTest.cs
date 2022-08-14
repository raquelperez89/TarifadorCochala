
namespace DescuentosTests
{
    [TestFixture]
    public class DescuentoCumpleTest
    {
        private DescuentoCumple descuentoCumple;
        private DateOnly today;
        private IPlan plan;
        [SetUp]
        public void Setup()
        {
            descuentoCumple = new DescuentoCumple();
            plan = new PlanMensual();
            today = DateOnly.FromDateTime(DateTime.Now);
        }

        [TestCase(04, 11)]
        [TestCase(01, 11)]
        [TestCase(09, 11)]
        [TestCase(02, 18)]
        public void getPorcentajeDescuentoTest(int mes, int dia)
        {
            DateOnly fechaNacimiento = new DateOnly(2000,mes,dia);
            Usuario usuario = new Usuario(89898, "Test", fechaNacimiento, "Estudiante", plan);
            double result = descuentoCumple.getPorcentajeDescuento(usuario);
            Assert.AreEqual(result, 0);
        }
        [Test]
        public void getPorcentajeDescuentoHoyTest()
        {
            DateOnly fechaNacimiento = new DateOnly(2000,today.Month,today.Day);
            Usuario usuario = new Usuario(89898, "Test", fechaNacimiento, "Estudiante", plan);
            double result = descuentoCumple.getPorcentajeDescuento(usuario);
            Assert.AreEqual(result, 0.30);
        }
    }
}