﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
    public class NotariaBC
    {
        public List<Notaria> getNotaria()
        {
            List<Notaria> lcorreos = new NotariaDAC().getNotaria();
            return lcorreos;
        }

    }
}
