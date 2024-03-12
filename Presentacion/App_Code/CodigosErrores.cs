using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using NPOI.HSSF.Model; // InternalWorkbook
using NPOI.HSSF.UserModel; // HSSFWorkbook, HSSFSheet
using NPOI.SS.UserModel;
using WebNPOI.Code.Repository;
using WebNPOI.Code.Domain;
using WebNPOI.Code.Service;
using System.Text;
using WebNPOI.Code.Crosscutting;
using System.Net;

public static class CodigosErrores
{
    public static string errorLiquidacionCerrada = "No hay liquidaciones abiertas";
}
    