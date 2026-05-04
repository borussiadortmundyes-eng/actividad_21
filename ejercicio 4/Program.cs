using System;


        Console.WriteLine(" SISTEMA DE AUTENTICACIÓN ");

        SistemaSeguridad sistema = new SistemaSeguridad();

       Console.WriteLine("escirba el cargo del usuario:");
string cargo = Console.ReadLine();
Console.WriteLine("escriba calve de acceso");
string clave = Console.ReadLine();
sistema.Login(cargo, clave);

        sistema.RegistrarAccion("Inicio de sesión exitoso");

        Console.ReadKey();
 

interface IAutenticacion
{
    void Login(string usuario, string contraseña);
}

interface IAuditoria
{
    void RegistrarAccion(string accion);
}

class SistemaSeguridad : IAutenticacion, IAuditoria
{
    public void Login(string usuario, string contraseña)
    {
        if (usuario == "admin" && contraseña == "1234")
        {
            Console.WriteLine(" Acceso concedido");
        }
        else
        {
            Console.WriteLine(" Acceso denegado");
        }
    }

    public void RegistrarAccion(string accion)
    {
        Console.WriteLine($"[AUDITORÍA] {accion} - {DateTime.Now}");
    }
}