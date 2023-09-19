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
    public class DAL_Veichulo_EF : IDAL_Veichulos
    {
        private DBContextCore _dbContext;

        public DAL_Veichulo_EF(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public DAL_Veichulo_EF()
        {
        }

        public List<Veichulo> Get()
        {
            return _dbContext.Veichulos.Select(v => new Veichulo { Marca = v.Marca, Matricula = v.Matricula, Modelo = v.Modelo }).ToList();
        }

        public Veichulo Get(string matricula)
        {
            var vEF = _dbContext.Veichulos.FirstOrDefault(v => v.Matricula == matricula);

            if(vEF != null) 
            {
                return new Veichulo
                {
                    Marca = vEF.Marca,
                    Matricula = matricula,
                    Modelo = vEF.Modelo,
                };
            }
            else
            {
                return null;
            }
        }

        public void Insert(Veichulo veichulo)
        {
            var vEF = new DataAccessLayer.EFModels.Veichulos
            {
                Marca = veichulo.Marca,
                Modelo = veichulo.Modelo,
                Matricula = veichulo.Matricula,
            };

            _dbContext.Veichulos.Add(vEF);
            _dbContext.SaveChanges();
        }

        public void Update(Veichulo veichulo)
        {
            var vEf = _dbContext.Veichulos.FirstOrDefault(v => v.Matricula == veichulo.Matricula);
            if (vEf != null)
            {
                vEf.Marca = veichulo.Marca;
                vEf.Modelo = veichulo.Modelo;
            }
        }

        public void Delete(string matricula)
        {
            var vEF = _dbContext.Veichulos.FirstOrDefault(v => v.Matricula == matricula);
            if (vEF != null)
            {
                _dbContext.Veichulos.Remove(vEF);
                _dbContext.SaveChanges();
            }
        }
    }
}
