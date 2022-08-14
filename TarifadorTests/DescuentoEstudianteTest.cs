
namespace DescuentosTests
{
    [TestFixture]
    public class DescuentoEstudianteTest
    {
        private DescuentoEstudiante descuentoEstudiante;
        private IPlan plan;
        [SetUp]
        public void Setup()
        {
            descuentoEstudiante = new DescuentoEstudiante();
            plan = new PlanMensual();
        }

        [TestCase("Estudiante", 0.15)]
        [TestCase("estudiante", 0)]
        [TestCase("plomero", 0)]
        [TestCase(null, 0)]
        public void getPorcentajeDescuentoTest(string ocupacion, double expected)
        {
            DateOnly fechaNacimiento = new DateOnly(2000,08, 11);
            Usuario usuario = new Usuario(89898, "Test", fechaNacimiento, ocupacion, plan);
            double result = descuentoEstudiante.getPorcentajeDescuento(usuario);
            Assert.AreEqual(result, expected);
        }
    }
}