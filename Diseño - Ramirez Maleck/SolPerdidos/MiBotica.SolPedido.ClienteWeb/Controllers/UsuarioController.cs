using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiBotica.SolPedido.Utiles.Helpers;

namespace MiBotica.SolPedido.ClienteWeb.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<Usuario> usuario = new List<Usuario>();
            usuario = new UsuarioLN().ListaUsuarios();
            return View(usuario);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            Usuario usuario = new Usuario();
            return View(usuario);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                // TODO: Add insert logic here
                usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);
                new UsuarioLN().InsertarUsuario(usuario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            var lista = new UsuarioLN().ListaUsuarios();
            var usuario = lista.FirstOrDefault(x => x.IdUsuario == id);
            if (usuario == null) return HttpNotFound();

            usuario.ClaveTexto = "";
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(usuario.ClaveTexto))
        {
                    ModelState.AddModelError("ClaveTexto", "Debe ingresar una clave para modificar.");
                    return View(usuario); // vuelve a la vista con error
                }

                usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);

                new UsuarioLN().ModificarUsuario(usuario);
                TempData["ok"] = "Usuario modificado correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(usuario);

            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            var lista = new UsuarioLN().ListaUsuarios();
            var usuario = lista.FirstOrDefault(x => x.IdUsuario == id);
            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(Usuario usuario)
        {
            try
            {
                new UsuarioLN().EliminarUsuario(usuario.IdUsuario);
                TempData["ok"] = "Usuario eliminado correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "No se pudo eliminar el usuario: " + ex.Message);
                return View(usuario);
            }
        }
    }
}
