using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Idioma
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {

                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {

                    var queryLINQ = (from idiomaLINQ in context.Idiomas
                                      select new
                                      {
                                          IdIdioma = idiomaLINQ.IdIdioma,
                                          Nombre = idiomaLINQ.NombreIdioma
                                      }).ToList();

                    result.Objects = new List<Object>();

                    if (queryLINQ.Count > 0)
                    {
                        foreach (var item in queryLINQ)
                        {
                            ML.Idioma idioma = new ML.Idioma();

                            idioma.IdIdioma = int.Parse(item.IdIdioma.ToString());
                            idioma.NombreIdioma = item.Nombre;


                            result.Objects.Add(idioma);
                        }

                        result.Correct = true;
                    }


                }


            }catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio,un error: "+ ex.Message;    
            }

            return result;

        }

    }
}
