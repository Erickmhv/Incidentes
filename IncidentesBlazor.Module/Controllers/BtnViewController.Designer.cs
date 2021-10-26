
namespace IncidentesBlazor.Module.Controllers
{
    partial class BtnViewController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCerrar = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Caption = "Finalizar";
            this.btnCerrar.ConfirmationMessage = null;
            this.btnCerrar.Id = "btnCerrar";
            this.btnCerrar.ImageName = "BO_Validation";
            this.btnCerrar.TargetObjectType = typeof(IncidentesBlazor.Module.BusinessObjects.Incidentes.Incidente);
            this.btnCerrar.ToolTip = null;
            this.btnCerrar.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.btnCerrar.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.btnCerrar_Execute);
            // 
            // BtnViewController
            // 
            this.Actions.Add(this.btnCerrar);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction btnCerrar;
    }
}
