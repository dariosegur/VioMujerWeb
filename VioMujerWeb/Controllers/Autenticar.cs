using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VioMujerWeb.Controllers
{
    public class AutenticarController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Validar(string Usuario, string password)
        {
            
        }
    }
}