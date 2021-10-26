using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using static IncidentesBlazor.Module.Utils.Util;
using DevExpress.Persistent.Base;
using System.Linq;
using DevExpress.ExpressApp;

namespace IncidentesBlazor.Module.BusinessObjects.Incidentes
{
    [DefaultClassOptions,DefaultProperty("Nombre")]
    public partial class Departamento
    {
        public Departamento(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

    }

}
