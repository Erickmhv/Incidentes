using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using IncidentesBlazor.Module.BusinessObjects;
using IncidentesBlazor.Module.BusinessObjects.Incidentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBlazor.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class FilterListViewController : ViewController
    {
        public FilterListViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            if ((View is ListView) & (View.ObjectTypeInfo.Type == typeof(Incidente)))
            {
                Session session = ((XPObjectSpace)this.ObjectSpace).Session;
                string criteria = $"[FechaCierre] IS NULL AND [UsuarioAsignado.Oid] = '{new XPQuery<ApplicationUser>(session).Where(i => i.Oid.ToString() == SecuritySystem.CurrentUserId.ToString()).FirstOrDefault().Oid.ToString().ToUpper()}'";

                ((ListView)View).CollectionSource.Criteria["ListViewFilter"] = CriteriaOperator.Parse(criteria);
            }
            //View.ObjectSpace.Refresh();
            View.Refresh();

            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
