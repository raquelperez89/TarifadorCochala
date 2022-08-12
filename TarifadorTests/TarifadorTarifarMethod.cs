using NUnit.Framework;

namespace TarifadorTests
{
    public class TarifadorTarifarMethod
    {
        private Tarifador tarifador;
        [SetUp]
        public void Setup()
        {
            tarifador = new Tarifador();
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
                tarifador.tarifar(descuentos);
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
                tarifador.tarifar(descuentos);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}