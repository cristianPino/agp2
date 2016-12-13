using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using System.Globalization;

public partial class SaveToFile : System.Web.UI.Page
{

    Int16 tipo;
    Int32 id_solicitud;
    string user;

    protected void Page_Load(object sender, EventArgs e)
    {

        tipo = Convert.ToInt16(Request.QueryString["tipo"]);
        id_solicitud = Convert.ToInt32(Request.QueryString["id_solicitud"]);
        user = Request.QueryString["user"];




        String strExc = "";
        try
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
            HttpPostedFile uploadfile = files["RemoteFile"];

            //String Path = System.Web.HttpContext.Current.Request.MapPath(".") + "/UploadedImages/";
            string sPath = String.Format("{0}", "docs");


            //if (!Directory.Exists(Path))
            //{
            //    Directory.CreateDirectory(Path);
            //}


            //divido la fecha en año mes dia.
            string x = DateTime.Now.ToString("yyyyMMddHHmmss");
            string anio = x.Substring(0, 4);
            string mes = x.Substring(4, 2);
            string dia = x.Substring(6, 2);

            //obtengo todos los nombres de los meses del año en español.
            String[] Meses = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

            //valido que el formato de los dias y meses sean equivalentes a los nombres de las carpetas de destino.
            string numero_mes = CambiarMes(mes);
            string CarpetaMes = numero_mes + "." + Meses[Convert.ToInt32(mes) - 1].ToString();
            string nuevo_dia = CambiarDia(dia);

            //armo los strings con las rutas dependiendo de la consulta.
            string destino = "";
            string destino_2 = "";

            destino = "/" + anio + "/" + CarpetaMes + "/" + nuevo_dia;


            FileInfo fi_documento = new FileInfo(uploadfile.FileName);

            if (!System.IO.Directory.Exists(@sPath)) sPath = "docs";
            string sDoc = id_solicitud.ToString() + "_" + tipo.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + fi_documento.Extension.Trim();
            string sSave = Server.MapPath(@sPath) + destino + "\\" + sDoc;

            destino_2 = "f:\\Docs\\" + anio + "\\" + CarpetaMes + "\\" + nuevo_dia + "\\" + sDoc;

            FileUpload fu_documento = new FileUpload();


            uploadfile.SaveAs(destino_2);


            sSave = sPath + destino + "/" + sDoc;

            DocumentosOperacionBC doc = new DocumentosOperacionBC();
            doc.add_documentos(id_solicitud, tipo, sSave, fi_documento.Extension, uploadfile.ContentLength, "", user);




        }
        catch (Exception exc)
        {
            strExc = exc.ToString();
            String strField1Path = HttpContext.Current.Request.MapPath(".") + "/" + "log.txt";
            StreamWriter sw1 = File.CreateText(strField1Path);
            if (strField1Path != null)
            {
                sw1.Write(strExc);
                sw1.Close();
            }
            Response.Write(strExc);
        }
    }

    public string CambiarMes(string mes)
    {
        string nuevomes = mes;
        if (Convert.ToInt32(mes) < 10)
        {
            nuevomes = nuevomes.Substring(1, nuevomes.Length - 1);
            return nuevomes;
        }
        return nuevomes;
    }

    public string CambiarDia(string dia)
    {
        string nuevodia = dia;
        if (Convert.ToInt32(dia) < 10)
        {
            nuevodia = nuevodia.Substring(1, nuevodia.Length - 1);
            return nuevodia;
        }
        return nuevodia;
    }



}

