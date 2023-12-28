﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                    var medioLINQ = (from queryLINQ in context.Medios
                                     join tipoMedioLINQ in context.TipoMedios
                                     on queryLINQ.IdTipoMedio equals tipoMedioLINQ.IdTipoMedio
                                     join editorialLINQ in context.Editorials
                                     on queryLINQ.IdEditorial equals editorialLINQ.IdEditorial
                                     join idiomaLINQ in context.Idiomas
                                     on queryLINQ.IdIdioma equals idiomaLINQ.IdIdioma
                                     join generoLINQ in context.Generos
                                     on queryLINQ.IdGenero equals idiomaLINQ.IdGenero
                                     join autorLINQ in context.Autors
                                     on queryLINQ.IdAutor equals autorLINQ.IdAutor
                                     select new
                                     {
                                         IdMedio = queryLINQ.IdMedio,
                                         Titulo = queryLINQ.Titulo,
                                         IdTipoMedio = tipoMedioLINQ.IdTipoMedio,
                                         NombreTM = tipoMedioLINQ.NombreTM,
                                         IdEditorial = editorialLINQ.IdEditorial,
                                         NombreEdit = editorialLINQ.NombreEdit,
                                         AñoLanzamiento = queryLINQ.AñoLanzamiento,
                                         Duración = queryLINQ.Duración,
                                         NumPaginas = queryLINQ.NumPaginas,
                                         IdIdioma = idiomaLINQ.IdIdioma,
                                         NombreIdioma = idiomaLINQ.NombreIdioma,
                                         IdGenero = generoLINQ.IdGenero,
                                         NombreGenero = generoLINQ.NombreGenero,
                                         IdAutor = autorLINQ.IdAutor,
                                         Nombre = autorLINQ.Nombre,
                                         ApellidoPaterno = autorLINQ.ApellidoPaterno,
                                         ApellidoMaterno = autorLINQ.ApellidoMaterno,
                                         Descripcion = queryLINQ.Descripcion,
                                         Imagen = queryLINQ.Imagen
                                     }).ToList();



                    result.Objects = new List<Object>();

                    if (medioLINQ.Count > 0)
                    {
                        foreach (var item in medioLINQ)
                        {
                            ML.Medio medio = new ML.Medio();

                            medio.IdMedio = int.Parse(item.IdMedio.ToString());
                            medio.Titulo = item.Titulo;
                            medio.TipoMedio = new ML.TipoMedio();
                            medio.TipoMedio.IdTipoMedio = int.Parse(item.IdTipoMedio.ToString());
                            medio.TipoMedio.NombreTM = item.NombreTM;
                            medio.Editorial = new ML.Editorial();
                            medio.Editorial.IdEditorial = int.Parse(item.IdEditorial.ToString());
                            medio.Editorial.NombreEdit = item.NombreEdit;
                            medio.AñoLanzamiento = item.AñoLanzamiento == null ? "" : item.AñoLanzamiento.Value.Date.ToString("dd/MM/yyyy");
                            medio.Duración = item.Duración;
                            medio.NumPaginas = int.Parse(item.NumPaginas.ToString());
                            medio.Idioma = new ML.Idioma();
                            medio.Idioma.IdIdioma = int.Parse(item.IdIdioma.ToString());
                            medio.Idioma.NombreIdioma = item.NombreIdioma;
                            medio.Genero = new ML.Genero();
                            medio.Genero.IdGenero = int.Parse(item.IdGenero.ToString());
                            medio.Genero.NombreGenero = item.NombreGenero;
                            medio.Autor = new ML.Autor();
                            medio.Autor.IdAutor = int.Parse(item.IdAutor.ToString());
                            medio.Autor.Nombre = item.Nombre;
                            medio.Autor.ApellidoPaterno = item.ApellidoPaterno;
                            medio.Autor.ApellidoMaterno = item.ApellidoMaterno;
                            medio.Descripcion = item.Descripcion;
                            byte[] medioImagen = item.Imagen as byte[] ?? null;
                            medio.Imagen = medioImagen;



                            result.Objects.Add(medio);
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





        public static ML.Result GetById(int idMedio)
        {
            ML.Result result = new ML.Result();


            try
            {

                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {

                    var medioLINQ = (from queryLINQ in context.Medios
                                     join tipoMedioLINQ in context.TipoMedios
                                     on queryLINQ.IdTipoMedio equals tipoMedioLINQ.IdTipoMedio
                                     join editorialLINQ in context.Editorials
                                     on queryLINQ.IdEditorial equals editorialLINQ.IdEditorial
                                     join idiomaLINQ in context.Idiomas
                                     on queryLINQ.IdIdioma equals idiomaLINQ.IdIdioma
                                     join generoLINQ in context.Generos
                                     on queryLINQ.IdGenero equals idiomaLINQ.IdGenero
                                     join autorLINQ in context.Autors
                                     on queryLINQ.IdAutor equals autorLINQ.IdAutor
                                     where queryLINQ.IdMedio == idMedio
                                     select new
                                     {
                                         IdMedio = queryLINQ.IdMedio,
                                         Titulo = queryLINQ.Titulo,
                                         IdTipoMedio = tipoMedioLINQ.IdTipoMedio,
                                         NombreTM = tipoMedioLINQ.NombreTM,
                                         IdEditorial = editorialLINQ.IdEditorial,
                                         NombreEdit = editorialLINQ.NombreEdit,
                                         AñoLanzamiento = queryLINQ.AñoLanzamiento,
                                         Duración = queryLINQ.Duración,
                                         NumPaginas = queryLINQ.NumPaginas,
                                         IdIdioma = idiomaLINQ.IdIdioma,
                                         NombreIdioma = idiomaLINQ.NombreIdioma,
                                         IdGenero = generoLINQ.IdGenero,
                                         NombreGenero = generoLINQ.NombreGenero,
                                         IdAutor = autorLINQ.IdAutor,
                                         Nombre = autorLINQ.Nombre,
                                         ApellidoPaterno = autorLINQ.ApellidoPaterno,
                                         ApellidoMaterno = autorLINQ.ApellidoMaterno,
                                         Descripcion = queryLINQ.Descripcion,
                                         Imagen = queryLINQ.Imagen
                                     });


                    result.Object = new object();

                    if (medioLINQ != null)
                    {

                        var item = medioLINQ.FirstOrDefault();

                        ML.Medio medio = new ML.Medio();

                        medio.IdMedio = int.Parse(item.IdMedio.ToString());
                        medio.Titulo = item.Titulo;
                        medio.TipoMedio = new ML.TipoMedio();
                        medio.TipoMedio.IdTipoMedio = int.Parse(item.IdTipoMedio.ToString());
                        medio.TipoMedio.NombreTM = item.NombreTM;
                        medio.Editorial = new ML.Editorial();
                        medio.Editorial.IdEditorial = int.Parse(item.IdEditorial.ToString());
                        medio.Editorial.NombreEdit = item.NombreEdit;
                        medio.AñoLanzamiento = item.AñoLanzamiento == null ? "" : item.AñoLanzamiento.Value.Date.ToString("dd/MM/yyyy");
                        medio.Duración = item.Duración;
                        medio.NumPaginas = int.Parse(item.NumPaginas.ToString());
                        medio.Idioma = new ML.Idioma();
                        medio.Idioma.IdIdioma = int.Parse(item.IdIdioma.ToString());
                        medio.Idioma.NombreIdioma = item.NombreIdioma;
                        medio.Genero = new ML.Genero();
                        medio.Genero.IdGenero = int.Parse(item.IdGenero.ToString());
                        medio.Genero.NombreGenero = item.NombreGenero;
                        medio.Autor = new ML.Autor();
                        medio.Autor.IdAutor = int.Parse(item.IdAutor.ToString());
                        medio.Autor.Nombre = item.Nombre;
                        medio.Autor.ApellidoPaterno = item.ApellidoPaterno;
                        medio.Autor.ApellidoMaterno = item.ApellidoMaterno;
                        medio.Descripcion = item.Descripcion;
                        byte[] medioImagen = item.Imagen as byte[] ?? null;
                        medio.Imagen = medioImagen;

                        result.Object = medio;


                        result.Correct = true;


                    }

                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "ocurrio un error: " + ex.Message;
            }


            return result;

        }






       

        public static ML.Result Add(ML.Medio medio)
        {
            ML.Result result = new ML.Result();


            try
            {

                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AddMedio '{medio.Titulo}', '{medio.TipoMedio.IdTipoMedio}' , '{medio.Editorial.IdEditorial}'  , '{medio.AñoLanzamiento}'  , '{medio.Duración}' , '{medio.NumPaginas}' , '{medio.Idioma.IdIdioma}' , '{medio.Genero.IdGenero}' , '{medio.Autor.IdAutor}' , '{medio.Descripcion}' , '{medio.Imagen}'  ");

                    if (query != null)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al agregar medio";
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



        public static ML.Result Update(ML.Medio medio)
        {
            ML.Result result = new ML.Result();


            try
            {

                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AddMedio '{medio.IdMedio}' , '{medio.Titulo}', '{medio.TipoMedio.IdTipoMedio}' , '{medio.Editorial.IdEditorial}'  , '{medio.AñoLanzamiento}'  , '{medio.Duración}' , '{medio.NumPaginas}' , '{medio.Idioma.IdIdioma}' , '{medio.Genero.IdGenero}' , '{medio.Autor.IdAutor}' , '{medio.Descripcion}' , '{medio.Imagen}'  ");

                    if (query != null)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al actualizar medio";
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


        // falta checarlo e implementarlo porque se deben eliminar en donde exista ese medio 


        public static ML.Result Delete(int idMedio)
        {
            ML.Result result = new ML.Result();


            try
            {

                using (DL.AnahuacNcapasNetCoreContext context = new DL.AnahuacNcapasNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AddMedio '{medio.IdMedio}' , '{medio.Titulo}', '{medio.TipoMedio.IdTipoMedio}' , '{medio.Editorial.IdEditorial}'  , '{medio.AñoLanzamiento}'  , '{medio.Duración}' , '{medio.NumPaginas}' , '{medio.Idioma.IdIdioma}' , '{medio.Genero.IdGenero}' , '{medio.Autor.IdAutor}' , '{medio.Descripcion}' , '{medio.Imagen}'  ");

                    if (query != null)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al actualizar medio";
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