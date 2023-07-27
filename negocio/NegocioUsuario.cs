using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioUsuario
    {
        public List<Usuario> GetAllUsers()
        {
            List<Usuario> users = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            datos.setearConsulta("SELECT UserID, Username, PasswordHash, FullName,Email FROM MCUser");
            try
            {
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario user = new Usuario();
                    user.Id = Convert.ToInt32(datos.Lector["UserID"]);
                    user.Username = datos.Lector["Username"].ToString();
                    user.HashPass = datos.Lector["PasswordHash"].ToString();
                    user.FullName = datos.Lector["FullName"].ToString();
                    user.Email = datos.Lector["Email"].ToString();

                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return users;
        }

        public bool LogUser(string username, string password)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT PasswordHash FROM MCUser WHERE Username = @Username");
                datos.setearParametro("@Username", username);
                datos.ejecutarLectura();

                if (datos.Lector.HasRows)
                {
                    datos.Lector.Read(); // Move to the first (and only) row
                    string hashedPassword = datos.Lector["PasswordHash"].ToString();

                    if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                    {
                        // User is authenticated
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                // Handle exception
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return false; // Failed user login or user not found
        }
        public bool IsUsernameAvailable(string username)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("SELECT COUNT(*) FROM MCUser WHERE Username = @Username");
            datos.setearParametro("@Username", username);

            try
            {
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    int count = Convert.ToInt32(datos.Lector[0]);
                    if (count == 0) { return true; } // Return true if username is not found in the database
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return false; // Username is not available
        }
        public bool IsEmailAvailable(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("SELECT COUNT(*) FROM MCUser WHERE Email = @Email");
            datos.setearParametro("@Email", email);

            try
            {
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    int count = Convert.ToInt32(datos.Lector[0]);
                    if (count == 0) { return true; } // Return true if Email is not found in the database
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return false; // Email is not available
        }
        public bool IsFullNameAvailable(string fullName)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("SELECT COUNT(*) FROM MCUser WHERE FullName = @FullName");
            datos.setearParametro("@FullName", fullName);

            try
            {
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    int count = Convert.ToInt32(datos.Lector[0]);
                    if (count == 0) { return true; } // Return true if FullName is not found in the database
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return false; // FullName is not available
        }

        public bool CreateUser(Usuario NewUser)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("INSERT INTO MCUser (Username, PasswordHash, Salt, Email, FullName, LastLogin, IsLocked, FailedLoginAttempts)" +
                " VALUES (@Username, @PasswordHash, @Salt, @Email, @FullName, NULL, 0, 0)");
            datos.setearParametro("@Username", NewUser.Username);
            datos.setearParametro("@PasswordHash", NewUser.HashPass);
            datos.setearParametro("@Salt", NewUser.Salt);
            datos.setearParametro("@Email", NewUser.Email);
            datos.setearParametro("@FullName", NewUser.FullName);

            try
            {
                datos.ejecutarAccion();
                return true; // Registration successful
            }
            catch (Exception)
            {
                return false; // Registration failed due to an error
            }
        }

        public Usuario listByUsername(string username)
        {
            Usuario usuario = new Usuario();
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("SELECT UserID, Username, PasswordHash, FullName,Email FROM MCUser where Username = @username");
            datos.setearParametro("@username", username);
            try
            {
                datos.ejecutarLectura();

                if(datos.Lector.Read())
                {
                    usuario.Id = Convert.ToInt32(datos.Lector["UserID"]);
                    usuario.Username = datos.Lector["Username"].ToString();
                    usuario.HashPass = datos.Lector["PasswordHash"].ToString();
                    usuario.FullName = datos.Lector["FullName"].ToString();
                    usuario.Email = datos.Lector["Email"].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return usuario;
        }





        public Usuario ListarXUsuario(int id)
        {
            Usuario usuario = new Usuario();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(" select id, usuario, CONTRASEÑA, NOMBRES, APELLIDOS, DNI, TELEFONO, mail from USUARIOS where id= '" + id + "'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.Id = datos.Lector.GetInt32(0);
                    usuario.Username = (string)datos.Lector["usuario"];
                    usuario.HashPass = (string)datos.Lector["CONTRASEÑA"];
                    usuario.FullName = (string)datos.Lector["NOMBRES"];
                    usuario.DNI = datos.Lector.GetInt64(5);

                    usuario.Email = (string)datos.Lector["mail"];

                }

            }
            catch (Exception)
            {

                throw;
            }
            return usuario;
        }

        public void ModificarUsuario(Usuario modificado)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("update usuarios set usuario=@usuario, contraseña=@password, mail=@mail, telefono=@telefono where Id=@id");

                datos.setearParametro("@id", modificado.Id);
                datos.setearParametro("@usuario", modificado.Username);
                datos.setearParametro("@password", modificado.HashPass);
                datos.setearParametro("@mail", modificado.Email);
                datos.ejecutarAccion();
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
        public void ModificarUsuario(Usuario modificado, Usuario anterior)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ventas SET usuarioVendedor = @usuario WHERE usuarioVendedor = @lastUser");
                datos.setearParametro("@lastUser", anterior.Username);
                datos.setearParametro("@usuario", modificado.Username);
                datos.ejecutarAccion();
                datos.setearConsulta("UPDATE ventas SET usuario = @usuario WHERE usuario = @lastUser");
                datos.ejecutarAccion();
                datos.setearConsulta("UPDATE usuarios SET usuario = @usuario, contraseña = @password, mail = @mail, telefono = @telefono WHERE Id = @id");
                datos.setearParametro("@id", modificado.Id);
                datos.setearParametro("@password", modificado.HashPass);
                datos.setearParametro("@mail", modificado.Email);
                datos.ejecutarAccion();
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

        public void eliminarUsuario(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from FAVORITOS where Id_Usuario = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
                datos.setearConsulta("delete FROM Imagenes WHERE idpublicacion IN (SELECT id FROM Publicaciones WHERE id_usuario = @id)");
                datos.ejecutarAccion();
                datos.setearConsulta("delete from publicaciones where ID_USUARIO=@id");
                datos.ejecutarAccion();
                datos.setearConsulta("delete from usuarios where Id=@id");
                datos.ejecutarAccion();

            }
            catch (Exception)
            {
                throw;
            }

        }


        public Usuario ListarXUsuario(string usuario)
        {
            Usuario user = new Usuario();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(" select id, usuario, CONTRASEÑA, NOMBRES, APELLIDOS, DNI, TELEFONO, mail from USUARIOS where usuario= '" + usuario + "'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    user.Id = datos.Lector.GetInt32(0);
                    user.Username = (string)datos.Lector["usuario"];
                    user.HashPass = (string)datos.Lector["CONTRASEÑA"];
                    user.FullName = (string)datos.Lector["NOMBRES"];
                    user.DNI = datos.Lector.GetInt64(5);

                    user.Email = (string)datos.Lector["mail"];

                }

            }
            catch (Exception)
            {

                throw;
            }
            return user;
        }



        public Usuario ListarXDNI(long dni)
        {
            Usuario user = new Usuario();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(" select id, usuario, CONTRASEÑA, NOMBRES, APELLIDOS, DNI, TELEFONO, mail from USUARIOS where dni = @dni");

                datos.setearParametro("@dni", dni);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    user.Id = datos.Lector.GetInt32(0);
                    user.Username = (string)datos.Lector["usuario"];
                    user.HashPass = (string)datos.Lector["CONTRASEÑA"];
                    user.FullName = (string)datos.Lector["NOMBRES"];
                    user.DNI = datos.Lector.GetInt64(5);

                    user.Email = (string)datos.Lector["mail"];

                }

            }
            catch (Exception)
            {

                throw;
            }
            return user;
        }
    }
}









