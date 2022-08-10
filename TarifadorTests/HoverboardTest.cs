using hoverboardN;

namespace TarifadorTests
{
    [TestFixture]
    public class HoverboardTest
    {
        private Hoverboard hoverboard;

        [SetUp]
        public void SetUp()
        {
            hoverboard = new Hoverboard();
        }

        [Test]
        public void getTarifaAgregadaTest()
        {
            double result = hoverboard.getTarifaAgregada();

            Assert.AreEqual(result, 0.25);
        }
    }
}