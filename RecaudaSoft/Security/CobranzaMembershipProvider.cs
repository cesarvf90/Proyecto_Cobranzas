using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using RecaudaSoft.Models;
using System.Data.Entity;
using System.Linq;


namespace RecaudaSoft.Scripts
{
    public class CobranzaMembershipProvider : MembershipProvider
    {

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

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            using (var db = new CobranzasEntities())
            {
                var usuarios = from usuario in db.Usuarios
                               where usuario.nombreUsuario.Equals(username, StringComparison.CurrentCultureIgnoreCase) &&
                                 usuario.contrasena.Equals(oldPassword, StringComparison.CurrentCultureIgnoreCase)
                               select usuario;
                if (usuarios.ToArray().Length > 0)
                {
                    Usuario usuario = usuarios.First();
                    usuario.contrasena = newPassword;
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            using (CobranzasEntities db = new CobranzasEntities())
            {
                var listaUsuarios = db.Usuarios.Where(a => a.nombreUsuario.Equals(username)).ToList();
                Usuario usuarioEncontrado;
                if (listaUsuarios.Count() == 0)
                {
                    usuarioEncontrado = null;
                }
                else
                    usuarioEncontrado = listaUsuarios.First();

                if (usuarioEncontrado == null)
                {
                    Usuario usuario = new Usuario();
                    usuario.nombreUsuario = username;
                    usuario.contrasena = password;
                    usuario.correo = email;
                    //AccountModel account = new AccountModel(model);
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    status = MembershipCreateStatus.Success;
                    return new MembershipUser("CobranzaMembershipProvider", "", null, "", "", "", false, false, new DateTime(), new DateTime(), new DateTime(), new DateTime(), new DateTime());
                }

                status = MembershipCreateStatus.InvalidUserName;
                return new MembershipUser("CobranzaMembershipProvider", "", null, "", "", "", false, false, new DateTime(), new DateTime(), new DateTime(), new DateTime(), new DateTime());
            }
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        /*
         * Se utiliza para el login
         */
        public override bool ValidateUser(string username, string password)
        {
            using (CobranzasEntities db = new CobranzasEntities())
            {
                var usuarios = from usuario in db.Usuarios
                               where usuario.nombreUsuario.Equals(username, StringComparison.CurrentCultureIgnoreCase) &&
                                 usuario.contrasena.Equals(password, StringComparison.CurrentCultureIgnoreCase)
                               select usuario;
                if (usuarios.ToArray().Length > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}