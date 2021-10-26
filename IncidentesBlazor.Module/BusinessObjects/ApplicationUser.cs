using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using static IncidentesBlazor.Module.Utils.Util;

namespace IncidentesBlazor.Module.BusinessObjects
{
    [MapInheritance(MapInheritanceType.ParentTable)]
    [DefaultProperty(nameof(UserName))]
    public class ApplicationUser : PermissionPolicyUser, IObjectSpaceLink, ISecurityUserWithLoginInfo
    {
        public ApplicationUser(Session session) : base(session) {
            FechaRegistro = DateTime.Now;
        }

        [Browsable(false)]
        [Aggregated, Association("User-LoginInfo")]
        public XPCollection<ApplicationUserLoginInfo> LoginInfo
        {
            get { return GetCollection<ApplicationUserLoginInfo>(nameof(LoginInfo)); }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private string cedula;

        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        private string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private DateTime fechaNacimiento;

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        private Estatus enumEstatus;

        public Estatus EnumEstatus
        {
            get { return enumEstatus; }
            set { enumEstatus = value; }
        }

        private DateTime fechaRegistro;

        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        private DateTime fechaModificacion;

        public DateTime FechaModificacion
        {
            get { return fechaModificacion; }
            set { fechaModificacion = value; }
        }

        private ApplicationUser creadoPor;

        public ApplicationUser CreadoPor
        {
            get { return creadoPor; }
            set { creadoPor = value; }
        }

        private ApplicationUser modificadoPor;

        public ApplicationUser ModificadoPor
        {
            get { return modificadoPor; }
            set { modificadoPor = value; }
        }

        protected override void OnSaved()
        {

            FechaModificacion = DateTime.Now;
            ModificadoPor = new XPQuery<ApplicationUser>(Session).Where(i => i.Oid.ToString() == SecuritySystem.CurrentUserId.ToString()).FirstOrDefault();

            base.OnSaved();
        }

        IEnumerable<ISecurityUserLoginInfo> IOAuthSecurityUser.UserLogins => LoginInfo.OfType<ISecurityUserLoginInfo>();

        IObjectSpace IObjectSpaceLink.ObjectSpace { get; set; }

        ISecurityUserLoginInfo ISecurityUserWithLoginInfo.CreateUserLoginInfo(string loginProviderName, string providerUserKey)
        {
            ApplicationUserLoginInfo result = ((IObjectSpaceLink)this).ObjectSpace.CreateObject<ApplicationUserLoginInfo>();
            result.LoginProviderName = loginProviderName;
            result.ProviderUserKey = providerUserKey;
            result.User = this;
            return result;
        }
    }
}
