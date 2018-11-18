using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Denuncia
    {
        public long? DenunciaId { get; set; }
        public long CiudadId { get; set; }
        public DateTime FechaReporte { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public decimal? Longitud { get; set; }
        public decimal? Latitud { get; set; }
        public string Ciudad { get; set; }
        public long? DepartamentoId { get; set; }
        public string Departamento { get; set; }
        public long? AtendidoPorId { get; set; }
        public string AtendidoPor { get; set; }
        public int TotalPages { get; set; }
        public int TotalReg { get; set; }
        public string Ubicacion { get; set; }
        public string Telefono { get; set; }

        public static List<Denuncia> GetDenuncias(string orderBy, bool descendente, int nRegPerPage, int nPage, Denuncia Filtro) {
            using (var contexto=new Datos.VioMujerEntities()) {
                string filtro = CreateFiltro(Filtro);
                var listado = contexto.DenunciaList(orderBy, descendente, nRegPerPage, nPage, filtro==""?null:filtro);
                var res = listado.Select(r=>MapDenuncia(r)).ToList();
                return res;
            }
        }

        public static void Add(Denuncia NewRegistro) {
            using (var context = new Datos.VioMujerEntities()) {
                var nuevo = MapDenuncia(NewRegistro);
                context.Denuncias.Add(nuevo);
                context.SaveChanges();
            }
        }

        public static void MarcarComoAtendido(int DenunciaId, int UsuarioId)
        {
            using (var context = new Datos.VioMujerEntities())
            {
                var registro = context.Denuncias.Single(r=>r.DenunciaId==DenunciaId);
                registro.AtendidoPor = UsuarioId;
                context.SaveChanges();
            }
        }

        private static Denuncia MapDenuncia(Datos.View_Denuncia origen)
        {
            var destino = new Denuncia()
            {
                AtendidoPor = origen.AtendidoPor,
                AtendidoPorId = origen.AtendidoPorId,
                Ciudad = origen.Ciudad,
                CiudadId = origen.CiudadId,
                DenunciaId = origen.DenunciaId,
                Departamento = origen.Departamento,
                DepartamentoId = origen.DepartamentoId,
                Descripcion = origen.Descripcion,
                Direccion = origen.Direccion,
                FechaReporte = origen.FechaReporte,
                Latitud = origen.Latitud,
                Longitud = origen.Longitud,
                TotalPages=origen.TotalPages,
                TotalReg=origen.TotalReg,
                Telefono=origen.Telefono,
                Ubicacion=origen.Ubicacion
            };
            return destino;
        }
        private static Datos.Denuncia MapDenuncia(Denuncia origen)
        {
            var destino = new Datos.Denuncia()
            {
                AtendidoPor = origen.AtendidoPorId,
                CiudadId = origen.CiudadId,
                DenunciaId = origen.DenunciaId??0,
                Descripcion = origen.Descripcion,
                Direccion = origen.Direccion,
                FechaReporte = origen.FechaReporte,
                Latitud = origen.Latitud,
                Longitud = origen.Longitud,
                Ubicacion=origen.Ubicacion,
                Telefono=origen.Telefono
            };
            return destino;
        }
        private static string CreateFiltro(Denuncia Filtro)
        {
            string filtro = "";
            if (Filtro != null)
            {
                if (Filtro.DenunciaId != null)
                {
                    filtro = "DenunciaId = \'" + Filtro.DenunciaId + "\'";
                }
                if (!string.IsNullOrEmpty(Filtro.Descripcion))
                {
                    filtro += filtro.Length > 0 ? " AND " : "";
                    filtro += "Descripcion like \'%" + Filtro.Descripcion + "%\'";
                }
                if (!string.IsNullOrEmpty(Filtro.Departamento))
                {
                    filtro += filtro.Length > 0 ? " AND " : "";
                    filtro += "Departamento like \'%" + Filtro.Departamento + "%\'";
                }
                if (!string.IsNullOrEmpty(Filtro.Direccion))
                {
                    filtro += filtro.Length > 0 ? " AND " : "";
                    filtro += "Direccion like \'%" + Filtro.Direccion + "%\'";
                }
                if (!string.IsNullOrEmpty(Filtro.Ciudad))
                {
                    filtro += filtro.Length > 0 ? " AND " : "";
                    filtro += "Ciudad like \'%" + Filtro.Ciudad + "%\'";
                }
                if (!string.IsNullOrEmpty(Filtro.AtendidoPor))
                {
                    filtro += filtro.Length > 0 ? " AND " : "";
                    filtro += "AtendidoPor like \'%" + Filtro.Departamento + "%\'";
                }
            }
            return filtro;
        }

    }
}
