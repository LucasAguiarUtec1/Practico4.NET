using System.Text.Json.Serialization;

namespace Shared
{
    public class Persona
    {
        public string Nombre { get; set; } = "-- Sin Nombre --";

        public string Apellido { get; set; } = "";

        public string direccion { get; set; }

        public int telefono { get; set; }

        public DateTime fechaNa { get; set; }

        public string documento { get; set; }

        public void Print()
        {
            Console.WriteLine("-- Persona --");
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Documento: " + documento);
        }

        public void PrintTable()
        {
            Console.WriteLine("| " + documento + " | " + Nombre + " | " +" | " + telefono + " | " + fechaNa +  " | " + direccion + " |");
        }
    }
}