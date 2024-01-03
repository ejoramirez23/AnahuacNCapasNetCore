using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Genero
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var generoLINQ = (from queryLINQ in context.Generos
                                      select new
                                      {
                                          IdGenero = queryLINQ.IdGenero,
                                          Nombre = queryLINQ.NombreGenero
                                      }).ToList();

                    result.Objects = new List<Object>();

                    if (generoLINQ.Count > 0)
                    {
                        foreach (var item in generoLINQ)
                        {
                            ML.Genero genero = new ML.Genero();

                            genero.IdGenero = int.Parse(item.IdGenero.ToString());
                            genero.NombreGenero = item.Nombre;


                            result.Objects.Add(genero);
                        }

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
    }
}
