using bicicleta;
using NUnit.Framework;

namespace TarifadorTests
{
    [TestFixture]
    public class BicicletaTest
    {
        private Bicicleta bicicleta;

        [SetUp]
        public void SetUp()
        {
            bicicleta = new Bicicleta();
        }

        [Test]
        public void getTarifaAgregadaTest()
        {
            double result = bicicleta.getTarifaAgregada();

            Assert.AreEqual(result, 0.30);
        }
    }
}