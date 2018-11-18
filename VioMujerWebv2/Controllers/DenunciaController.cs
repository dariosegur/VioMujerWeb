using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VioMujerWeb.Controllers
{
    public class DenunciaController : BaseController
    {
        public DenunciaController()
        {
            paginaIndexada = Index;
        }
        public ActionResult Index()
        {
            ViewBag.CurrentUser = UsuarioActual;
            if (Filtros != null && (Filtros.GetType() != typeof(Negocio.Denuncia))) { Filtros = null; }
            var model = new Models.Denuncia()
            {
                User = UsuarioActual,
                Denuncias = Negocio.Denuncia.GetDenuncias(OrderBy, Descendente, NRegPerPage, NCurPage, (Negocio.Denuncia)Filtros),
                nCurPage = NCurPage,
                Descendente = Descendente,
                OrderBy = OrderBy,
                Filtros = Filtros
            };
            model.nTotalRegister = model.Denuncias.Count > 0 ? model.Denuncias[0].TotalReg : 0;
            model.nTotalPages = model.Denuncias.Count > 0 ? model.Denuncias[0].TotalPages : 0;
            return View("Index", model);

        }
        public ActionResult SetFilter(Negocio.Denuncia Filtros)
        {
            this.Filtros = Filtros;
            return Index();
        }

    }
}