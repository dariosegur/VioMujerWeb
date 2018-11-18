using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VioMujerWebv2.Controllers
{
    public class InformacionController : BaseApiController
    {
        public Negocio.Information Get(int id)
        {
            var r = Negocio.Information.GetInformacion(id);
            return r;
        }
    }
}