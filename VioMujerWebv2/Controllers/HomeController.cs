using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VioMujerWeb.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.CurrentUser = UsuarioActual;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Autenticar(string Usuario, string password)
        {
            UsuarioActual = null;
            var usuario = Negocio.Usuario.Autenticar(Usuario, password);
            if (usuario == null) {
                ViewBag.Error = "Usuario o contraseña incorrecto";
                return View("Login");
            }
            UsuarioActual = usuario;
            ViewBag.CurrentUser = usuario;
            return RedirectToAction("Index", "Denuncia");
        }

        public ActionResult Logout()
        {
            UsuarioActual = null;
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}