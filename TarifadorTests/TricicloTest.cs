using NUnit.Framework;

namespace TarifadorTests
{
    [TestFixture]
    public class TricicloTest
    {
        private Triciclo triciclo;

        [SetUp]
        public void SetUp()
        {
            triciclo = new Triciclo();
        }

        [Test]
        public void getTarifaAgregadaTest()
        {
            double result = triciclo.getTarifaAgregada();

            Assert.AreEqual(result, 0.20);
        }
    }
}