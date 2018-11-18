using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuario
    {
        public long UsuarioId { get; set; }
        public string Login { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificado { get; set; }
        public DateTime? FechaUltimoAcceso { get; set; }
        public bool Activo { get; set; }
        /// <summary>
        /// Metodo para autenticar un usuario dentro del sistema
        /// </summary>
        /// <param name="login">Nombre para autenticarse</param>
        /// <param name="contrasena">Contraseña</param>
        /// <returns>Retorna la información del usuario autenticado. Si el usuario ol acontraseña no son correctos retorna nulo</returns>
        static public Usuario Autenticar(string login, string contrasena)
        {
            using (var context = new Datos.VioMujerEntities())
            {
                var registro = context.Autenticar(login,contrasena).FirstOrDefault();
                if (registro == null) return null;
                var resultado = new Usuario {
                    Activo=registro.Activo,
                    FechaCreacion=registro.FechaCreacion,
                    FechaModificado=registro.FechaModificado,
                    FechaUltimoAcceso=registro.FechaUltimoAcceso,
                    Login=registro.Login,
                    UsuarioId=registro.UsuarioId
                };
                return resultado;
            }
        }
    }
}
