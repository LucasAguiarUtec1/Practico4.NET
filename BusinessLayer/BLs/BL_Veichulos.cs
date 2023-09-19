using BusinessLayer.IBLs;
using DataAccessLayer.EFModels;
using DataAccessLayer.IDALs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BLs
{
    public class BL_Veichulos : IBL_Veichulos
    {
        private IDAL_Veichulos _veichulos;

        public BL_Veichulos(IDAL_Veichulos veichulos)
        {
            _veichulos = veichulos;
        }

        public List<Veichulo> Get()
        {
            return _veichulos.Get();
        }

        public Veichulo Get(string matricula)
        {
            return _veichulos.Get(matricula);
        }

        public void Insert(Veichulo veichulo)
        {
            _veichulos.Insert(veichulo);
        }

        public void Update(Veichulo veichulo)
        {
            _veichulos.Update(veichulo);
        }

        public void Delete(string matricula)
        {
            _veichulos.Delete(matricula);
        }
    }
}
