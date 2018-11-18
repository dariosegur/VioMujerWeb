using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaisesCiudadesService
{
    public class PaisesCiudadesService
    {
        public static Dictionary<string,string> GetPaises() {
            System.Net.WebClient cliente = new System.Net.WebClient();
            var respuesta =  cliente.DownloadString("https://geodata.solutions/restapi?dd=1");
            var lista=respuesta.Replace("[[", "").Replace("]]", "").Replace("\"","").Split(new string[] { "],[" }, StringSplitOptions.RemoveEmptyEntries);
            if (lista == null||lista.Count()<=0) return null;
            return lista.ToDictionary(n=>n.Split(new char[] { ',' })[0], n=> n.Split(new char[] { ',' })[1]);
        }

        public static Dictionary<int, string> GetDepartamentos(string PaisID)
        {
            System.Net.WebClient cliente = new System.Net.WebClient();
            var respuesta = cliente.DownloadString("https://geodata.solutions/restapi?dd=1&country=" + PaisID);
            var lista = respuesta.Replace("[[", "").Replace("]]", "").Replace("\"", "").Split(new string[] { "],[" }, StringSplitOptions.RemoveEmptyEntries);
            if (lista == null || lista.Count() <= 0) return null;
            return lista.ToDictionary(n => int.Parse(n.Split(new char[] { ',' })[0]), n => n.Split(new char[] { ',' })[1]);
        }

        public static Dictionary<int, string> GetCiudades(string PaisID, int DepartamentoId)
        {
            System.Net.WebClient cliente = new System.Net.WebClient();
            var respuesta = cliente.DownloadString("https://geodata.solutions/restapi?dd=pop10k-ordpop&country=" + PaisID+ "&state="+DepartamentoId);
            var lista = respuesta.Replace("[[", "").Replace("]]", "").Replace("\"", "").Split(new string[] { "],[" }, StringSplitOptions.RemoveEmptyEntries);
            if (lista == null || lista.Count() <= 0) return null;
            return lista.ToDictionary(n => int.Parse(n.Split(new char[] { ',' })[0]), n => n.Split(new char[] { ',' })[1]);
        }
    }
}
