using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CNEGOCIO;

namespace sistemaAGP.analisis_vehiculo
{
    public partial class AdministracionInfocar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)  return;
            CargaCombobox();
            GetAllChartCertificado();
        }

        public void CargaCombobox()
        {
            FuncionGlobal.comboclientesbyusuario(Session["usrname"].ToString().Trim(),dlCliente);
        }

        public void GetAllChartCertificado()
        {
            ResetHidden();
            var cliente = Convert.ToInt32(dlCliente.SelectedValue);
            htitulo.Value = dlCliente.SelectedValue == "0" ? "" : "por " + dlCliente.SelectedItem.Text;
            var listaCAv = new InfoAutoBC().GetChartTodosCertificado("CCAV", cliente);
            var listaCMul = new InfoAutoBC().GetChartTodosCertificado("CAMUL", cliente);

            var conteo = 0;
            foreach (var d in listaCAv)
            {
                conteo++;
                switch (conteo)
                {
                    case 1:
                        Ch1.Value = d.ChartMesConteo.ToString();
                        hmes1.Value = d.ChartMesDescripcion;
                        break;
                    case 2:
                        ch2.Value = d.ChartMesConteo.ToString();
                        hmes2.Value = d.ChartMesDescripcion;
                        break;
                    case 3:
                        ch3.Value = d.ChartMesConteo.ToString();
                        hmes3.Value = d.ChartMesDescripcion;
                        break;
                    case 4:
                        ch4.Value = d.ChartMesConteo.ToString();
                        hmes4.Value = d.ChartMesDescripcion;
                        break;
                    case 5:
                        ch5.Value = d.ChartMesConteo.ToString();
                        hmes5.Value = d.ChartMesDescripcion;
                        break;
                    case 6:
                        ch6.Value = d.ChartMesConteo.ToString();
                        hmes6.Value = d.ChartMesDescripcion;
                        break;
                    case 7:
                        ch7.Value = d.ChartMesConteo.ToString();
                        hmes7.Value = d.ChartMesDescripcion;
                        break;
                    case 8:
                        ch8.Value = d.ChartMesConteo.ToString();
                        hmes8.Value = d.ChartMesDescripcion;
                        break;
                    case 9:
                        ch9.Value = d.ChartMesConteo.ToString();
                        hmes9.Value = d.ChartMesDescripcion;
                        break;
                    case 10:
                        ch10.Value = d.ChartMesConteo.ToString();
                        hmes10.Value = d.ChartMesDescripcion;
                        break;
                    case 11:
                        ch11.Value = d.ChartMesConteo.ToString();
                        hmes11.Value = d.ChartMesDescripcion;
                        break;
                    case 12:
                        ch12.Value = d.ChartMesConteo.ToString();
                        hmes12.Value = d.ChartMesDescripcion;
                        break;
                }
            }



            foreach (var d in listaCMul)
            {
                if (hmes1.Value == d.ChartMesDescripcion)
                {
                    mh1.Value = d.ChartMesConteo.ToString();
                }
                else if (hmes2.Value == d.ChartMesDescripcion)
                {
                    mh2.Value = d.ChartMesConteo.ToString();
                }
                else if (hmes3.Value == d.ChartMesDescripcion)
                {
                    mh3.Value = d.ChartMesConteo.ToString();
                }
                else if (hmes4.Value == d.ChartMesDescripcion)
                {
                    mh4.Value = d.ChartMesConteo.ToString();
                }
                else if (hmes5.Value == d.ChartMesDescripcion)
                {
                    mh5.Value = d.ChartMesConteo.ToString();
                }
                else if (hmes6.Value == d.ChartMesDescripcion)
                {
                    mh6.Value = d.ChartMesConteo.ToString();
                }
                else if (hmes7.Value == d.ChartMesDescripcion)
                {
                    mh7.Value = d.ChartMesConteo.ToString();
                }
                else if (hmes8.Value == d.ChartMesDescripcion)
                {
                    mh8.Value = d.ChartMesConteo.ToString();
                }
                else if (hmes9.Value == d.ChartMesDescripcion)
                {
                    mh9.Value = d.ChartMesConteo.ToString();
                }
                else if (hmes10.Value == d.ChartMesDescripcion)
                {
                    mh10.Value = d.ChartMesConteo.ToString();
                }
                else if (hmes11.Value == d.ChartMesDescripcion)
                {
                    mh11.Value = d.ChartMesConteo.ToString();
                }
                else if (hmes12.Value == d.ChartMesDescripcion)
                {
                    mh12.Value = d.ChartMesConteo.ToString();
                }
            }
        }
        public void ResetHidden()
        {
            Ch1.Value = "0";
            ch2.Value = "0";
            ch3.Value = "0";
            ch4.Value = "0";
            ch5.Value = "0";
            ch6.Value = "0";
            ch7.Value = "0";
            ch8.Value = "0";
            ch9.Value = "0";
            ch10.Value = "0";
            ch11.Value = "0";
            ch12.Value = "0";

            mh1.Value = "0";
            mh2.Value = "0";
            mh3.Value = "0";
            mh4.Value = "0";
            mh5.Value = "0";
            mh6.Value = "0";
            mh7.Value = "0";
            mh8.Value = "0";
            mh9.Value = "0";
            mh10.Value = "0";
            mh11.Value = "0";
            mh12.Value = "0";

            hmes1.Value = "";
            hmes2.Value = "";
            hmes3.Value = "";
            hmes4.Value = "";
            hmes5.Value = "";
            hmes6.Value = "";
            hmes7.Value = "";
            hmes8.Value = "";
            hmes9.Value = "";
            hmes10.Value = "";
            hmes11.Value = "";
            hmes12.Value = "";


        }
    }
}