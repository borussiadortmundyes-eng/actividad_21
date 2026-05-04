
using System;
using System.Collections.Generic;


        Dictionary<int, Usuario> usuarios = new Dictionary<int, Usuario>();
        int opcion;
Console.WriteLine("Bienvenido al sistema de gestión de usuarios");
do
        {
            opcion = Atajos.Opcion(
                "1) Agregar Administrador",
                "2) Agregar Docente",
                "3) Agregar Estudiante",
                "4) Mostrar usuarios",
                "5) Buscar por ID",
                "6) Eliminar usuario",
                "7) Salir"
            );

            switch (opcion)
            {
                case 1:
                    AgregarUsuario(usuarios, Atajos.CrearAdmin());
                    break;

                case 2:
                    AgregarUsuario(usuarios, Atajos.CrearDocente());
                    break;

                case 3:
                    AgregarUsuario(usuarios, Atajos.CrearEstudiante());
                    break;

                case 4:
                    Console.WriteLine("\nLISTA DE USUARIOS ");
                    foreach (var u in usuarios.Values)
                    {
                        u.Acceso();
                    }
                    Console.ReadKey();
                    break;

                case 5:
                    int buscar = Atajos.ValidarEntero("Ingrese ID a buscar:");
                    if (usuarios.ContainsKey(buscar))
                        usuarios[buscar].Acceso();
                    else
                        Console.WriteLine("Usuario no encontrado");

                    Console.ReadKey();
                    break;

                case 6:
                    int eliminar = Atajos.ValidarEntero("Ingrese ID a eliminar:");
                    if (usuarios.Remove(eliminar))
                        Console.WriteLine("Usuario eliminado");
                    else
                        Console.WriteLine("No existe ese ID");

                    Console.ReadKey();
                    break;

            }

        } while (opcion != 7);
    

    static void AgregarUsuario(Dictionary<int, Usuario> usuarios, Usuario nuevo)
    {
        if (usuarios.ContainsKey(nuevo.ID))
        {
            Console.WriteLine("Ese ID ya existe");
        }
        else
        {
            usuarios.Add(nuevo.ID, nuevo);
            Console.WriteLine("Usuario agregado correctamente");
        }
        Console.ReadKey();
    }

class Usuario
{
    private int id;
    private string nombre;
    private int edad;

    public Usuario(int id, string nombre, int edad)
    {
        ID = id;
        Nombre = nombre;
        Edad = edad;
    }

    public int ID
    {
        get => id;
        set
        {
            if (value > 0)
                id = value;
            else
                Console.WriteLine("ID inválido");
        }
    }

    public string Nombre
    {
        get => nombre;
        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 3)
                nombre = value;
            else
                Console.WriteLine("Nombre inválido");
        }
    }

    public int Edad
    {
        get => edad;
        set
        {
            if (value > 15)
                edad = value;
            else
                Console.WriteLine("Edad inválida");
        }
    }

    public virtual void Acceso()
    {
        Console.WriteLine($"{ID} - {Nombre} tiene acceso básico");
    }
}
class Administrador : Usuario
{
    private string colegiado;

    public Administrador(int id, string nombre, int edad, string colegiado)
        : base(id, nombre, edad)
    {
        NumeroColegiado = colegiado;
    }

    public string NumeroColegiado
    {
        get => colegiado;
        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 3)
                colegiado = value;
            else
                Console.WriteLine("Colegiado inválido");
        }
    }

    public override void Acceso()
    {
        Console.WriteLine($"{ID} - {Nombre} acceso TOTAL (Administrador)");
    }
}
class Docente : Usuario
{
    private string colegiado;

    public Docente(int id, string nombre, int edad, string colegiado)
        : base(id, nombre, edad)
    {
        this.colegiado = colegiado;
    }

    public override void Acceso()
    {
        Console.WriteLine($"{ID} - {Nombre} acceso LIMITADO (Docente)");
    }
}
class Estudiante : Usuario
{
    private string carnet;

    public Estudiante(int id, string nombre, int edad, string carnet)
        : base(id, nombre, edad)
    {
        this.carnet = carnet;
    }

    public override void Acceso()
    {
        Console.WriteLine($"{ID} - {Nombre} NO tiene acceso (Estudiante)");
    }
}
class Atajos
{
    public static int ValidarEntero(string mensaje)
    {
        int valor;
        while (true)
        {
            Console.WriteLine(mensaje);
            if (int.TryParse(Console.ReadLine(), out valor) && valor > 0)
                return valor;

            Console.WriteLine("Número inválido");
        }
    }

    public static string ValidarString(string mensaje, int min)
    {
        string valor;
        while (true)
        {
            Console.WriteLine(mensaje);
            valor = Console.ReadLine();

            if (!string.IsNullOrEmpty(valor) && valor.Length > min)
                return valor;

            Console.WriteLine("Texto inválido");
        }
    }

    public static int Opcion(params string[] opciones)
    {
        int op;
        do
        {
            Console.Clear();
            foreach (var o in opciones)
                Console.WriteLine(o);

            op = ValidarEntero("Seleccione una opción");

        } while (op < 1 || op > opciones.Length);

        return op;
    }

    public static Administrador CrearAdmin()
    {
        int id = ValidarEntero("ID:");
        string nombre = ValidarString("Nombre:", 3);
        int edad = ValidarEntero("Edad:");
        string col = ValidarString("Colegiado:", 3);

        return new Administrador(id, nombre, edad, col);
    }

    public static Docente CrearDocente()
    {
        int id = ValidarEntero("ID:");
        string nombre = ValidarString("Nombre:", 3);
        int edad = ValidarEntero("Edad:");
        string col = ValidarString("Colegiado:", 3);

        return new Docente(id, nombre, edad, col);
    }

    public static Estudiante CrearEstudiante()
    {
        int id = ValidarEntero("ID:");
        string nombre = ValidarString("Nombre:", 3);
        int edad = ValidarEntero("Edad:");
        string carnet = ValidarString("Carnet:", 3);

        return new Estudiante(id, nombre, edad, carnet);
    }
}