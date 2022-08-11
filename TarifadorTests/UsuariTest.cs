using tarifador;
using NUnit.Framework;

namespace TarifadorTests
{
    [TestFixture]
    class UsuariTest
    {
        private Usuario usuario;

        [SetUp]
        public void SetUp()
        {
            IPlan planRegular = new PlanRegular();
            usuario =  new Usuario(2, "goku", new DateOnly(2000, 04, 20), "Estudiante", planRegular);
        }

        [Test]
        public void getTarifaAgregadaTest()
        {
            double result = bicicleta.getTarifaAgregada();

            Assert.AreEqual(result, 0.30);
        }
    }
}