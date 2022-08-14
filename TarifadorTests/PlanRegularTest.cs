namespace PlanTests
{
    [TestFixture]
    public class PlanRegularTest
    {
        private IPlan plan;
        private IVehiculo vehiculo;

        [SetUp]
        public void SetUp()
        {
            plan = new PlanRegular();
          
        }
        

        [TestCase("Bicicleta",0.8)]
        [TestCase("Triciclo",0.7)]
        [TestCase("Scooter",0.7)]
        [TestCase("Hooverboard",0.75)]
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
        public void getNombrePlan()
        {
            string nombrePlan = plan.getNombrePlan();
            Assert.AreEqual("REGULAR", nombrePlan);
        }
    }
}