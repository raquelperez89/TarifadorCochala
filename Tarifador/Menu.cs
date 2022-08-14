using System.Globalization;

public class Menu
{
    IImpuesto impuesto = new ImpuestoBoliviano();
    Tarifador tarifador = new Tarifador();
    List<IDescuento> descuentos = new List<IDescuento>(){
            new DescuentoCumple(),
            new DescuentoEstudiante()
        };
    private void mostrarPlanes()
    {
        Console.WriteLine("--------Planes-------");
        Console.WriteLine("1.- Plan Regular ");
        Console.WriteLine("2.- Plan Mensual ");
    }
    private IPlan obtenerPlan(int opcion)
    {
        switch (opcion)
        {
            case 1:
                PlanRegular planRegular = new PlanRegular();
                return planRegular;
            case 2:
                PlanMensual planMensual = new PlanMensual();
                return planMensual;
            default:
                return null;
        }
    }
    private IPlan elegirPlan()
    {
        IPlan planElegido;
        do
        {
            Console.WriteLine("Elegir el plan: ");
            mostrarPlanes();
            int opcionPlan = Convert.ToInt32(Console.ReadLine());
            planElegido = obtenerPlan(opcionPlan);
            Console.Clear();
        } while (planElegido == null);
        return planElegido;
    }

    private void agregarUsuario()
    {
        Console.WriteLine("--------Crear Usuario-------");
        int ci = ingresarCi();
        string nombreCompleto = ingresarNombreCompleto();
        var fechaNacimiento = ingresarFechaNacimiento();
        string ocupacion = ingresarOcupacion();
        IPlan planElegido = elegirPlan();
        Usuario usuario = new Usuario(ci, nombreCompleto, fechaNacimiento, ocupacion, planElegido);
        this.tarifador.addUsuario(usuario);
        usuario.mostrarInformacion();
    }

    private void mostrarVehiculo()
    {
        Console.WriteLine("1.- Bicicleta ");
        Console.WriteLine("2.- Hoverboard ");
        Console.WriteLine("3.- Scooter ");
        Console.WriteLine("4.- Triciclo ");
    }
    private IVehiculo obtenerVehiculo(int opcion)
    {
        switch (opcion)
        {
            case 1:
                Bicicleta bicicleta = new Bicicleta();
                return bicicleta;
            case 2:
                Hoverboard hoverboard = new Hoverboard();
                return hoverboard;
            case 3:
                Scooter scooter = new Scooter();
                return scooter;
            case 4:
                Triciclo triciclo = new Triciclo();
                return triciclo;
            default:
                return null;
        }
    }
    private IVehiculo elegirVehiculo()
    {
        IVehiculo vehiculoElegido;
        do
        {
            Console.WriteLine("Elegir el Vehiculo: ");
            mostrarVehiculo();
            int opcionVehiculo = Convert.ToInt32(Console.ReadLine());
            vehiculoElegido = obtenerVehiculo(opcionVehiculo);
            Console.Clear();
        } while (vehiculoElegido == null);
        return vehiculoElegido;
    }
    public int ingresarMinutos()
    {
        String input;
        int minutos;
        Boolean isParsed = true;
        do
        {
            if (!isParsed)
            {
                Console.WriteLine("Debe ser entero");
            }
            Console.WriteLine("Introduzca minutos: ");
            input = Console.ReadLine();
            isParsed = int.TryParse(input, out minutos);
            Console.Clear();
        } while (minutos < 0 || !isParsed);
        return minutos;
    }

    private int ingresarCiParaRegistro()
    {
        String input;
        int ci;
        Boolean isParsed = true;
        Console.WriteLine("Ingresar número de CI al cual añadir el registro: ");
        do
        {
            if (!isParsed)
            {
                Console.WriteLine("El ci debe ser entero");
            }
            Console.WriteLine("Introduzca Ci: ");
            input = Console.ReadLine();
            isParsed = int.TryParse(input, out ci);
            Console.Clear();
        } while (esCiValido(ci) == true || isParsed == false);
        return ci;
    }
    private void agregarRegistro()
    {
        Console.WriteLine("--------Crear Registro-------");
        IVehiculo vehiculoElegido = elegirVehiculo();
        int minutos = ingresarMinutos();
        Registro registro = new Registro(vehiculoElegido, minutos);
        Console.WriteLine("Lista de usuarios: ");
        tarifador.getListaUsuarios().ForEach(usuario => usuario.mostrarInformacion());
        int ci = ingresarCiParaRegistro();
        tarifador.aniadirRegistroAUsuario(ci, registro);
    }

    private Boolean manejadorDeOpciones(int opcion)
    {
        switch (opcion)
        {
            case 1:
                agregarUsuario();
                break;
            case 2:
                agregarRegistro();
                break;
            case 3:
                tarifador.tarifar(descuentos, impuesto);
                break;
            case 4:
                tarifador.mostrarMontoPorUsuario();
                break;
            case 0:
                break;
            default:
                return false;
        }
        return true;
    }

