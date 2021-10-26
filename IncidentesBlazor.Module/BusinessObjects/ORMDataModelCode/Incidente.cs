using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace IncidentesBlazor.Module.BusinessObjects.Incidentes
{
    [DefaultProperty("Oid")]

    public partial class Incidente
    {
        private PermissionPolicyUser usuarioReportaId;

        public PermissionPolicyUser UsuarioReportaId
        {
            get { return usuarioReportaId; }
            set { usuarioReportaId = value; }
        }

        private ApplicationUser usuarioAsignado;

        public ApplicationUser UsuarioAsignado
        {
            get { return usuarioAsignado; }
            set { usuarioAsignado = value; }
        }

        public bool comentarioCierreCambio = false;
        public bool estatusCambio = false;
        public bool fechaCierreCambio = false;
        public int contador = 0;
        public Incidente(Session session) : base(session) { }

        protected override void OnLoaded()
        {
            UsuarioReportaId = new XPQuery<PermissionPolicyUser>(Session).Where(i => i.Oid.ToString() == SecuritySystem.CurrentUserId.ToString()).FirstOrDefault();

            base.OnLoaded();
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            if (propertyName == "ComentarioCierre")
            {
                comentarioCierreCambio = true;
            }

            if (propertyName == "FechaCierre")
            {
                fechaCierreCambio = true;
            }

            if (propertyName == "Estatus")
            {
                estatusCambio = true;
            }

            base.OnChanged(propertyName, oldValue, newValue);
        }

        protected override void OnSaving()
        {
            if (Oid > 0 && contador == 0)
            {
                contador++;
                var comentario = "";

                if (comentarioCierreCambio)
                    comentario += $"- Se cambio el comentario a {ComentarioCierre} - ";

                if (fechaCierreCambio)
                    comentario += $"- Se cambio la fecha cierre a {FechaCierre} - ";

                if (estatusCambio)
                    comentario += $"- Se cambio el estatus a {Estatus} - ";

                if (!string.IsNullOrEmpty(comentario)/* && HistorialIncidentes.Any(x => x.Comentario == comentario + $" por el usuario {UsuarioReportaId?.UserName} -" && x.Estatus == Utils.Util.Estatus.Activo && x.Incidente == this)*/)
                {
                    HistorialIncidentes.Add(new HistorialIncidente(Session)
                    {
                        CreadoPor = new XPQuery<ApplicationUser>(Session).Where(i => i.Oid.ToString() == SecuritySystem.CurrentUserId.ToString()).FirstOrDefault(),
                        Comentario = comentario + $" por el usuario {UsuarioReportaId?.UserName} -",
                        Estatus = Utils.Util.Estatus.Activo,
                        Incidente = this,
                        FechaRegistro = DateTime.Now

                    });
                }
                comentario = "";
            }

            base.OnSaving();
        }
        protected override void OnSaved()
        {
            contador = 0;
            //if (Oid > 0)
            //{
            //    var comentario = "";

            //    if (comentarioCierreCambio)
            //        comentario += $"- Se cambio el comentario a {ComentarioCierre} - ";

            //    if (fechaCierreCambio)
            //        comentario += $"- Se cambio la fecha cierre a {FechaCierre} - ";

            //    if (estatusCambio)
            //        comentario += $"- Se cambio el estatus a {Estatus} - ";

            //    if (!string.IsNullOrEmpty(comentario))
            //    {
            //        var historialIncidente = new HistorialIncidente(Session)
            //        {
            //            CreadoPor = new XPQuery<ApplicationUser>(Session).Where(i => i.Oid.ToString() == SecuritySystem.CurrentUserId.ToString()).FirstOrDefault(),
            //            Comentario = comentario + $" por el usuario {UsuarioReportaId?.UserName} -",
            //            Estatus = Utils.Util.Estatus.Activo,
            //            Incidente = this,
            //            FechaRegistro = DateTime.Now

            //        };

            //        HistorialIncidentes.Add(historialIncidente);

            //        historialIncidente.Save();
            //        Save();
            //    }
            //}

            base.OnSaved();
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        public void Cerrar()
        {
            FechaCierre = DateTime.Now;
        }

    }

}
