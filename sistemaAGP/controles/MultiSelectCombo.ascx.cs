using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections;
using CENTIDAD;
using CNEGOCIO;


namespace sistemaAGP.controles
{
    public partial class MultiSelectCombo : System.Web.UI.UserControl
    {
        private string select;

        public string Select
        {
            get { return select; }
            set { select = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label();
            }

        }

        public void List(DataTable dt, string tipo)
        {

            this.chkList.DataSource = dt;
            this.chkList.DataValueField = "id";
            this.chkList.DataTextField = "nombre";
            this.chkList.DataBind();
        }

        public string getvalue()
        {
            string value = "";

            foreach (ListItem li in this.chkList.Items)
            {
                if (li.Selected)
                {
                    value += li.Value + ",";
                }
            }

            Label();

            char[] quitar = {','};
            string valor = value.TrimEnd(quitar);

            return valor;
        }

        public void Label()
        {
            int count= 0;

            foreach (ListItem li in this.chkList.Items)
            {
                if (li.Selected)
                {
                    count = count + 1;
                }
            }

            if(count != 0)
            {
                this.DDLabel.Text = "Cantidad Seleccionada: "+count.ToString();
            }
            else
            {
                DDLabel.Text = "Seleccione objetos a Utilizar";
            }
        }

        public void Limpiar()
        {
            foreach (ListItem li in this.chkList.Items)
            {
                if (li.Selected)
                {
                    li.Selected = false;
                }
            }

            this.checkall.Checked = false;
            this.DDLabel.Text = "Seleccione objetos a Utilizar";
        }


        protected void button1_Click(object sender, EventArgs e)
        {

        }
    }
}