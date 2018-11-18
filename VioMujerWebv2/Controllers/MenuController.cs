using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VioMujerWebv2.Controllers
{
    public class MenuController : BaseApiController
    {
        public Negocio.MenuImage Get(int id)
        {
            var r = Negocio.MenuImage.GetMenuImage(id);
            return r;
        }
    }
}