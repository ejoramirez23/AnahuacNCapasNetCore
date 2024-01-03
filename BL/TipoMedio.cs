using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TipoMedio
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {

                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {

                    var queryLINQ = (from tipoMedioLINQ in context.TipoMedios
                                     select new
                                     {
                                         IdTipoMedio = tipoMedioLINQ.IdTipoMedio,
                                         Nombre = tipoMedioLINQ.NombreTm
                                     }).ToList();

                    result.Objects = new List<Object>();

                    if (queryLINQ.Count > 0)
                    {
                        foreach (var item in queryLINQ)
                        {
                            ML.TipoMedio tipoMedio = new ML.TipoMedio();

                            tipoMedio.IdTipoMedio = int.Parse(item.IdTipoMedio.ToString());
                            tipoMedio.NombreTM = item.Nombre;


                            result.Objects.Add(tipoMedio);
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

    }
}
