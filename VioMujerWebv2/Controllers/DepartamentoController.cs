using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VioMujerWebv2.Controllers
{
    public class DepartamentoController : BaseApiController
    {
        public List<Negocio.Geografia.Departamento> Get()
        {
            return Negocio.Geografia.Departamento.GetDepartamentos();
        }
    }
}