namespace BL
{
    public class Medio
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();


            try
            {

                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {

                  


                }


            }catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "ocurrio un error: "+ ex.Message;
            }


            return result;

            //nnjnjnsnjnsjs
        }

    }
}