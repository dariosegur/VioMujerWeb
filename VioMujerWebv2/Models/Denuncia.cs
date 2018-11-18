using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VioMujerWeb.Models
{
    public class Denuncia:BasicModelGrid
    {
        public List<Negocio.Denuncia> Denuncias { get; set; }
    }
}