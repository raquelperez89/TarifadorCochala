
namespace TarifadorTests
{
    [TestFixture]
    public class DescuentoEstudianteTest
    {
        private DescuentoEstudiante descuentoEstudiante;
        [SetUp]
        public void Setup()
        {
            descuentoEstudiante = new DescuentoEstudiante();
        }

        [TestCase("Estudiante", 0.15)]
        [TestCase("estudiante", 0)]
        [TestCase("plomero", 0)]
        [TestCase(null, 0)]
        public void getPorcentajeDescuentoTest(string ocupacion, double expected)
        {
            IPlan plan = new PlanMensual();
            DateOnly fechaNacimiento = new DateOnly(2000,08, 11);
            Usuario usuario = new Usuario(89898, "Test", fechaNacimiento, ocupacion, plan);
            double result = descuentoEstudiante.getPorcentajeDescuento(usuario);
            Assert.AreEqual(result, expected);
        }
    }
}