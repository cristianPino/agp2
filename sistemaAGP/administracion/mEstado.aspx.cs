using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using CNEGOCIO;
using CENTIDAD;
using System.Collections.Generic;


namespace sistemaAGP
{
	public partial class mEstado : System.Web.UI.Page
	{
		private string codigo;
        private string nombre_familia;
        private Int16 id_grupo;
        private DropDownList dl;
        private DropDownList dl2;
        private DropDownList dl3;

		protected void Page_Load(object sender, EventArgs e)
		{
			codigo = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());
            nombre_familia = (Request.QueryString["nombre_familia"].Trim());
			
			if (!IsPostBack)
			{
                FuncionGlobal.combogrupo(this.dpl_grupo);
                this.lbl_familia.Text = nombre_familia.Trim();
                getestado();
			}

		}

		protected void getestado()
		{

			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("codigo_estado"));
			dt.Columns.Add(new DataColumn("descripcion"));
			DataColumn col = new DataColumn("correo_cliente");
			col.DataType = System.Type.GetType("System.Boolean");
			DataColumn col2 = new DataColumn("correo_empresa");
			col2.DataType = System.Type.GetType("System.Boolean");
			dt.Columns.Add(new DataColumn("orden"));
			DataColumn col3 = new DataColumn("cliente_estado");
			col3.DataType = System.Type.GetType("System.Boolean");
			DataColumn col4 = new DataColumn("llamada");
			col4.DataType = System.Type.GetType("System.Boolean");
			dt.Columns.Add(new DataColumn("lista_correo"));
			DataColumn col5 = new DataColumn("envia_adquirientes");
			col5.DataType = System.Type.GetType("System.Boolean");
			dt.Columns.Add(new DataColumn("dias_primer_a"));
			dt.Columns.Add(new DataColumn("dias_ultimo_a"));
			dt.Columns.Add(new DataColumn("caducidad_estado"));
			dt.Columns.Add(new DataColumn("contador_estado"));
			dt.Columns.Add(new DataColumn("url_documento"));
            dt.Columns.Add(new DataColumn("id_grupo"));
			dt.Columns.Add(new DataColumn("url_modulo"));
            dt.Columns.Add(new DataColumn("url_comportamiento"));
            DataColumn col6 = new DataColumn("estado_manual");
            col6.DataType = System.Type.GetType("System.Boolean");
			dt.Columns.Add(col);
			dt.Columns.Add(col2);
			dt.Columns.Add(col3);
			dt.Columns.Add(col4);
			dt.Columns.Add(col5);
            dt.Columns.Add(col6);

			List<EstadoTipoOperacion> lestadotipo = new EstadotipooperacionBC().getEstadoByFamiliaByGrupo(Convert.ToInt16(codigo),id_grupo);
    

