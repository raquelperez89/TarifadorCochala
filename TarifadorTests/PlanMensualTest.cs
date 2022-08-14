
namespace PlanTests
{
    [TestFixture]
    public class PlanMensualTest
    {
        private IPlan plan;
        private IVehiculo vehiculo;

        [SetUp]
        public void SetUp()
        {
            plan = new PlanMensual();
          
        }
        
        [TestCase("Bicicleta",0.6)]
        [TestCase("Triciclo",0.5)]
        [TestCase("Scooter",0.5)]
        [TestCase("Hooverboard",0.55)]
        public void cobroTotalPorMinutoTest(String tipoVehiculo, double expected)
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
            double result = plan.cobroTotalPorMinuto(vehiculo);
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void getNombrePlanTest()
        {
            Assert.AreEqual(plan.getNombrePlan(),"MENSUAL");
        }
    }
}