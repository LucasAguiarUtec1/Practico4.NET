using BusinessLayer.BLs;
using BusinessLayer.IBLs;
using Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PracticoClase1
{
    public class Commands
    {
        IBL_Personas _personasBL;
        IBL_Veichulos _veichulosBL;

        public Commands(IBL_Personas personasBL, IBL_Veichulos veichulosBL)
        {
            _personasBL = personasBL;
            _veichulosBL = veichulosBL;

        }

        public void AddPersona()
        {
            // Pedimos los datos de la pesona.
            Persona persona = new Persona();
            Console.WriteLine("Ingrese el nombre de la persona: ");
            persona.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese los Apellidos de la persona");
            persona.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese el documento de la persona: ");
            persona.documento = Console.ReadLine();

            Console.Write("Ingrese la fecha de nacimiento (YYYY-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime fechaNacimiento))
            {
                persona.fechaNa = fechaNacimiento;
            }
            else
            {
                Console.WriteLine("Formato de fecha no válido.");
            }

            Console.WriteLine("Ingrese direccion");
            persona.direccion = Console.ReadLine();

            Console.WriteLine("Ingrese Telofono");
            persona.telefono = int.Parse(Console.ReadLine());

            _personasBL.Insert(persona);

            _personasBL.Get(persona.documento).Print();
            Console.ReadLine();
            Console.Clear();
        }

        public void ListPersonas()
        {
            List<Persona> personas = _personasBL.Get();

            Console.WriteLine("Listado de personas:");
            Console.WriteLine("| Documento | Nombre | Telefono | Fecha Nacimiento | Direccion|");

            foreach (Persona persona in personas)
            {
                persona.PrintTable();
            }
        }

        public void RemovePersona()
        {
            Console.WriteLine("Ingrese el documento de la persona a eliminar: ");
            string documento = Console.ReadLine();

            _personasBL.Delete(documento);

            Console.WriteLine("Persona eliminada correctamente.");
        }

        public void UpdatePersona()
        {
            Console.WriteLine("-- Actualizar Datos --");
            Persona persona = new Persona();
            Console.WriteLine("Ingrese el documento de la persona a actualizar: ");
            persona.documento = Console.ReadLine();
            
            Console.WriteLine("Ingrese el nombre de la persona: ");
            persona.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese los Apellidos de la persona");
            persona.Apellido = Console.ReadLine();

            Console.Write("Ingrese la fecha de nacimiento (YYYY-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime fechaNacimiento))
            {
                persona.fechaNa = fechaNacimiento;
            }
            else
            {
                Console.WriteLine("Formato de fecha no válido.");
            }

            Console.WriteLine("Ingrese direccion");
            persona.direccion = Console.ReadLine();

            Console.WriteLine("Ingrese Telofono");
            persona.telefono = int.Parse(Console.ReadLine());

            _personasBL.Update(persona);
            Console.WriteLine("Datos Actualizados");
            Console.ReadLine();
        }

        public void AddVeichulo()
        {
            Veichulo veichulo = new Veichulo();
            Console.WriteLine("Ingrese La Marca Del Veichulo");
            veichulo.Marca = Console.ReadLine();

            Console.WriteLine("Ingrese El Modelo Del Veichulo");
            veichulo.Modelo = Console.ReadLine();

            Console.WriteLine("Ingrese La Matricula del Veichulo");
            veichulo.Matricula = Console.ReadLine();

            _veichulosBL.Insert(veichulo);

            _veichulosBL.Get(veichulo.Matricula).print();

            Console.WriteLine("Veichulo registrado Exitosamente");
        }

        public void UpdateVeichulo()
        {
            Veichulo veichulo = new Veichulo();

            Console.WriteLine("Ingrese La Matricula del Veichulo A Actualizar");
            veichulo.Matricula = Console.ReadLine();

            Console.WriteLine("Ingrese La Marca Del Veichulo");
            veichulo.Marca = Console.ReadLine();

            Console.WriteLine("Ingrese El Modelo Del Veichulo");
            veichulo.Modelo = Console.ReadLine();
           
            _veichulosBL.Update(veichulo);

            Console.WriteLine("Veichulo Actualizado Exitosamente");
        }

        public void RemoveVeichulo()
        {
            Console.WriteLine("Ingrese La Matricula Del Veichulo A Eliminar");
            string mat = Console.ReadLine();

            _veichulosBL.Delete(mat);

            Console.WriteLine("Veichulo Eliminado Exitosamente");
        }

        public void ListVeichulos()
        {
            List<Veichulo> veichulos = _veichulosBL.Get();

            Console.WriteLine("Listado De Veichulos");
            Console.WriteLine("| Marca | Modelo | Matricula|");
            
            foreach(Veichulo ve in veichulos)
            {
                ve.printTable();
            }
        }
    }
}
