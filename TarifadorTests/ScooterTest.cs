using NUnit.Framework;

namespace TarifadorTests
{
    public class ScooterTest
    {
        private Scooter scooter;
        [SetUp]
        public void Setup()
        {
            scooter = new Scooter();
        }

        [Test]
        public void getTarifaAgregadaTest()
        {
            double result = scooter.getTarifaAgregada();
            Assert.AreEqual(result,0.20);
        }
    }
}