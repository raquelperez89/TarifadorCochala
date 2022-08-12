using NUnit.Framework;
namespace TarifadorTests
{
    public class RegistroTest
    {
        private Registro registro;
        private IVehiculo vehiculo = new Scooter();
        private int minutosDeUso = 10;
        
        [SetUp]
        public void Setup()
        {

            registro = new Registro(vehiculo, minutosDeUso);
        }

        [Test]
        public void calcularMontoRegistro()
        {
            PlanRegular planRegular = new PlanRegular();
            Usuario usuario = new Usuario(1, "Pedro picapiedra", new DateOnly(2000, 08, 10), "plomero", planRegular);
            List<IDescuento> descuentos = new List<IDescuento>(){
            new DescuentoCumple(),
            new DescuentoEstudiante()};
            try
            {
                registro.calcularMontoRegistro(usuario, descuentos);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}