    public void mostrarMenu()
    {
        Boolean isParsed, isValidOption;
        String input;
        int opcion;
        do
        {
            Console.WriteLine("--------MENU-------");
            Console.WriteLine("1.- Agregar Usuario");
            Console.WriteLine("2.- Agregar Registro");
            Console.WriteLine("3.- Tarifar usuarios");
            Console.WriteLine("4.- Mostrar usuarios");
            Console.WriteLine("0.- Salir");
            input = Console.ReadLine();
            isParsed = int.TryParse(input, out opcion);
            Console.Clear();
            isValidOption = manejadorDeOpciones(opcion);
        } while (isValidOption == false || isParsed == false || opcion != 0);
    }
    public Boolean esFechaDeNacimientoValida(int dia, int mes, int anio)
    {
        Boolean res = true;
        DateTime today = DateTime.Now;
        if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
        {
            if (dia < 1 || dia > 31)
            {
                res = false;
            }
        }
        else if (mes == 2)
        {
            if (dia < 1 || dia > 28)
            {
                res = false;
            }
        }
        else
        {
            if (dia < 1 || dia > 30)
            {
                res = false;
            }
        }
        if (anio < 1900 || anio > today.Year - 18)
        {
            res = false;
        }
        return res;
    }


    public Boolean esCiValido(int ci)
    {
        Usuario usuario = tarifador.getListaUsuarios().Find(usuario => usuario.ci == ci);
        if (usuario == null) return true;
        return false;
    }

    public int ingresarCi()
    {
        String input;
        int ci;
        Boolean isParsed = true;
        do
        {
            if (!isParsed)
            {
                Console.WriteLine("El ci debe ser entero");
            }
            Console.WriteLine("Introduzca Ci: ");
            input = Console.ReadLine();
            isParsed = int.TryParse(input, out ci);
            Console.Clear();
        } while (esCiValido(ci) == false || isParsed == false);
        return ci;
    }
    public DateOnly ingresarFechaNacimiento()
    {
        int diaNacimiento, mesNacimiento, anioNacimiento;
        string diaNacimientoInput, mesNacimientoInput, anioNacimientoInput;
        Boolean isValid = false;
        Boolean isValidDia, isValidMes, isValidAnio;
        do
        {
            if (!isValid)
            {
                Console.WriteLine("La fecha de nacimiento debe ser valido por ej. 12/6/1998 y el usuario debe ser mayor de edad");
            }

            Console.WriteLine("Introduzca Dia de nacimiento: ");
            diaNacimientoInput = Console.ReadLine();
            isValidDia = int.TryParse(diaNacimientoInput, out diaNacimiento);

            Console.WriteLine("Introduzca Mes de nacimiento: ");
            mesNacimientoInput = Console.ReadLine();
            isValidMes = int.TryParse(mesNacimientoInput, out mesNacimiento);

            Console.WriteLine("Introduzca Año de nacimiento: ");
            anioNacimientoInput = Console.ReadLine();
            isValidAnio = int.TryParse(anioNacimientoInput, out anioNacimiento);
            if (isValidDia && isValidMes && isValidAnio)
            {
                isValid = esFechaDeNacimientoValida(diaNacimiento, mesNacimiento, anioNacimiento);
            }
        } while (isValid == false);
        return new DateOnly(anioNacimiento, mesNacimiento, diaNacimiento);

    }

    public string ingresarOcupacion()
    {
        string ocupacion;
        do
        {
            Console.WriteLine("Ocupacion: ");
            ocupacion = Console.ReadLine();
            Console.Clear();
        } while (!esOcupacionValida(ocupacion));
        return ocupacion;
    }

    public Boolean esOcupacionValida(string ocupacion)
    {
        if (ocupacion.All(char.IsDigit))
        {
            Console.WriteLine("Ingresar una ocupacion valida.");
            return false;
        }
        else
        {
            ocupacion = char.ToUpper(ocupacion[0]) + ocupacion.Substring(1);
            return true;
        }
    }
    public string ingresarNombreCompleto()
    {
        string nombreCompleto;
        do
        {
            Console.WriteLine("Introduzca Nombre Completo: ");
            nombreCompleto = Console.ReadLine();
            Console.Clear();
        } while (!esNombreCompletoValido(nombreCompleto));
        return nombreCompleto;
    }

    public Boolean esNombreCompletoValido(string nombreCompleto)
    {
        if (nombreCompleto.All(char.IsDigit))
        {
            Console.WriteLine("Ingrese un nombre valido.");
            return false;
        }
        else
        {
            nombreCompleto = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(nombreCompleto.ToLower());
            return true;
        }
    }

}
