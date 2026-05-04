
        Console.WriteLine("SISTEMA DE VEHÍCULOS ");

        Camion camion = new Camion("Volvo", 15);

        
        camion.Encender();       
        camion.Rodar();          
        camion.CargarMercancia(); 

        Console.ReadKey();
   

class Vehiculo
{
    public string Marca { get; set; }

    public Vehiculo(string marca)
    {
        Marca = marca;
    }

    public virtual void Encender()
    {
        Console.WriteLine($"El vehículo {Marca} está encendido");
    }
}

class Terrestre : Vehiculo
{
    public Terrestre(string marca) : base(marca)
    {
    }

    public virtual void Rodar()
    {
        Console.WriteLine($"El vehículo {Marca} está rodando");
    }
}

class Camion : Terrestre
{
    public int CapacidadToneladas { get; set; }

    public Camion(string marca, int capacidad) : base(marca)
    {
        CapacidadToneladas = capacidad;
    }

    public void CargarMercancia()
    {
        Console.WriteLine($"El camión {Marca} está cargando {CapacidadToneladas} toneladas");
    }
}
