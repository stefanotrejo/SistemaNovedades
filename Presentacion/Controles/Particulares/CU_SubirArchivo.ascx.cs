using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Controles_Particulares_CU_SubirArchivo : System.Web.UI.UserControl
{
    string Extension = "";

    public string Carpeta
    {
        get
        {
            return this.lblCarpeta.Text;
        }

        set
        {
            this.lblCarpeta.Text = value;
        }
    }

    public string ArchivoNombreSinExtension
    {
        get
        {
            return this.lblArchivoNombre.Text;
        }

        set
        {
            this.lblArchivoNombre.Text = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubirArchivo_Click(object sender, EventArgs e)
    {
        if (fup.HasFile)
        {
            if (Directory.Exists(MapPath("~/ArchivosSubidos/")))
            {
                Extension = fup.FileName.Substring(fup.FileName.IndexOf('.'), fup.FileName.Length - fup.FileName.IndexOf('.'));

                fup.SaveAs(MapPath("~/ArchivosSubidos/" + ArchivoNombreSinExtension + Extension));
            }
        }
    }
}