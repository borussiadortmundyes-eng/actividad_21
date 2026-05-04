using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(" PLATAFORMA EDUCATIVA n");

      
        Alumno alumno = new Alumno("Oscar", "A001");
        Profesor profesor = new Profesor("Carlos", "Matemática");
        Coordinador coordinador = new Coordinador("Laura", "Académico");

      
        alumno.IniciarSesion();
        profesor.IniciarSesion();
        coordinador.IniciarSesion();

        Console.WriteLine();

       
        alumno.Estudiar();
        profesor.Ensenar();
        coordinador.Supervisar();

        Console.ReadKey();
    }
}

class Usuario
{
    public string Nombre { get; set; }

    public Usuario(string nombre)
    {
        Nombre = nombre;
    }

    public virtual void IniciarSesion()
    {
        Console.WriteLine($"{Nombre} ha iniciado sesión");
    }
}

class Alumno : Usuario
{
    public string Carnet { get; set; }

    public Alumno(string nombre, string carnet) : base(nombre)
    {
        Carnet = carnet;
    }

    public void Estudiar()
    {
        Console.WriteLine($"{Nombre} está estudiando (Carnet: {Carnet})");
    }
}
class Profesor : Usuario
{
    public string Curso { get; set; }

    public Profesor(string nombre, string curso) : base(nombre)
    {
        Curso = curso;
    }

    public void Ensenar()
    {
        Console.WriteLine($"{Nombre} está enseñando {Curso}");
    }
}class Coordinador : Usuario
{
    public string Area { get; set; }

    public Coordinador(string nombre, string area) : base(nombre)
    {
        Area = area;
    }

    public void Supervisar()
    {
        Console.WriteLine($"{Nombre} supervisa el área {Area}");
    }
}

