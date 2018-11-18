using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace VioMujerWebv2.Controllers
{

    public class CiudadController : BaseApiController
    {

        // GET api/<controller>/5
        public List<Negocio.Geografia.Ciudad> Get(int id)
        {
            return Negocio.Geografia.Ciudad.GetCiudadesPorDepartamento(id);
        }
    }
}