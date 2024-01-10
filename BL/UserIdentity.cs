using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserIdentity
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = (from User in context.AspNetUsers
                                 select new
                                 {
                                     idUser = User.Id,
                                     userName = User.UserName
                                 }).ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var user in query)
                        {
                            ML.Usuario uI = new ML.Usuario();

                            uI.Id = user.idUser;
                            uI.UserName = user.userName;
                            result.Objects.Add(uI);
                        }
                        result.Correct = true;
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

        public static ML.Result Asignar(ML.UserIdentity user)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"AddAspNetUserRoles '{user.IdUsuario}', '{user.Rol.RoleId}'");

                    if (query != 0)
                    {
                        result.Correct = true;
                        result.Message = "Asignación exitosa";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Ocurrio un error al intentar realizar la asignación";
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
    }
}
