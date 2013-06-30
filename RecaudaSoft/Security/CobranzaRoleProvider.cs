using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using RecaudaSoft.Models;

namespace RecaudaSoft.Security
{
    public class CobranzaRoleProvider : RoleProvider 
    {

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            if (usernames == null || roleNames == null)
            {
                throw new ArgumentNullException();
            }
            if (usernames.Any().Equals("") || usernames.Contains(",") || roleNames.Any().Equals("") || roleNames.Contains(","))
            {
                throw new ArgumentException();
            }

            foreach (string nombreUsuario in usernames)
            {
                using (CobranzasEntities db = new CobranzasEntities())
                {
                    List<Rol> roles = db.Rols.ToList();
                    foreach (string nombreRol in roleNames)
                    {
                        foreach (Rol rolAux in roles)
                        {
                            if (rolAux.nombre.Equals(nombreRol))
                            {
                                /* TODO cvasquez: mejorar la relacion para que un usuario se pueda relacionar con mas de un rol por ejemplo si cambia de puesto
                                var userAux = db.Usuarios.Where(a => a.nombreUsuario.Equals(nombreUsuario)).First();
                                RolesXUsuario rolXusuario = new RolesXUsuario();
                                rolXusuario.AccountModelID = userAux.Id;
                                rolXusuario.RolID = rolAux.Id;
                                db.RolesXUsuario.Add(rolXusuario);
                                db.SaveChanges();
                                */
                                var userAux = db.Usuarios.Where(a => a.nombreUsuario.Equals(nombreUsuario)).First();
                                Usuario usuario = new Usuario();
                                usuario.nombreUsuario = nombreUsuario;
                                usuario.idRol = db.Rols.Where(r => r.nombre.Equals(nombreRol)).First().idRol;
                                db.Usuarios.Add(usuario);
                                db.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (var db = new CobranzasEntities())
            {
                /* Si se trabajara por roles el acceso a las vistas*/
                /*var usuario = db.Usuarios.Include("Rol").Where(u => u.nombreUsuario.Equals(username, StringComparison.CurrentCulture)).First();

                Rol rol = usuario.Rol;
                List<string> roles = new List<string>();
                if (rol != null)
                {
                    roles.Add(rol.nombre);
                }
                return roles.ToArray();
                 * */

                /* Si se trabaja por permisos el acceso a las vistas*/
                var usuario = db.Usuarios.Include("Rol").Where(u => u.nombreUsuario.Equals(username, StringComparison.CurrentCulture)).First();

                var permisos = from rp in db.RolXPermisoes
                            where rp.idRol == usuario.idRol
                            select rp.Permiso.funcionalidad;

                if (permisos != null)
                {
                    return permisos.ToArray();
                }
                else
                {
                    return new string[] { }; ;
                }
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}