			foreach (EstadoTipoOperacion mestadotipo in lestadotipo) 
			{
                
                    DataRow dr = dt.NewRow();

                    //Grupo mgrupo = new GrupoBC().getEstadobycodigo(mestadotipo.Codigo_estado);
                    dr["codigo_estado"] = mestadotipo.Codigo_estado;
                    dr["descripcion"] = mestadotipo.Descripcion;
                    dr["correo_cliente"] = Convert.ToBoolean(mestadotipo.Correo_cliente);
                    dr["correo_empresa"] = Convert.ToBoolean(mestadotipo.Correo_empresa);
                    dr["orden"] = mestadotipo.Orden;
                    dr["cliente_estado"] = Convert.ToBoolean(mestadotipo.Cliente_estado);
                    dr["llamada"] = Convert.ToBoolean(mestadotipo.Llamada);
                    dr["lista_correo"] = mestadotipo.Lista_correo;
                    dr["envia_adquirientes"] = mestadotipo.Envia_adquirientes;
                    dr["dias_primer_a"] = mestadotipo.Dias_primer_a;
                    dr["dias_ultimo_a"] = mestadotipo.Dias_ultimo_a;
                    dr["caducidad_estado"] = mestadotipo.Caducidad_estado;
                    dr["contador_estado"] = mestadotipo.Contado_estado;
                    dr["url_documento"] = "mDocumentoEstado.aspx?codigo_estado=" + FuncionGlobal.FuctionEncriptar(mestadotipo.Codigo_estado.ToString()) + "&id_familia=" +
                    FuncionGlobal.FuctionEncriptar(codigo.ToString()) + "&nombre_familia=" + (this.lbl_familia.Text.Trim());
                    dr["url_comportamiento"] = "mComportamiento.aspx?codigo_estado=" + FuncionGlobal.FuctionEncriptar(mestadotipo.Codigo_estado.ToString()) + "&id_familia=" +
                    FuncionGlobal.FuctionEncriptar(codigo.ToString()) + "&nombre_familia=" + (this.lbl_familia.Text.Trim());

                    //if (mestadotipo.Id_grupo == null)
                    //{
                        dr["id_grupo"] = mestadotipo.Id_grupo;
                    //}
                    //else
                    //{
                    //    dr["id_grupo"] = mgrupo.Id_grupo;
                    //}
                    dr["url_modulo"] = "mreglaestadofamilia.aspx?codigo_estado=" + FuncionGlobal.FuctionEncriptar(mestadotipo.Codigo_estado.ToString()) + "&id_familia=" +                      FuncionGlobal.FuctionEncriptar(codigo.ToString()) + "&nombre_familia=" + (this.lbl_familia.Text.Trim());

                    dr["estado_manual"] = mestadotipo.Estado_manual.ToString();

                    dt.Rows.Add(dr);
                
			}
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
		}


		protected void Button1_Click(object sender, EventArgs e)
		{
		}

		private void add()
		{
		}

		public void limpiar()
		{
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
		}

		protected void txt_nombre_TextChanged(object sender, EventArgs e)
		{
		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
		{
		}

		protected void chk_Cocliente_CheckedChanged(object sender, EventArgs e)
		{
		}

		protected void txt_orden_TextChanged(object sender, EventArgs e)
		{
		}

		protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
		{
		}

		protected void presionado(object sender, EventArgs e)
		{

			GridViewRow row;

			string add_ET = "";

            //string add_EG = "";

            //string delete_EG = "";

            //delete_EG = new GrupoBC().delete_GrupoEstado(Convert.ToInt32(codigo));

            for (int i = 0; i < GridView1.Rows.Count; i++)
			{

                row = GridView1.Rows[i];
                string id_estado = GridView1.Rows[i].Cells[0].Text;
                TextBox descripcion = (TextBox)GridView1.Rows[i].FindControl("descripcion");
                CheckBox chk_cliente = (CheckBox)GridView1.Rows[i].FindControl("chk_cliente");
                CheckBox chk_empresa = (CheckBox)GridView1.Rows[i].FindControl("chk_empresa");
                CheckBox chk_estadoempresa = (CheckBox)GridView1.Rows[i].FindControl("chk_estadoempresa");
                CheckBox chk_llamada = (CheckBox)GridView1.Rows[i].FindControl("chk_llamada");
                CheckBox chk_adquiriente = (CheckBox)GridView1.Rows[i].FindControl("chk_adquiriente");
                TextBox dias_primer_a = (TextBox)GridView1.Rows[i].FindControl("dias_primer_a");
                TextBox dias_ultimo_a = (TextBox)GridView1.Rows[i].FindControl("dias_ultimo_a");
                TextBox lista_correo = (TextBox)GridView1.Rows[i].FindControl("lista_correo");
                string txt = Convert.ToString(GridView1.Rows[i].FindControl("txt_aviso"));
                TextBox caducidad_estado = (TextBox)GridView1.Rows[i].FindControl("caducidad_estado");
                DropDownList dl = (DropDownList)GridView1.Rows[i].FindControl("contador_estado");
                DropDownList dl3 = (DropDownList)GridView1.Rows[i].FindControl("id_grupo");
                CheckBox chk_emanual = (CheckBox)GridView1.Rows[i].FindControl("chk_emanual");
                //string Descripcion = gr_dato.Rows[i].Cells[1].Text;
				
				Int32 estado = Convert.ToInt32(id_estado);
				string ccliente = chk_cliente.Checked.ToString();
				string cempresa = chk_empresa.Checked.ToString();
				string cestemp = chk_estadoempresa.Checked.ToString();
				string cllamada = chk_llamada.Checked.ToString();
				string descr = descripcion.Text.ToString();
				string cadquiriente = chk_adquiriente.Checked.ToString();
                string orden = i.ToString();
				//Int16 caviso = Convert.ToInt16(dias_primer_a);
				//Int16 caviso = Convert.ToInt16(chk_aviso);
				//Int16 ctermino = Convert.ToInt16(dias_ultimo_a);
				//Int16 ccaducidad = Convert.ToInt16(caducidad_estado);
				string ccontador = dl.SelectedValue.ToString();
                string cgrupo = dl3.SelectedValue.ToString();
                string cmanual = chk_emanual.Checked.ToString();

				add_ET = new EstadotipooperacionBC().add_Estadotipooperacion(estado,Convert.ToInt16(codigo), Convert.ToString(descr), ccliente, cempresa,
                    Convert.ToInt16(orden), cestemp, cllamada,cadquiriente,Convert.ToInt16(dias_primer_a.Text.ToString()),Convert.ToInt16(dias_ultimo_a.Text.ToString())
                    , Convert.ToInt16(caducidad_estado.Text.ToString()), Convert.ToInt16(ccontador),0, lista_correo.Text.ToString(), Convert.ToInt32(dl3.SelectedValue.Trim()),Convert.ToBoolean(cmanual));

                //if (cgrupo != "0")
                //{
                //    add_EG = new GrupoBC().add_Estadogrupo(Convert.ToInt32(dl3.SelectedValue.Trim()), estado);
                //}

			}

			getestado();
		}

		protected void grabar(object sender, EventArgs e)
		{

			string add_MU = "";

			string descripcion = this.TextBox1.Text;
			string ccliente = this.chk_aviso.Checked.ToString();
			string cempresa = this.CheckBox1.Checked.ToString();
			string cmanual = this.CheckBox3.Checked.ToString();
			string cllamada = this.CheckBox4.Checked.ToString();
			string corden = this.TextBox3.Text;
            
			
			add_MU = new EstadotipooperacionBC().add_Estadotipooperacion(0,Convert.ToInt16(codigo),Convert.ToString(descripcion), ccliente, cempresa, Convert.ToInt16(corden),                            "false", cllamada,"false",0,0,0,0,0,"0",Convert.ToInt16(this.dpl_grupo.SelectedValue),Convert.ToBoolean(cmanual));

			getestado();
		}

		protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			int id_fam;
			string id_fam_encrip;
			id_fam_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());
			id_fam = Convert.ToInt16(id_fam_encrip);

			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				EstadoTipoOperacion mtipooperacion = new EstadoTipoOperacion();

				mtipooperacion.Codigo = "0";
				mtipooperacion.Descripcion = "Seleccionar";
				List<EstadoTipoOperacion> ltipooperacion = new EstadotipooperacionBC().getEstadoByFamilia(id_fam);

				ltipooperacion.Add(mtipooperacion);

				 dl = (DropDownList)e.Row.FindControl("contador_estado");

				dl.DataSource = ltipooperacion;
				dl.DataValueField = "codigo_estado";
				dl.DataTextField = "descripcion";
				dl.DataBind();

                Grupo mgrupo = new Grupo();
                mgrupo.Id_grupo = 0;
                mgrupo.Descripcion = "Seleccionar";

                List<Grupo> lgrupo = new GrupoBC().getallgrupo();
                lgrupo.Add(mgrupo);

                 dl3 = (DropDownList)e.Row.FindControl("id_grupo");

                dl3.DataSource = lgrupo;
                dl3.DataValueField = "id_grupo";
                dl3.DataTextField = "descripcion";
                dl3.DataBind();
                

				dl.SelectedValue = GridView1.DataKeys[e.Row.RowIndex].Values[0].ToString();
                dl3.SelectedValue = GridView1.DataKeys[e.Row.RowIndex].Values[1].ToString(); ;
			}
		}

		protected void dl_estado_SelectedIndexChanged(object sender, EventArgs e)
		{
		}
        protected void dl_grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void dpl_grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_grupo = Convert.ToInt16(this.dpl_grupo.SelectedValue);
            this.lbl_gfamilia.Text = this.dpl_grupo.SelectedItem.Text;
            getestado();
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }

	}

}