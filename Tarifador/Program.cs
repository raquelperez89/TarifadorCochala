
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        PlanRegular planRegular = new PlanRegular();
        PlanMensual planMensual = new PlanMensual();

        IVehiculo scooter = new Scooter();
        IVehiculo bicicleta = new Bicicleta();
        IVehiculo hoverboard = new Hoverboard();
        IVehiculo triciclo = new Triciclo();

        List<Registro> listaRegistros = new List<Registro>()
        {
            new Registro(scooter, 40),
            new Registro(bicicleta, 40),
            new Registro(triciclo, 40),
            new Registro(hoverboard, 40),
            new Registro(scooter, 40),
        };

        List<Usuario> listaUsuarios = new List<Usuario>()
        {
            new Usuario(1, "Pedro picapiedra", new DateOnly(2000, 08, 11), "plomero", planRegular),
            new Usuario(2, "goku", new DateOnly(2000, 04, 20), "Estudiante", planRegular),
            new Usuario(3, "juanito", new DateOnly(2000, 04, 20), "plomero", planMensual),
            new Usuario(4, "mafalda", new DateOnly(2000, 08, 11), "Estudiante", planRegular) 
        };
        

        string fileName = "TarifadorDatos.json";
        using FileStream createStream = File.Create(fileName);
        var options = new JsonSerializerOptions { WriteIndented = true };
        await JsonSerializer.SerializeAsync(createStream, listaUsuarios, options);

        await createStream.DisposeAsync();

        //Console.WriteLine(File.ReadAllText(fileName));
/*
        string fileNameread = "TarifadorDatos.json";
        string jsonString = File.ReadAllText(fileNameread);
        List<Usuario> weatherForecast = JsonSerializer.Deserialize<List<Usuario>>(jsonString)!;

        Console.WriteLine($"ci: {weatherForecast[1].nombreCompleto}");

*/
        Tarifador tarifador = new Tarifador();
        List<IDescuento> descuentos = new List<IDescuento>(){
            new DescuentoCumple(),
            new DescuentoEstudiante()
        };

        tarifador.addListaUsuarios(listaUsuarios);

        tarifador.aniadirRegistroAUsuario(1,listaRegistros[0]);
        tarifador.aniadirRegistroAUsuario(2,listaRegistros[1]);
        tarifador.aniadirRegistroAUsuario(2,listaRegistros[3]);
        tarifador.aniadirRegistroAUsuario(3,listaRegistros[2]);
        tarifador.aniadirRegistroAUsuario(4,listaRegistros[4]);
        tarifador.tarifar(descuentos);
        tarifador.mostrarMontoPorUsuario();


         
    }
    
}
