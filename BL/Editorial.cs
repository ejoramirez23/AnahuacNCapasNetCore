using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Editorial
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {

                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {

                    var queryLINQ = (from editorialLINQ in context.Editorials
                                     select new
                                     {
                                         IdEditorial = editorialLINQ.IdEditorial,
                                         Nombre = editorialLINQ.NombreEdit
                                     }).ToList();

                    result.Objects = new List<Object>();

                    if (queryLINQ.Count > 0)
                    {
                        foreach (var item in queryLINQ)
                        {
                            ML.Editorial editorial = new ML.Editorial();

                            editorial.IdEditorial = int.Parse(item.IdEditorial.ToString());
                            editorial.NombreEdit = item.Nombre;


                            result.Objects.Add(editorial);
                        }

                        result.Correct = true;
                    }


                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio,un error: " + ex.Message;
            }

            return result;

        }



        public static ML.Result GetById(int idEditorial)
        {
            ML.Result result = new ML.Result();


            try
            {

                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {

                    var queryLINQ = (from editorialLINQ in context.Editorials
                                     where editorialLINQ.IdEditorial == idEditorial
                                     select new
                                     {
                                         IdEditorial = editorialLINQ.IdEditorial,
                                         Nombre = editorialLINQ.NombreEdit
                                     });


                    result.Object = new object();

                    if (queryLINQ != null)
                    {

                        var item = queryLINQ.FirstOrDefault();

                        ML.Editorial editorial = new ML.Editorial();

                        editorial.IdEditorial = int.Parse(item.IdEditorial.ToString());
                        editorial.NombreEdit = item.Nombre;

                        result.Object = editorial;


                        result.Correct = true;


                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "ocurrio un error: " + ex.Message;
            }


            return result;

        }




        public static ML.Result Add(ML.Editorial editorial)
        {
            ML.Result result = new ML.Result();


            try
            {

                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AddEditorial '{editorial.NombreEdit}' ");

                    if (query != 0)
                    {
                        result.Correct = true;
                        result.Message = "La editorial se agrego correctamente";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al agregar editorial";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "ocurrio un error: " + ex.Message;
            }


            return result;

        }



        public static ML.Result Update(ML.Editorial editorial)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UpdateEditorial '{editorial.IdEditorial}', '{editorial.NombreEdit}' ");
                    
                    if (query != 0)
                    {
                        result.Correct = true;
                        result.Message = "La editorial se actualizo correctamente";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al actualizar editorial";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "ocurrio un error: " + ex.Message;
            }
            return result;
        }
       


        public static ML.Result Delete(int idEditorial)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"DeleteEditorial '{idEditorial}' ");

                    if (query != 0)
                    {
                        result.Correct = true;
                        result.Message = "Editorial eliminada correctamente";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al eliminar editorial";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "ocurrio un error: " + ex.Message;
            }
            return result;
        }




    }
}
