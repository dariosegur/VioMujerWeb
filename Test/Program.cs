using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = PaisesCiudadesService.PaisesCiudadesService.GetPaises();
            var departamentos = PaisesCiudadesService.PaisesCiudadesService.GetDepartamentos("CO");
            foreach (var d in departamentos) {
                using (var context = new Datos.VioMujerEntities())
                {
                    var dep = new Datos.Departamento()
                    {
                        DepartamentoId = d.Key,
                        Nombre = d.Value
                    };
                    context.Departamentoes.Add(dep);
                    context.SaveChanges();
                    try
                    {
                        var ciudades = PaisesCiudadesService.PaisesCiudadesService.GetCiudades("CO", d.Key);
                        if (ciudades != null)
                        {
                            foreach (var c in ciudades)
                            {
                                try
                                {
                                    context.Ciudads.Add(new Datos.Ciudad() { DepartamentoId = d.Key, CiudadId = c.Key, Nombre = c.Value });
                                    context.SaveChanges();
                                }
                                catch
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(">" + c.Value);
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(">" + c.Value);
                            }
                        }
                    }
                    catch {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(">Al consultar");
                    }
                }
            }
            Console.Write("Listo");
            Console.ReadKey();
        }
    }
}
