using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using static IncidentesBlazor.Module.Utils.Util;
using DevExpress.ExpressApp;
using System.Linq;

namespace IncidentesBlazor.Module.BusinessObjects.Incidentes
{

    public partial class Base
    {
        private Estatus estatus;

        public Estatus Estatus
        {
            get { return estatus; }
            set { estatus = value; }
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
        public Base(Session session) : base(session) { }
        public override void AfterConstruction() {
            FechaRegistro = DateTime.Now;
            CreadoPor = new XPQuery<ApplicationUser>(Session).Where(i => i.Oid.ToString() == SecuritySystem.CurrentUserId.ToString()).FirstOrDefault();
            
            base.AfterConstruction(); 
        
        }

        protected override void OnSaved()
        {
            if (Oid > 0)
            {
                FechaModificacion = DateTime.Now;
                ModificadoPor = new XPQuery<ApplicationUser>(Session).Where(i => i.Oid.ToString() == SecuritySystem.CurrentUserId.ToString()).FirstOrDefault();
            }
            base.OnSaved();
        }


    }

}
