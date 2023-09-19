// See https://aka.ms/new-console-template for more information
using Shared;
using DataAccessLayer.DALs;
using DataAccessLayer.IDALs;
using BusinessLayer.IBLs;
using BusinessLayer.BLs;
using PracticoClase1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Primera Aplicación con .NET");

IDAL_Personas _personas = new DAL_Personas_EF(new DataAccessLayer.DBContextCore());
IDAL_Veichulos _veichulos = new DAL_Veichulo_EF(new DataAccessLayer.DBContextCore());
IBL_Personas _personasBL = new BL_Personas(_personas);
IBL_Veichulos _veichulosBL = new BL_Veichulos(_veichulos);
Commands commands = new Commands(_personasBL, _veichulosBL);
UpdateDatabase();

Console.WriteLine("Comandos Posibles:");
Console.WriteLine("1 - Agregar Persona");
Console.WriteLine("2 - Listar Personas");
Console.WriteLine("3 - Eliminar Persona");
Console.WriteLine("4 - Actualizar Datos Persona");
Console.WriteLine("5 - Agregar Veichulo");
Console.WriteLine("6 - Listar Veichulos");
Console.WriteLine("7 - Eliminar Veichulo");
Console.WriteLine("8 - Salir");

Console.Write("Ingrese Comando> ");
string command = Console.ReadLine();

while(command != "8")
{
    try
    {
        switch (command)
        {
            case "1":
                commands.AddPersona();
                break;
            case "2":
                commands.ListPersonas();
                break;
            case "3":
                commands.RemovePersona();
                break;
            case "4":
                commands.UpdatePersona();
                break;
            case "5":
                commands.AddVeichulo();
                break;
            case "6":
                commands.ListVeichulos();
                break;
            case "7":
                commands.RemoveVeichulo();
                break;
            default:
                Console.WriteLine("Comando no reconocido");
                break;
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine("ERROR> " + ex.Message);
    }
    finally
    {
        Console.Write("Ingrese Comando> ");
        command = Console.ReadLine();
    }
}

Console.WriteLine("Gracias por usar la aplicación");

void UpdateDatabase()
{
    using (var context = new DataAccessLayer.DBContextCore())
    {
        context?.Database.Migrate();
    }
}