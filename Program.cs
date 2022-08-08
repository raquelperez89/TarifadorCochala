class Program{
    static void Main(string[] args)
    {
        PlanRegular planRegular = new PlanRegular();
        PlanMensual planMensual = new PlanMensual();
        List<Usuario> listaUsuarios = new List<Usuario>()
        {
            new Usuario(1, "Pedro picapiedra", new DateOnly(2000, 04, 20), "plomero", planRegular),
            new Usuario(2, "goku", new DateOnly(2000, 04, 20), "estudiante", planRegular),
            new Usuario(3, "juanito", new DateOnly(2000, 04, 20), "plomero", planMensual),
            new Usuario(4, "mafalda", new DateOnly(2000, 04, 20), "estudiante", planRegular),
            new Usuario(5, "carlos", new DateOnly(2000, 04, 20), "plomero", planMensual),
            new Usuario(6, "Maria", new DateOnly(2000, 04, 20), "estudiante", planRegular),
            new Usuario(7, "Laura", new DateOnly(2000, 04, 20), "plomero", planMensual),
 
        };
        IVehiculo scooter = new Scooter();
        IVehiculo bicicleta = new Bicicleta();
        IVehiculo hoverboard = new Hoverboard();
        IVehiculo triciclo = new Triciclo();

        List<Registro> listaRegistros = new List<Registro>()
        {
            new Registro(1,scooter, 40),
            new Registro(2,bicicleta, 40),
            new Registro(3,triciclo, 40),
            new Registro(2,hoverboard, 40),
            new Registro(4,scooter, 40),
        };

        Tarifador tarifador = new Tarifador();
        tarifador.addListaRegistros(listaRegistros);
        tarifador.addListaUsuarios(listaUsuarios);
        tarifador.tarifar();
        tarifador.mostrarMontoPorUsuario();


         
    }
    
}
