using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Base;

namespace MiBotica.SolPedido.LogicaNegocio.Core
{
    public class UsuarioLN : BaseLN
    {
        public List<Usuario> ListaUsuarios()
        {
            try
            {
                return new UsuarioDA().ListaUsuarios();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarUsuario(Usuario usuario)
        {
            try
            {
                new UsuarioDA().ModificarUsuario(usuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        public void EliminarUsuario(int id)
        {
            try
            {
                new UsuarioDA().EliminarUsuario(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        public void InsertarUsuario(Usuario usuario)
        {
            try
            {
                new UsuarioDA().InsertarUsuario(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
