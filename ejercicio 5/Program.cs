using System;
using System.Collections.Generic;

List<Persona> personas = new List<Persona>()
        {
            new Empleado("Carlos"),
            new Visitante("Ana"),
            new Seguridad("Luis")
        };

foreach (Persona persona in personas)
{
    Console.WriteLine("Nombre: " + persona.Nombre);
    Console.WriteLine("Tipo de acceso: " + persona.ObtenerAcceso());
    
}


class Persona
{
    public string Nombre { get; set; }

    public Persona(string nombre)
    {
        Nombre = nombre;
    }

    public virtual string ObtenerAcceso()
    {
        return "Acceso general";
    }
}

class Empleado : Persona
{
    public Empleado(string nombre) : base(nombre) { }

    public override string ObtenerAcceso()
    {
        return "Acceso a oficinas y áreas de trabajo";
    }
}

class Visitante : Persona
{
    public Visitante(string nombre) : base(nombre) { }

    public override string ObtenerAcceso()
    {
        return "Acceso limitado (solo áreas públicas)";
    }
}


class Seguridad : Persona
{
    public Seguridad(string nombre) : base(nombre) { }

    public override string ObtenerAcceso()
    {
        return "Acceso total a todas las áreas";
    }
}


       