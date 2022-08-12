namespace ImpuestosTests
{
    [TestFixture]
    public class ImpuestoBolivianoTest
    {
        private IImpuesto impuesto;

        [SetUp]
        public void SetUp()
        {
            impuesto = new ImpuestoBoliviano();
        }

        [Test]
        public void applicarImpuestoTest()
        {
            double monto = 25.50;
            double result = impuesto.applicarImpuesto(monto);

            Assert.AreEqual(result, 29.325);
        }
    }
}