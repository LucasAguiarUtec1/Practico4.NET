using DataAccessLayer.IDALs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs
{
    public class DAL_Personas_EF : IDAL_Personas
    {
        private DBContextCore _dbContext;

        public DAL_Personas_EF(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string documento)
        {
            var p = _dbContext.Personas.FirstOrDefault(p => p.Documento == documento);

            if (p != null)
            {
                _dbContext.Personas.Remove(p);
                _dbContext.SaveChanges();
            }
        }

        public List<Persona> Get()
        {
            return _dbContext.Personas
                             .Select(p => new Persona { documento = p.Documento, Nombre = p.Nombres, Apellido = p.Apellidos, direccion = p.direccion, fechaNa = p.fechaNacimiento, telefono = p.Telefono })
                             .ToList();
        }

        public Persona Get(string documento)
        {
            var pEf = _dbContext.Personas.FirstOrDefault(p => p.Documento == documento);
            if (pEf != null)
            {
                return new Persona
                {
                    documento = pEf.Documento,
                    Nombre = pEf.Nombres,
                    fechaNa = pEf.fechaNacimiento,
                    telefono = pEf.Telefono,
                    Apellido = pEf.Apellidos,
                };
            }
            return null;
        }

        public void Insert(Persona persona)
        {
            var p = new DataAccessLayer.EFModels.Personas
            {
                Nombres = persona.Nombre,
                Apellidos = persona.Apellido,
                direccion = persona.direccion,
                Documento = persona.documento,
                fechaNacimiento = persona.fechaNa,
                Telefono = persona.telefono,
            };
            _dbContext.Personas.Add(p);
            _dbContext.SaveChanges();
        }

        public void Update(Persona persona)
        {
            var entidadExistente = _dbContext.Personas.FirstOrDefault(p => p.Documento == persona.documento);

            if (entidadExistente != null)
            {
                entidadExistente.Nombres = persona.Nombre;
                entidadExistente.Apellidos = persona.Apellido;
                entidadExistente.direccion = persona.direccion;
                entidadExistente.fechaNacimiento = persona.fechaNa;
                entidadExistente.Telefono = persona.telefono;

                _dbContext.Entry(entidadExistente).State = EntityState.Modified;

                _dbContext.SaveChanges();
            }
            else
            {
                return;
            }
        }
    }
}
