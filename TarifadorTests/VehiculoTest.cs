namespace VehiculoTests
{
    [TestFixture]
    public class VehiculoTest
    {
        private IVehiculo vehiculo;

        [SetUp]
        public void SetUp()
        {

        }

        [TestCase("Bicicleta",0.3)]
        [TestCase("Triciclo",0.2)]
        [TestCase("Scooter",0.2)]
        [TestCase("Hooverboard",0.25)]
        public void getTarifaAgregadaTest(String tipoVehiculo, double expected)
        {
            switch (tipoVehiculo)
            {
                case "Bicicleta":
                    vehiculo = new Bicicleta();
                    break;
                case "Triciclo":
                    vehiculo = new Triciclo();
                    break;
                case "Scooter":
                    vehiculo = new Scooter();
                    break;
                case "Hooverboard":
                    vehiculo = new Hoverboard();
                    break;
                default:
                    break;
            }
            double result = vehiculo.getTarifaAgregada();
            Assert.AreEqual(result, expected);
        }
    }
}