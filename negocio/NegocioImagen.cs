﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace negocio
{
    public class NegocioImagen
    {
        public List<Imagen> listFCharacter(int id)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select id, ImageUrl, character_id from images where character_id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.Id = datos.Lector.GetInt32(0);
                    imagen.Url = (string)datos.Lector["ImageUrl"] !=null? (string)datos.Lector["ImageUrl"] : "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQogFO9C5CpJWSO1PoItMbYVr968uCyHzKPZ8LD26z0J46BI4Vg";
                    imagen.Character_Id = datos.Lector.GetInt32(2);   
                    lista.Add(imagen);
                }
                if(lista.Count == 0)
                {
                    Imagen defaultImg = new Imagen();
                    defaultImg.Id = 0;
                    defaultImg.Url = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQogFO9C5CpJWSO1PoItMbYVr968uCyHzKPZ8LD26z0J46BI4Vg";
                    defaultImg.Character_Id = id;
                    lista.Add(defaultImg);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }
    }
}