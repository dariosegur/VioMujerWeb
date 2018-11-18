using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Http;
using System.IO;
using System.Web.Configuration;
using System.Web;

namespace VioMujerWebv2.Controllers
{
    public class ImagenController : Controller
    {
       /// <summary>
        /// Accion para obtener una imagen en el directorio de imagenes
        /// </summary>
        /// <param name="Nombre de la imagen"></param>
        /// <returns>La imgen solicitada</returns>
        public FileResult Imagen(string id)
        {
            return GetImage(id);
        }     
        /// <summary>
        /// Accion para obtener una imagen en el directorio de imagenes
        /// </summary>
        /// <param name="Nombre de la imagen"></param>
        /// <returns>La imgen solicitada</returns>
        private FileResult GetImage(string id)
        {
            var dir = Server.MapPath("/Images");
            var path = Path.Combine(dir, id + ".png"); //validate the path for security or use other means to generate the path.
            return new FileStreamResult(new FileStream(path, FileMode.Open), "image/jpeg");
        }
    }
}