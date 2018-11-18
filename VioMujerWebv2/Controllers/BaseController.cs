using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Mvc.Filters;


namespace VioMujerWeb.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            filterContext.Result = new ViewResult
            {
                ViewName = @"~/Views/Shared/Error.cshtml",
                MasterName = @"~/Views/Shared/_Layout.cshtml",
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model)
            };
        }

        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            if (controllerName == "Home" && (actionName == "Autenticar"|| actionName == "Index")) return;
            var user = filterContext.HttpContext.User;
            if (!EstaAutenticado)
            {
                var model = new HandleErrorInfo(new Exception("Fuera de login"), controllerName, actionName);
                filterContext.Result = new ViewResult
                {
                    ViewName = @"~/Views/Home/Login.cshtml",
                    MasterName = @"~/Views/Shared/_Layout.cshtml",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model)
                };
            }
        }

        protected override void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }

        /// <summary>
        /// Construye una respuesta JsonResult simple, con un mensaje y una bandera de ok o error
        /// </summary>
        /// <param name="result">Badeara que indica si el resultado fue faborabel o no</param>
        /// <param name="message">Texto indicando detalle del resultado</param>
        /// <param name="code">Codigo del Error si existio</param>
        /// <returns>Objeto JsonResult</returns>
        protected JsonResult SimpleJson(bool result, string message, long? code = null)
        {
            return Json(new { Result = result, Message = message, Code = code ?? 0 });
        }

        /// <summary>
        /// Indica si existe un usuario autenticado en el sistema
        /// </summary>
        protected bool EstaAutenticado
        {
            get { return (UsuarioActual!=null); }
        }


        /// <summary>
        /// Información del usuario autenticado actualmente en el sistema
        /// </summary>
        protected Negocio.Usuario UsuarioActual
        {
            get { return (Negocio.Usuario)(HttpContext.Session["UsuarioActual"] ?? null); }
            set { HttpContext.Session["UsuarioActual"] = value; }
        }


        /// <summary>
        /// Numero de registros por página
        /// </summary>
        protected int NRegPerPage => 20;

        /// <summary>
        /// Pagina actual
        /// </summary>
        protected int NCurPage
        {
            get { return (int)(HttpContext.Session["nCurPage"] ?? 1); }
            set { HttpContext.Session["nCurPage"] = value; }
        }

        /// <summary>
        /// Directorio para almacenar imagenes 
        /// </summary>
        protected string PrivateImageFolder
        {
            get
            {
                return WebConfigurationManager.AppSettings["PrivateImageFolder"];
            }
        }
        /// <summary>
        /// Accion para obtener una imagen en el directorio de imagenes
        /// </summary>
        /// <param name="Nombre de la imagen"></param>
        /// <returns>La imgen solicitada</returns>
        public FileResult GetImage(string id)
        {
            var dir = PrivateImageFolder;
            var path = Path.Combine(dir, id); //validate the path for security or use other means to generate the path.
            return new FileStreamResult(new FileStream(path, FileMode.Open), "image/jpeg");
        }

        /// <summary>
        /// Criterio de ordenamiento, campo por el cual se ordena
        /// </summary>
        protected string OrderBy
        {
            get { return (string)(HttpContext.Session["OrderBy"] ?? null); }
            set { HttpContext.Session["OrderBy"] = value; }
        }

        /// <summary>
        /// Criterio de ordenamiento, ascendente o descendente
        /// </summary>
        protected bool Descendente
        {
            get { return (bool)(HttpContext.Session["Descendente"] ?? false); }
            set { HttpContext.Session["Descendente"] = value; }
        }

        /// <summary>
        /// Filtros a aplicar
        /// </summary>
        protected object Filtros
        {
            get { return HttpContext.Session["Filtros"]; }
            set
            {
                NCurPage = 0;
                HttpContext.Session["Filtros"] = value;
            }
        }

      
        /// <summary>
        /// Extrae la excepcion original
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>Excepcion original</returns>
        static public Exception ExtractException(Exception ex)
        {
            var exFinal = ex;
            while (exFinal.InnerException != null)
            {
                exFinal = exFinal.InnerException;
            }
            return exFinal;
        }

        protected delegate ActionResult PaginaIndexada();
        protected PaginaIndexada paginaIndexada;
        /// <summary>
        /// Cambia la pagina
        /// </summary>
        /// <param name="newPage"></param>
        /// <returns>Vista</returns>
        public ActionResult ChangePage(int newPage)
        {
            NCurPage = newPage;
            return paginaIndexada();
        }
        /// <summary>
        /// Cambiar el ordenamiento
        /// </summary>
        /// <param name="field">Campo por el cual ordenar</param>
        /// <returns>Vista</returns>
        public ActionResult ChangeFilterField(string field)
        {
            Descendente = field != OrderBy ? false : !Descendente;
            OrderBy = field;
            return paginaIndexada();
        }
        //[HttpPost]
        //public ActionResult Upload(HttpPostedFileBase file, long Id)
        //{
            //ViewBag.result = false;
            //ViewBag.message = "";
            //try
            //{
            //    if (file == null || file.ContentLength <= 0)
            //    {
            //        throw new Exception("Debe seleccionar un archivo");
            //    }
            //    var fileName = PrivateImageFolder + Path.GetFileName(file.FileName);
            //    file.SaveAs(fileName);
            //    //var registro = Negocio.Categoria.GetById(Id);
            //    //registro.Icon = Path.GetFileName(file.FileName);
            //    //Negocio.Categoria.Editar(registro);
            //    ViewBag.message = "Archivo cargado correctamente";
            //    ViewBag.result = true;
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.message = ex.Message;
            //    ViewBag.code = ex.HResult;
            //}
            //return Registro(Id);
        //}
    }
}