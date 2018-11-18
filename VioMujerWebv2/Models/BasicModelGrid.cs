using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VioMujerWeb.Models
{
    public class BasicModelGrid
    {
        public Negocio.Usuario User { get; set; }
        public int nRegPerPage { get; set; }
        public int nCurPage { get; set; } 
        public int nTotalRegister { get; set; }
        public int nTotalPages { get; set; }
        public string OrderBy { get; set; }
        public bool Descendente { get; set; }
        public object Filtros { get; set; }
    }
}