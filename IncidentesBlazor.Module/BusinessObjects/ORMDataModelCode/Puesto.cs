using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System;
using System.Linq;
using static IncidentesBlazor.Module.Utils.Util;

namespace IncidentesBlazor.Module.BusinessObjects.ORMDataModelCode
{
    public partial class Puesto : PermissionPolicyRole
    {
        public Puesto(Session session) : base(session)
        {
            FechaRegistro = DateTime.Now;
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
    }

}