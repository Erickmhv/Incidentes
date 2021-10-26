using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using DevExpress.ExpressApp;

namespace IncidentesBlazor.Module.BusinessObjects.Incidentes
{

    public partial class HistorialIncidente
    {
        public HistorialIncidente(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }


        protected override void OnSaving()
        {
            Save();
            base.OnSaving();
        }
        //protected override void OnSaved()
        //{
        //    if (Oid > 0)
        //    {
        //        FechaModificacion = DateTime.Now;
        //        ModificadoPor = new XPQuery<ApplicationUser>(Session).Where(i => i.Oid.ToString() == SecuritySystem.CurrentUserId.ToString()).FirstOrDefault();
        //    }
        //    base.OnSaved();
        //}
    }

}
