﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioCharacter
    {
        public List<Character> Listar(int pageNumber, int pageSize)
        {
            List<Character> lista = new List<Character>();
            AccesoDatos datos = new AccesoDatos();
            NegocioImagen negocioImagen = new NegocioImagen();

            try
            {
                // Calculate the number of characters to skip to get to the desired page
                int skipCount = (pageNumber - 1) * pageSize;

                // Update the SQL query to fetch the characters for the specified page
                datos.setearConsulta($@"
                SELECT c.character_id, c.name, c.description, ct.type_id AS tipoID, ct.type_name AS NameID,
                m.name AS MovieName, s.name AS SeriesName, a.id AS AlID, a.nombre AS AligmentName, c.color
                FROM Characters c
                LEFT JOIN CharacterTypes ct ON c.type_id = ct.type_id
                LEFT JOIN Alignment a ON c.alignment_id = a.id
                LEFT JOIN Movies m ON c.movie_idFA = m.movie_id
                LEFT JOIN Series s ON c.series_idFA = s.series_id
                ORDER BY c.character_id
                OFFSET {skipCount} ROWS
                FETCH NEXT {pageSize} ROWS ONLY");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Character aux = new Character();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Name = datos.Lector.GetString(1);
                    aux.Description = datos.Lector.GetString(2);
                    aux.MovieFA = datos.Lector.IsDBNull(datos.Lector.GetOrdinal("MovieName")) ? null : datos.Lector.GetString(datos.Lector.GetOrdinal("MovieName"));
                    aux.SerieFA = datos.Lector.IsDBNull(datos.Lector.GetOrdinal("SeriesName")) ? null : datos.Lector.GetString(datos.Lector.GetOrdinal("SeriesName"));
                    aux.color = (string)datos.Lector["color"];

                    CharacterType type = new CharacterType();
                    type.Id = datos.Lector.GetInt32(3);
                    type.Name = datos.Lector.GetString(4);
                    aux.Type = type;

                    Alingment a = new Alingment();
                    a.Id = datos.Lector.GetInt32(7);
                    a.Name = datos.Lector.GetString(8);
                    aux.Alingment = a;

                    aux.Images = negocioImagen.listFCharacter(aux.Id);

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Character ListarXID(int id)
        {
            Character lista = new Character();
            AccesoDatos datos = new AccesoDatos();
            NegocioImagen negocioImagen = new NegocioImagen();

            try
            {
                datos.setearConsulta(@"
                SELECT top 10 c.character_id, c.name, c.description, ct.type_id AS tipoID, ct.type_name AS NameID,
                m.name AS MovieName, s.name AS SeriesName, a.id AS AlID, a.nombre AS AligmentName, c.color
                FROM Characters c
                LEFT JOIN CharacterTypes ct ON c.type_id = ct.type_id
                LEFT JOIN Alignment a ON c.alignment_id = a.id
                LEFT JOIN Movies m ON c.movie_idFA = m.movie_id
                LEFT JOIN Series s ON c.series_idFA = s.series_id
                where c.character_id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura(); ;

                while (datos.Lector.Read())
                {
                    Character aux = new Character();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Name = datos.Lector.GetString(1);
                    aux.Description = datos.Lector.GetString(2);
                    aux.MovieFA = datos.Lector.IsDBNull(datos.Lector.GetOrdinal("MovieName")) ? null : datos.Lector.GetString(datos.Lector.GetOrdinal("MovieName"));
                    aux.SerieFA = datos.Lector.IsDBNull(datos.Lector.GetOrdinal("SeriesName")) ? null : datos.Lector.GetString(datos.Lector.GetOrdinal("SeriesName"));

                    CharacterType type = new CharacterType();
                    type.Id = datos.Lector.GetInt32(3);
                    type.Name = datos.Lector.GetString(4);
                    aux.Type = type;

                    Alingment a = new Alingment();
                    a.Id = datos.Lector.GetInt32(7);
                    a.Name = datos.Lector.GetString(8);
                    aux.Alingment = a;

                    aux.color = (string)datos.Lector["color"];

                    aux.Images = negocioImagen.listFCharacter(aux.Id);

                    lista = aux;
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Character ListarXID(string id)
        {
            Character lista = new Character();
            AccesoDatos datos = new AccesoDatos();
            NegocioImagen negocioImagen = new NegocioImagen();

            try
            {
                datos.setearConsulta(@"
                SELECT top 10 c.character_id, c.name, c.description, ct.type_id AS tipoID, ct.type_name AS NameID,
                m.name AS MovieName, s.name AS SeriesName, a.id AS AlID, a.nombre AS AligmentName, c.color
                FROM Characters c
                LEFT JOIN CharacterTypes ct ON c.type_id = ct.type_id
                LEFT JOIN Alignment a ON c.alignment_id = a.id
                LEFT JOIN Movies m ON c.movie_idFA = m.movie_id
                LEFT JOIN Series s ON c.series_idFA = s.series_id
                where c.character_id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura(); ;

                while (datos.Lector.Read())
                {
                    Character aux = new Character();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Name = datos.Lector.GetString(1);
                    aux.Description = datos.Lector.GetString(2);
                    aux.MovieFA = datos.Lector.IsDBNull(datos.Lector.GetOrdinal("MovieName")) ? null : datos.Lector.GetString(datos.Lector.GetOrdinal("MovieName"));
                    aux.SerieFA = datos.Lector.IsDBNull(datos.Lector.GetOrdinal("SeriesName")) ? null : datos.Lector.GetString(datos.Lector.GetOrdinal("SeriesName"));

                    CharacterType type = new CharacterType();
                    type.Id = datos.Lector.GetInt32(3);
                    type.Name = datos.Lector.GetString(4);
                    aux.Type = type;

                    Alingment a = new Alingment();
                    a.Id = datos.Lector.GetInt32(7);
                    a.Name = datos.Lector.GetString(8);
                    aux.Alingment = a;

                    aux.color = (string)datos.Lector["color"];

                    aux.Images = negocioImagen.listFCharacter(aux.Id);

                    lista = aux;
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int GetTotalCharacterCount()
        {
            int totalCount = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Characters");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    totalCount = datos.Lector.GetInt32(0);
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
            return totalCount;
        }
    }
}
