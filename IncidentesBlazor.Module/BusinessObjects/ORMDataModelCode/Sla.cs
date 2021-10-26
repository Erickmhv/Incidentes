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
    [DefaultProperty("Descripcion")]

    public partial class Sla
    {
        public Sla(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

    }

}
