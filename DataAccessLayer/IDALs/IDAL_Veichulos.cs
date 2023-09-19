﻿using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IDALs
{
    public interface IDAL_Veichulos
    {
        List<Veichulo> Get();

        Veichulo Get(string matricula);

        void Insert(Veichulo veichulo);

        void Update(Veichulo veichulo);

        void Delete(string matricula);
    }
}
