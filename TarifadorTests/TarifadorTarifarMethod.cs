namespace TarifadorTests
{
    public class TarifadorTarifarMethod
    {
        private Tarifador tarifador;
        private IImpuesto impuesto;
        [SetUp]
        public void Setup()
        {
            tarifador = new Tarifador();
            impuesto = new ImpuestoBoliviano();
        }

        [Test]
        public void tarifarConListaDeDescuentos()
        {
            List<IDescuento> descuentos = new List<IDescuento>(){
                new DescuentoCumple(),
                new DescuentoEstudiante()
            };
            try
            {
                tarifador.tarifar(descuentos, impuesto);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [Test]
        public void tarifarSinListaDeDescuentos()
        {
            List<IDescuento> descuentos = new List<IDescuento>(){
            };
            try
            {
                tarifador.tarifar(descuentos,impuesto);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}