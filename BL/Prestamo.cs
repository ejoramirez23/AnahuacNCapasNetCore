using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Prestamo
    {
        public static ML.Result Add(ML.Prestamo prestamo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AddPrestamo {prestamo.Medio.IdMedio}, " +
                        $"'{prestamo.FechaPrestamo}', '{prestamo.FechaEntrega}', '{prestamo.Estatus}', " +
                        $"'{prestamo.Usuario.Id}'");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo agregar el prestamo";
                    }
                }
            }
            catch (Exception ex) 
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.Prestamo prestamo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UpdatePrestamo {prestamo.IdPrestamo}," +
                        $"{prestamo.Medio.IdMedio}, '{prestamo.FechaPrestamo}', '{prestamo.FechaEntrega}'," +
                        $"{prestamo.Estatus}, {prestamo.Usuario.Id}");

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Prestamo actualizado correctamente";
                    }else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo actualizar el prestamo";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex=ex;
                result.Message = ex.Message;
            }
                return result;
        }

        public static ML.Result Delete(int idPrestamo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"DeletePrestamo '{idPrestamo}'");

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Prestamo eliminado correctamente";
                    }
                    else
                    {
                        result.Correct = false;
                      
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message=ex.Message;
            }
            return result;
        }






    }
}
