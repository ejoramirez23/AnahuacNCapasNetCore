using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static ML.Result Add(ML.Autor autor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AddAutor '{autor.Nombre}'," +
                        $" '{autor.ApellidoPaterno}', '{autor.ApellidoMaterno}'");

                    if(query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Autor agregado correctamente";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Ocurrio un error al intentar agregar al autor";
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

        public static ML.Result Update(ML.Autor autor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UpdateAutor {autor.IdAutor}, " +
                        $"'{autor.Nombre}', '{autor.ApellidoPaterno}', '{autor.ApellidoMaterno}'");

                    if (query > 0)
                    {
                        result.Correct= true;
                        result.Message = "Autor actualizado correctamente";
                    }
                    else
                    {
                        result.Correct=false;
                        result.Message = "currio un error al intentar actualizar al autor";
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

        public static ML.Result Delete(int idAutor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"DeleteAutor {idAutor}");

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Autor eliminado correctamente";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Ocurrio un error al intentar eliminar al autor";
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = (from autorLq in context.Autors
                                 select new
                                 {
                                     IdAut = autorLq.IdAutor,
                                     Name = autorLq.Nombre,
                                     APaterno = autorLq.ApellidoPaterno,
                                     AMaterno = autorLq.ApellidoMaterno
                                 }).ToList();

                    result.Objects = new List<object>();

                    if (query.Count > 0)
                    { 
                        foreach (var obj in query)
                        {
                            ML.Autor autor = new ML.Autor();

                            autor.IdAutor = obj.IdAut;
                            autor.Nombre = obj.Name;
                            autor.ApellidoPaterno = obj.APaterno;
                            autor.ApellidoMaterno = obj.AMaterno;

                            result.Objects.Add(autor);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message= ex.Message;
            }
            return result;
        }

        public static ML.Result GetById(int idAutor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = (from autorLQ in context.Autors
                                 where autorLQ.IdAutor == idAutor
                                 select new
                                 {
                                     idAutor = autorLQ.IdAutor,
                                     nombre = autorLQ.Nombre,
                                     APaterno = autorLQ.ApellidoPaterno,
                                     AMaterno = autorLQ.ApellidoMaterno
                                 }).SingleOrDefault();
                    if (query != null)
                    {
                        ML.Autor autor = new ML.Autor();

                        autor.IdAutor = query.idAutor;
                        autor.Nombre = query.nombre;
                        autor.ApellidoPaterno = query.APaterno;
                        autor.ApellidoMaterno = query.AMaterno;

                        result.Object = autor;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message= ex.Message;
            }

            return result;
        }

    }
}
