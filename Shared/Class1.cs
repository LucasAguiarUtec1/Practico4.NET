using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Veichulo
    {
        public string Marca { get; set; } = "";
        
        public string Modelo { get; set; } = "";

        public string Matricula { get; set; } = "";

        public void print()
        {
            Console.WriteLine("-- Veichulo --");
            Console.WriteLine("Marca: " +  Marca);
            Console.WriteLine("Modelo: " +  Modelo);
            Console.WriteLine("Matricula: " +  Matricula);
        }

        public void printTable()
        {
            Console.WriteLine("| " + Marca + " | " +  Modelo + " | " + Matricula + " |");
        }
    }
}
