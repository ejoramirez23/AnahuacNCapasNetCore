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

         public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = (from presLinq in context.Prestamos
                                join medioLinq in context.Medios
                                on presLinq.IdMedio equals medioLinq.IdMedio
                                join userLinq in context.AspNetUsers
                                on presLinq.IdUsuario equals userLinq.Id

                                select new
                                {
                                    idPrestamo = presLinq.IdPrestamo,
                                    idMedio = presLinq.IdMedio,
                                    fechaPrestamo = presLinq.FechaPrestamo,
                                    fechaEntrega = presLinq.FechaEntrega,
                                    estatus = presLinq.Estatus,
                                    idUsuario = presLinq.IdUsuario

                                }).ToList();
                    if (query.Count > 0)
                    {
                        result.Object = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Prestamo prestamo = new ML.Prestamo();

                            prestamo.IdPrestamo = item.idPrestamo;

                            prestamo.Medio = new ML.Medio();
                            prestamo.Medio.IdMedio = item.idMedio.Value;
                            prestamo.FechaPrestamo =item.fechaPrestamo.Value;
                            prestamo.FechaEntrega = item.fechaEntrega.Value;

                            prestamo.Usuario = new ML.Usuario();
                            prestamo.Usuario.Id = item.idUsuario;

                            result.Objects.Add(prestamo);
                        }
                        result.Correct = true; 
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.Ex = ex;
                result.Message=ex.Message;
            }
            return result;
        }


        public static ML.Result GetById(int idprestamo)
{
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = (from presLinq in context.Prestamos
                                join medioLinq in context.Medios
                                on presLinq.IdMedio equals medioLinq.IdMedio
                                join userLinq in context.AspNetUsers
                                on presLinq.IdUsuario equals userLinq.Id
                                select new
                                {
                                    idPrestamo = presLinq.IdPrestamo,
                                    idMedio = presLinq.IdMedio,
                                    fechaPrestamo = presLinq.FechaPrestamo,
                                    fechaEntrega = presLinq.FechaEntrega,
                                    estatus = presLinq.Estatus,
                                    idUsuario = presLinq.IdUsuario

                                }).SingleOrDefault();
                    if (query != null)
                    {
                        ML.Prestamo prestamo = new ML.Prestamo();

                        prestamo.IdPrestamo = query.idPrestamo;

                        prestamo.Medio = new ML.Medio();
                        prestamo.Medio.IdMedio = query.idMedio.Value;
                        prestamo.FechaPrestamo = query.fechaPrestamo.Value;
                        prestamo.FechaEntrega = query.fechaEntrega.Value;
                        prestamo.Estatus = query.estatus.Value;

                        prestamo.Usuario = new ML.Usuario();
                        prestamo.Usuario.Id = query.idUsuario;

                        result.Object = prestamo;

                        result.Correct = true;
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
