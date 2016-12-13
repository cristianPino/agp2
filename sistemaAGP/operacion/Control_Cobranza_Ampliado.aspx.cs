using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using CENTIDAD;
using CNEGOCIO;
using sistemaAGP.operacion;
using AjaxControlToolkit;
namespace sistemaAGP
{
    public partial class Control_Cobranza_Ampliado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {

                IOrderedEnumerable<Cliente> lcliente = from c in new ClienteBC().getclientes()
                                                       orderby c.Persona.Nombre ascending, c.Persona.Apellido_paterno ascending, c.Persona.Apellido_materno ascending
                                                       select c;

                FuncionGlobal.comboregion(this.ddl_region, "CH");
                llenar_cliente();
              
                this.txt_desde.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
                this.txt_hasta.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            }

        }

        protected void llenar_cliente()
        {

                        DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id"));
            dt.Columns.Add(new DataColumn("nombre"));


            List<Cliente> lcliente = new ClienteBC().getclientes();

            foreach (Cliente mcli in lcliente)
            {

                DataRow dr = dt.NewRow();
                dr["id"] = mcli.Id_cliente;
                dr["nombre"] = mcli.Persona.Nombre;
                dt.Rows.Add(dr);
            }

            this.dl_cliente.List(dt, "cliente");
        }

        protected void llenar_ciudad()
        {
          



            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id"));
            dt.Columns.Add(new DataColumn("nombre"));


            List<Ciudad> lciudad = new CiudadBC().getCiudadbyregion(Convert.ToInt16(this.ddl_region.SelectedValue));

            foreach (Ciudad mCiu in lciudad)
            {

                DataRow dr = dt.NewRow();
                dr["id"] = mCiu.Id_Ciudad;
                dr["nombre"] = mCiu.Nombre;
                dt.Rows.Add(dr);
            }

            this.dl_ciudad.List(dt, "ciudad");


        }

        protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
        {
            //this.gvOrders.DataSource = null;
            //this.gvOrders.DataBind();
            

            //this.gr_dato_pesos_familia.DataSource = null;
            //this.gr_dato_pesos_familia.DataBind();

            if (tab_datos.ActiveTabIndex==0)
            {
                if (this.gvOrders.Columns.Count == 0)
                {
                    LoadGridOrders();
                    this.ib_exportar.Visible = true;
                }
            }
            if (tab_datos.ActiveTabIndex == 1)
            {
                if (this.gr_dato_pesos_familia.Columns.Count == 0)
                {
                    LoadGridOrdersMonto();
                    this.ib_exportar_monto.Visible = true;
                }
            }
            if (tab_datos.ActiveTabIndex == 2)
            {
                if (this.gr_dt_saldo.Columns.Count == 0)
                {
                    LoadGridOrdersReembolso();
                    this.ib_exportar_devolucion.Visible = true;
                }
            }
            if (tab_datos.ActiveTabIndex == 3)
            {
                if (this.gr_tramite.Columns.Count == 0)
                {
                    LoadGridOrderstramite();
                    this.ib_exportar_tramite.Visible = true;
                }
            }
            
            this.ib_gestion.Visible = false;
            this.ib_gestion.NavigateUrl = "../operacion/mGridDinaGestion.aspx?desde=" + this.txt_desde.Text + "&hasta=" + this.txt_hasta.Text + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(this.dl_cliente.getvalue()) + "&codigo=" + FuncionGlobal.FuctionEncriptar("0") + "&id_ciudad=" + FuncionGlobal.FuctionEncriptar(this.dl_ciudad.getvalue()) + "&tipo=" + "0";
        }

        protected void ddl_comuna_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dll_ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddl_region_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar_ciudad();
        }

        protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Int32 familia = 0;

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            familia = Convert.ToInt32(this.gvOrders.DataKeys[e.Row.RowIndex].Values[0].ToString());

            string cliente = "0";
            if (this.dl_cliente.getvalue() != "")
            {
                cliente = this.dl_cliente.getvalue();
            }

            string ciudad = "0";
            if (this.dl_ciudad.getvalue() != "")
            {
                ciudad = this.dl_ciudad.getvalue();
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvOrders, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
         
           
            
        }
       
      
        protected void gvOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOrders.PageIndex = e.NewPageIndex;

            //LoadGridOrders();
        }

        protected void gvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_familia = 0;
            Label mlabel = new Label();
            this.gvDetails.DataSource = null;
            this.gvDetails.DataBind();
            this.gvDetails.Visible = false;
            
           while (gvDetails.Columns.Count>0)
            {
                gvDetails.Columns.RemoveAt(0);
              
            }
            //this.gvDetails.DataBind();

            foreach (GridViewRow row in gvOrders.Rows)
            {
                if (row.RowIndex == gvOrders.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    id_familia = Convert.ToInt32(this.gvOrders.DataKeys[row.RowIndex].Values[0].ToString());

                    if (this.gvDetails.Visible != true)
                    {
                        BindGrid(this.gvDetails, id_familia.ToString(), mlabel, 0, "TBL_REPORTE_PROCESO_COBRANZA_CANTIDAD" + (string)(Session["usrname"]));
                        this.gvDetails.Visible = true;
                    }
                    
                }

                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
               
            }

           
        }
        private void LoadGridOrders()
        {

            string cliente = "0";
            if (this.dl_cliente.getvalue() != "")
            {
               
                cliente = this.dl_cliente.getvalue().Trim();
            }

            string ciudad = "0";
            if (this.dl_ciudad.getvalue() != "")
            {
               
                ciudad = this.dl_ciudad.getvalue().Trim();
            }
            if (this.txt_desde.Text == "")
            {
                this.txt_desde.Text = this.cal_desde.SelectedDate.Value.ToString();
            }

            if (this.txt_hasta.Text == "")
            {
                this.txt_hasta.Text = this.cal_hasta.SelectedDate.Value.ToString();
            }


            string crear_tabla = new Proceso_cierreBC().NewProcesoTabla(this.txt_desde.Text, this.txt_hasta.Text, cliente, "0", ciudad,"0", 0,(string)(Session["usrname"]));

            DataTable oper = new Proceso_cierreBC().procesos_familia(cliente, "0", ciudad, "0", "0", "TBL_REPORTE_PROCESO_COBRANZA_CANTIDAD" + (string)(Session["usrname"]));

            DataTable tabla = oper;
          

            if (this.gvOrders.Columns.Count <= 1)
            {
                foreach (DataColumn colum in tabla.Columns)
                {
                    var columna = new BoundField
                    {
                        DataField = colum.ColumnName,
                        HeaderText = colum.ColumnName,

                    };
                 
                    if (colum.ColumnName == "ID_FAMILIA")
                    {
                        columna.Visible = false;
                    }

               
                    //columna.ItemStyle.Width = 300;

                    columna.ItemStyle.CssClass = "td_centro_grande";
                    columna.HeaderStyle.CssClass = "td_cabecera_grande";

                    gvOrders.Columns.Add(columna);

                    gvOrders.DataBind();

                }

            }

            var dt = new DataTable();
            foreach (DataColumn dc in oper.Columns)
            {
                if (dc.ColumnName.Trim() == "producto")
                {
                    dt.Columns.Add(new DataColumn(dc.ColumnName));
                    dt.Columns.Add(new DataColumn(dc.ColumnName + "_url"));
                }
                else
                {

                    dt.Columns.Add(new DataColumn(dc.ColumnName));

                }
            }


            foreach (DataRow dtRow in oper.Rows)
            {
                DataRow dr = dt.NewRow();
                foreach (DataColumn dc in oper.Columns)
                {
                
                        if (dtRow[dc.ColumnName].ToString().Trim() == "")
                        {
                            dr[dc.ColumnName] = "0";
                        }
                        else
                        {

                            if (char.IsNumber(Convert.ToChar(dtRow[dc.ColumnName].ToString().Substring(0, 1))) == true)
                            {
                                dr[dc.ColumnName] = FuncionGlobal.NumeroConFormato(dtRow[dc.ColumnName].ToString().Trim());
                            }
                            else
                            {
                                dr[dc.ColumnName] = dtRow[dc.ColumnName].ToString().Trim();
                            }


                           
                        }

                    
                }
                
                dt.Rows.Add(dr);
            }


            this.gvOrders.AutoGenerateColumns = false;
            
            this.gvOrders.DataSource = dt;
            this.gvOrders.DataBind();
        }

       

        private void BindGrid(GridView gvDetails, string lCustomerType, Label label,Int32 tipo,string nombre_tabla)
        {

            string cliente = "0";
            if (this.dl_cliente.getvalue() != "")
            {
                cliente = this.dl_cliente.getvalue();
            }

            string ciudad = "0";
            if (this.dl_ciudad.getvalue() != "")
            {
                ciudad = this.dl_ciudad.getvalue();
            }

            DataTable oper = new Proceso_cierreBC().procesos_producto(cliente, "0", ciudad, tipo.ToString(),lCustomerType.Trim(),nombre_tabla);
            const string fancy = "fancybox fancybox.iframe";

            DataTable tabla = oper;
            foreach (DataColumn colum in tabla.Columns)
            {
                int indice = colum.Ordinal;

                if (colum.ColumnName.Trim() == "producto")
                {
                    var columna = new HyperLinkField
                    {
                        DataTextField = colum.ColumnName,
                        HeaderText = colum.ColumnName,
                        DataNavigateUrlFields = new string[]{colum.ColumnName+"_url"},
                    };
                    columna.ControlStyle.CssClass = fancy;

                    columna.ItemStyle.CssClass = "td_centro_grande";
                    columna.HeaderStyle.CssClass = "td_cabecera_grande";
                    gvDetails.Columns.Add(columna);
                    gvDetails.DataBind();
                }
                else
                {
                    var columna = new BoundField
                    {
                        DataField = colum.ColumnName,
                        HeaderText = colum.ColumnName,

                        //ShowHeader = false
                    };

                    if (colum.ColumnName == "codigo")
                    {
                        columna.Visible = false;
                    }
                    if (colum.ColumnName == "Column1")
                    {
                        columna.Visible = false;
                    }
                    if (colum.ColumnName == "Column2")
                    {
                        columna.Visible = false;
                    }
                    if (colum.ColumnName == "ID_FAMILIA")
                    {
                        columna.Visible = false;
                    }
                    if (colum.ColumnName == "FAMILIA")
                    {
                        columna.Visible = false;
                    }
                    //columna.ControlStyle.CssClass = "td_cabecera_chica";

                 
                    //columna.ItemStyle.Width = 300;
                    columna.ItemStyle.CssClass = "td_centro_grande";
                    columna.HeaderStyle.CssClass = "td_cabecera_grande";
                    gvDetails.Columns.Add(columna);
                    gvDetails.DataBind();

                }
               
            }

            var dt = new DataTable();
            foreach (DataColumn dc in oper.Columns)
            {
                if (dc.ColumnName.Trim() == "producto")
                {
                    dt.Columns.Add(new DataColumn(dc.ColumnName));
                    dt.Columns.Add(new DataColumn(dc.ColumnName + "_url"));
                }
                else
                {
                   
                    dt.Columns.Add(new DataColumn(dc.ColumnName));

                }
            }

            foreach (DataRow dtRow in oper.Rows)
            {
                DataRow dr = dt.NewRow();
                 foreach (DataColumn dc in oper.Columns)
                {
                    if (dc.ColumnName.Trim() == "producto")
                    {

                        dr[dc.ColumnName.Trim() + "_url"] = "mGridviewDinamica.aspx?desde=" + this.txt_desde.Text + "&hasta=" + this.txt_hasta.Text + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(this.dl_cliente.getvalue()) + "&codigo=" + FuncionGlobal.FuctionEncriptar(dtRow["codigo"].ToString()) + "&id_ciudad=" + FuncionGlobal.FuctionEncriptar(this.dl_ciudad.getvalue()) + "&tipo=" + tipo.ToString();
                        dr[dc.ColumnName] = dtRow[dc.ColumnName].ToString().Trim();
                    }
                    else
                    {
                        if (dtRow[dc.ColumnName].ToString().Trim() == "")
                        {
                            dr[dc.ColumnName] = "0";
                        }
                        else
                        {

                            if (char.IsNumber(Convert.ToChar(dtRow[dc.ColumnName].ToString().Substring(0, 1))) == true)
                            {
                                dr[dc.ColumnName] = FuncionGlobal.NumeroConFormato(dtRow[dc.ColumnName].ToString().Trim());
                            }
                            else
                            {
                                dr[dc.ColumnName] = dtRow[dc.ColumnName].ToString().Trim();
                            }
                        }
                    }
                }

                dt.Rows.Add(dr);
            }

            gvDetails.AutoGenerateColumns = false;

            gvDetails.DataSource = dt;
            gvDetails.DataBind();
          
        }


    
        protected void gvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            
            //Int16 XX = Convert.ToInt16(this.gvDetailsproducto.DataKeys[e.Row.RowIndex].Values[0].ToString());
            string xx = (string)e.Row.Cells[4].Text.Trim();

        }

        protected void ProductsGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            int si = 0;
            int pe = 0;
            int Sf = 0;
            int sb = 0;
            int sc = 0;
            for (int i = 1; i < gvOrders.Columns.Count; i++)
            {

                string final = "";
                int tamaño = gvOrders.Columns[i].HeaderText.Length;
                int inicio = tamaño - 2;


                final = gvOrders.Columns[i].HeaderText.Substring(inicio, 2);


                if (final == "SI")
                {
                    si = si + 1;
                }
                if (final == "PE")
                {
                    pe = pe + 1;
                }
                if (final == "SF")
                {
                    Sf = Sf + 1;
                }
                if (final == "SB")
                {
                    sb = sb + 1;
                }
                if (final == "SC")
                {
                    sc = sc + 1;
                }

            }
               
    if (e.Row.RowType == DataControlRowType.Header)
    {
        //Creating a gridview object            
       
 
        //Creating a gridview row object
        GridViewRow objgridviewrow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell cellFamilia = new TableCell();
            cellFamilia = new TableCell();
            cellFamilia.Text = "";
            cellFamilia.ColumnSpan = 1;
            cellFamilia.Style.Add("background-color", System.Drawing.Color.LightSkyBlue.Name);
            cellFamilia.HorizontalAlign = HorizontalAlign.Center;
            objgridviewrow.Cells.Add(cellFamilia);

	
 
        //Creating a table cell object
        TableCell objtablecell = new TableCell();
 
        #region Merge cells
 
       
        AddMergedCells(objgridviewrow, objtablecell, si, 
        "SALDO INICIAL", System.Drawing.Color.LightGreen.Name);

        AddMergedCells(objgridviewrow, objtablecell, pe, 
        "PERIODO", System.Drawing.Color.LightSkyBlue.Name);

        AddMergedCells(objgridviewrow, objtablecell, Sf,
        "SALDO FINAL CALCULADO", System.Drawing.Color.LightGreen.Name);

        AddMergedCells(objgridviewrow, objtablecell, sb,
        "SALDO FINAL BASE", System.Drawing.Color.LightSkyBlue.Name);

        AddMergedCells(objgridviewrow, objtablecell, sc,
        "DIFERENCIAS", System.Drawing.Color.LightGreen.Name);

        this.gvOrders.Controls[0].Controls.AddAt(0, objgridviewrow);

        #endregion
    }
       
        }

        protected void AddMergedCells(GridViewRow objgridviewrow,
            TableCell objtablecell, int colspan, string celltext, string backcolor)
        {
            objtablecell = new TableCell();
            objtablecell.Text = celltext;
            objtablecell.ColumnSpan = colspan;
            objtablecell.Style.Add("background-color", backcolor);
            objtablecell.HorizontalAlign = HorizontalAlign.Center;
            objgridviewrow.Cells.Add(objtablecell);
        }

        protected void gvDetail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gr_dato_pesos_familia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_familia = 0;
            Label mlabel = new Label();
            this.gvDetailsPesos_familia.DataSource = null;
            this.gvDetailsPesos_familia.DataBind();
            this.gvDetailsPesos_familia.Visible = false;

            while (gvDetailsPesos_familia.Columns.Count > 0)
            {
                gvDetailsPesos_familia.Columns.RemoveAt(0);

            }
            //this.gvDetails.DataBind();

            foreach (GridViewRow row in gr_dato_pesos_familia.Rows)
            {
                if (row.RowIndex == gr_dato_pesos_familia.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    id_familia = Convert.ToInt32(this.gr_dato_pesos_familia.DataKeys[row.RowIndex].Values[0].ToString());

                    if (this.gvDetailsPesos_familia.Visible != true)
                    {
                        BindGrid(this.gvDetailsPesos_familia, id_familia.ToString(), mlabel, 0, "TBL_REPORTE_PROCESO_COBRANZA_MONTO" + (string)(Session["usrname"]));
                        this.gvDetailsPesos_familia.Visible = true;
                    }

                }

                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }

            }

        }
        protected void gvDetailPesos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gr_dato_cant_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvDetailCantCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

   

        protected void gvDetailPesosfamilia_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            //Int16 XX = Convert.ToInt16(this.gvDetailsproducto.DataKeys[e.Row.RowIndex].Values[0].ToString());
            string xx = (string)e.Row.Cells[4].Text.Trim();

        }
        protected void gvDetailCantCliente_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            //Int16 XX = Convert.ToInt16(this.gvDetailsproducto.DataKeys[e.Row.RowIndex].Values[0].ToString());
            string xx = (string)e.Row.Cells[4].Text.Trim();

        }




  


        protected void gr_dato_pesos_familia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            string cliente = "0";
            if (this.dl_cliente.getvalue() != "")
            {
                cliente = this.dl_cliente.getvalue().Trim();
            }

            string ciudad = "0";
            if (this.dl_ciudad.getvalue() != "")
            {
                ciudad = this.dl_ciudad.getvalue().Trim();
            }
            Int32 id_familia = 0;

            id_familia = Convert.ToInt32(this.gr_dato_pesos_familia.DataKeys[e.Row.RowIndex].Values[0].ToString());

            //DataTable oper = new Proceso_cierreBC().procesos_familia(cliente, "0", ciudad, "1", id_familia.ToString(), "TBL_REPORTE_PROCESO_COBRANZA_MONTO"+(string)(Session["usrname"]));


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gr_dato_pesos_familia, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
         
        }



        //protected void gr_dato_cant_clientes_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
           

        //    if (e.Row.RowType != DataControlRowType.DataRow)
        //        return;

        //    Int32 id_familia = 0;
        //    id_familia = Convert.ToInt32(this.gvOrders.DataKeys[e.Row.RowIndex].Values[0].ToString());

        //    string cliente = "0";
        //    if (this.dl_cliente.getvalue() != "")
        //    {
        //        cliente = this.dl_cliente.getvalue();
        //    }

        //    string ciudad = "0";
        //    if (this.dl_ciudad.getvalue() != "")
        //    {
        //        ciudad = this.dl_ciudad.getvalue();
        //    }

        //    DataTable oper = new Proceso_cierreBC().procesos_familia(cliente, "0", ciudad, "1", id_familia.ToString(), "TBL_REPORTE_PROCESO_COBRANZA_CANTIDAD" + (string)(Session["usrname"]));

   

        //}

        protected void gr_dato_pesos_familia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gr_dato_pesos_familia.PageIndex = e.NewPageIndex;

        }
      
    
        private void LoadGridOrdersMonto()
        {

            string cliente = "0";
            if (this.dl_cliente.getvalue() != "")
            {
                cliente = this.dl_cliente.getvalue();
            }

            string ciudad = "0";
            if (this.dl_ciudad.getvalue() != "")
            {
                ciudad = this.dl_ciudad.getvalue();
            }
            if (this.txt_desde.Text == "")
            {
                this.txt_desde.Text = this.cal_desde.SelectedDate.Value.ToString();
            }

            if (this.txt_hasta.Text == "")
            {
                this.txt_hasta.Text = this.cal_hasta.SelectedDate.Value.ToString();
            }

            string crear_tabla = new Proceso_cierreBC().NewProcesoTabla(this.txt_desde.Text, this.txt_hasta.Text, cliente, "0", ciudad, "1", 0, (string)(Session["usrname"]));

            DataTable oper = new Proceso_cierreBC().procesos_familia(cliente, "0", ciudad, "1", "0", "TBL_REPORTE_PROCESO_COBRANZA_MONTO" + (string)(Session["usrname"]));

        
            DataTable tabla = oper;
        
           
            if (this.gr_dato_pesos_familia.Columns.Count <= 1)
            {
                foreach (DataColumn colum in tabla.Columns)
                {
                    var columna = new BoundField
                    {
                        DataField = colum.ColumnName,
                        HeaderText = colum.ColumnName,

                    };
                    if (colum.ColumnName == "Column1")
                    {
                        columna.Visible = false;
                    }
                    //if (colum.ColumnName == "FAMILIA")
                    //{
                    //    columna.Visible = false;
                    //}
                    if (colum.ColumnName == "Column2")
                    {
                        columna.Visible = false;
                    }
                    if (colum.ColumnName == "ID_FAMILIA")
                    {
                        columna.Visible = false;
                    }

                    columna.ItemStyle.CssClass = "td_centro_grande";
                    columna.HeaderStyle.CssClass = "td_cabecera_grande";

                    gr_dato_pesos_familia.Columns.Add(columna);

                    //gvOrders.DataBind();

                }

            }

            var dt = new DataTable();
            foreach (DataColumn dc in oper.Columns)
            {
                if (dc.ColumnName == "producto")
                {
                    dt.Columns.Add(new DataColumn(dc.ColumnName));
                    dt.Columns.Add(new DataColumn(dc.ColumnName + "_url"));
                }
                else
                {

                    dt.Columns.Add(new DataColumn(dc.ColumnName));

                }
            }

            var dts = new DataTable();
        

            foreach (DataRow dtRow in oper.Rows)
            {
                DataRow dr = dt.NewRow();
                foreach (DataColumn dc in oper.Columns)
                {

                    if (dtRow[dc.ColumnName].ToString().Trim() == "")
                    {
                        dr[dc.ColumnName] = "0";
                    }
                    else
                    {

                        if (char.IsNumber(Convert.ToChar(dtRow[dc.ColumnName].ToString().Substring(0, 1))) == true)
                        {
                            dr[dc.ColumnName] = FuncionGlobal.NumeroConFormato(dtRow[dc.ColumnName].ToString().Trim());
                        }
                        else
                        {
                            dr[dc.ColumnName] = dtRow[dc.ColumnName].ToString().Trim();
                        }
                    }


                }

                dt.Rows.Add(dr);
            }

            this.gr_dato_pesos_familia.AutoGenerateColumns = false;

            this.gr_dato_pesos_familia.DataSource = dt;
            this.gr_dato_pesos_familia.DataBind();
        }


        protected void gr_dato_pesos_familia_RowCreated(object sender, GridViewRowEventArgs e)
        {
            int si = 0;
            int pe = 0;
            int Sf = 0;
            int sb = 0;
            int sc = 0;
            for (int i = 1; i < gr_dato_pesos_familia.Columns.Count; i++)
            {

                string final = "";
                int tamaño = gr_dato_pesos_familia.Columns[i].HeaderText.Length;
                int inicio = tamaño - 2;


                final = gr_dato_pesos_familia.Columns[i].HeaderText.Substring(inicio, 2);


                if (final == "SI")
                {
                    si = si + 1;
                }
                if (final == "PE")
                {
                    pe = pe + 1;
                }
                if (final == "SF")
                {
                    Sf = Sf + 1;
                }
                if (final == "SB")
                {
                    sb = sb + 1;
                }
                if (final == "SC")
                {
                    sc = sc + 1;
                }

            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                //Creating a gridview object            


                //Creating a gridview row object
                GridViewRow objgridviewrow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell cellFamilia = new TableCell();
                cellFamilia = new TableCell();
                cellFamilia.Text = "";
                cellFamilia.ColumnSpan = 1;
                cellFamilia.Style.Add("background-color", System.Drawing.Color.LightSkyBlue.Name);
                cellFamilia.HorizontalAlign = HorizontalAlign.Center;
                objgridviewrow.Cells.Add(cellFamilia);



                //Creating a table cell object
                TableCell objtablecell = new TableCell();

                #region Merge cells


                AddMergedCells(objgridviewrow, objtablecell, si,
                "SALDO INICIAL", System.Drawing.Color.LightGreen.Name);

                AddMergedCells(objgridviewrow, objtablecell, pe,
                "PERIODO", System.Drawing.Color.LightSkyBlue.Name);

                AddMergedCells(objgridviewrow, objtablecell, Sf,
                "SALDO FINAL CALCULADO", System.Drawing.Color.LightGreen.Name);

                AddMergedCells(objgridviewrow, objtablecell, sb,
                "SALDO BASE FINAL", System.Drawing.Color.LightSkyBlue.Name);

                AddMergedCells(objgridviewrow, objtablecell, sc,
               "DIFERENCIAS", System.Drawing.Color.LightGreen.Name);

                this.gr_dato_pesos_familia.Controls[0].Controls.AddAt(0, objgridviewrow);

                #endregion
            }

        }



      
//DESDE AQUI COMIENZA LOS 2 ULTIMOS TAB



        protected void gr_dt_saldo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Int32 familia = 0;

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            familia = Convert.ToInt32(this.gr_dt_saldo.DataKeys[e.Row.RowIndex].Values[0].ToString());

            string cliente = "0";
            if (this.dl_cliente.getvalue() != "")
            {
                cliente = this.dl_cliente.getvalue();
            }

            string ciudad = "0";
            if (this.dl_ciudad.getvalue() != "")
            {
                ciudad = this.dl_ciudad.getvalue();
            }

            //DataTable oper = new Proceso_cierreBC().procesos_familia(cliente, "0", ciudad, "3", familia.ToString(), "TBL_REPORTE_PROCESO_COBRANZA_REEMBOLSO" + (string)(Session["usrname"]));
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gr_dt_saldo, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }

        }
      
        private void LoadGridOrdersReembolso()
        {

            string cliente = "0";
            if (this.dl_cliente.getvalue() != "")
            {
                cliente = this.dl_cliente.getvalue();
            }

            string ciudad = "0";
            if (this.dl_ciudad.getvalue() != "")
            {
                ciudad = this.dl_ciudad.getvalue();
            }
            if (this.txt_desde.Text == "")
            {
                this.txt_desde.Text = this.cal_desde.SelectedDate.Value.ToString();
            }

            if (this.txt_hasta.Text == "")
            {
                this.txt_hasta.Text = this.cal_hasta.SelectedDate.Value.ToString();
            }

            string crear_tabla = new Proceso_cierreBC().NewProcesoTabla(this.txt_desde.Text, this.txt_hasta.Text, cliente, "0", ciudad, "3", 0, (string)(Session["usrname"]));

            DataTable oper = new Proceso_cierreBC().procesos_familia(cliente, "0", ciudad, "3", "0", "TBL_REPORTE_PROCESO_COBRANZA_REEMBOLSO" + (string)(Session["usrname"]));


            DataTable tabla = oper;
         

        
            if (this.gr_dt_saldo.Columns.Count <= 1)
            {
                foreach (DataColumn colum in tabla.Columns)
                {
                    var columna = new BoundField
                    {
                        DataField = colum.ColumnName,
                        HeaderText = colum.ColumnName,

                    };
                    if (colum.ColumnName == "Column1")
                    {
                        columna.Visible = false;
                    }
                    //if (colum.ColumnName == "familia")
                    //{
                    //    columna.Visible = false;
                    //}
                    if (colum.ColumnName == "Column2")
                    {
                        columna.Visible = false;
                    }
                    if (colum.ColumnName == "ID_FAMILIA")
                    {
                        columna.Visible = false;
                    }

                    columna.ItemStyle.CssClass = "td_centro_grande";
                    columna.HeaderStyle.CssClass = "td_cabecera_grande";

                    gr_dt_saldo.Columns.Add(columna);

                    //gvOrders.DataBind();

                }

            }

            var dt = new DataTable();
            foreach (DataColumn dc in oper.Columns)
            {
                if (dc.ColumnName == "producto")
                {
                    dt.Columns.Add(new DataColumn(dc.ColumnName));
                    dt.Columns.Add(new DataColumn(dc.ColumnName + "_url"));
                }
                else
                {

                    dt.Columns.Add(new DataColumn(dc.ColumnName));

                }
            }

          

            foreach (DataRow dtRow in oper.Rows)
            {
                DataRow dr = dt.NewRow();
                foreach (DataColumn dc in oper.Columns)
                {

                    if (dtRow[dc.ColumnName].ToString().Trim() == "")
                    {
                        dr[dc.ColumnName] = "0";
                    }
                    else
                    {

                        if (char.IsNumber(Convert.ToChar(dtRow[dc.ColumnName].ToString().Substring(0, 1))) == true)
                        {
                            dr[dc.ColumnName] = FuncionGlobal.NumeroConFormato(dtRow[dc.ColumnName].ToString().Trim());
                        }
                        else
                        {
                            dr[dc.ColumnName] = dtRow[dc.ColumnName].ToString().Trim();
                        }

                       
                    }


                }

                dt.Rows.Add(dr);
            }



            this.gr_dt_saldo.AutoGenerateColumns = false;

            this.gr_dt_saldo.DataSource = dt;
            this.gr_dt_saldo.DataBind();
        }

       
       

        protected void gvDetailTramite_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gr_dt_saldo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_familia = 0;
            Label mlabel = new Label();
            this.gvDetailsSaldo.DataSource = null;
            this.gvDetailsSaldo.DataBind();
            this.gvDetailsSaldo.Visible = false;

            while (gvDetailsSaldo.Columns.Count > 0)
            {
                gvDetailsSaldo.Columns.RemoveAt(0);

            }
            //this.gvDetails.DataBind();

            foreach (GridViewRow row in gr_dt_saldo.Rows)
            {
                if (row.RowIndex == gr_dt_saldo.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    id_familia = Convert.ToInt32(this.gr_dt_saldo.DataKeys[row.RowIndex].Values[0].ToString());

                    if (this.gvDetailsSaldo.Visible != true)
                    {
                        BindGrid(this.gvDetailsSaldo, id_familia.ToString(), mlabel, 0, "TBL_REPORTE_PROCESO_COBRANZA_REEMBOLSO" + (string)(Session["usrname"]));
                        this.gvDetailsSaldo.Visible = true;
                    }

                }

                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }

            }
            
        }
        protected void gvDetailSaldo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void gr_dt_tramite_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_familia = 0;
            Label mlabel = new Label();
            this.gvDetailsTramite.DataSource = null;
            this.gvDetailsTramite.DataBind();
            this.gvDetailsTramite.Visible = false;

            while (gvDetailsTramite.Columns.Count > 0)
            {
                gvDetailsTramite.Columns.RemoveAt(0);

            }
            //this.gvDetails.DataBind();

            foreach (GridViewRow row in gr_tramite.Rows)
            {
                if (row.RowIndex == gr_tramite.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    id_familia = Convert.ToInt32(this.gr_tramite.DataKeys[row.RowIndex].Values[0].ToString());

                    if (this.gvDetailsTramite.Visible != true)
                    {
                        BindGrid(this.gvDetailsTramite, id_familia.ToString(), mlabel, 0, "TBL_REPORTE_PROCESO_COBRANZA_FACTURA" + (string)(Session["usrname"]));
                        this.gvDetailsTramite.Visible = true;
                    }

                }

                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }

            }
        }

        protected void gvDetailTramite_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            //Int16 XX = Convert.ToInt16(this.gvDetailsproducto.DataKeys[e.Row.RowIndex].Values[0].ToString());
            string xx = (string)e.Row.Cells[4].Text.Trim();

        }

        protected void gvDetailSaldoe_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            //Int16 XX = Convert.ToInt16(this.gvDetailsproducto.DataKeys[e.Row.RowIndex].Values[0].ToString());
            string xx = (string)e.Row.Cells[4].Text.Trim();

        }


        protected void gr_dt_tramite_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            string cliente = "0";
            if (this.dl_cliente.getvalue() != "")
            {
                cliente = this.dl_cliente.getvalue();
            }

            string ciudad = "0";
            if (this.dl_ciudad.getvalue() != "")
            {
                ciudad = this.dl_ciudad.getvalue();
            }
            Int32 id_familia = 0;

            id_familia = Convert.ToInt32(this.gr_tramite.DataKeys[e.Row.RowIndex].Values[0].ToString());

            //DataTable oper = new Proceso_cierreBC().procesos_familia(cliente, "0", ciudad, "2", id_familia.ToString(), "TBL_REPORTE_PROCESO_COBRANZA_FACTURA" + (string)(Session["usrname"]));

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gr_tramite, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
    

        }

        protected void gr_dt_tramite_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gr_tramite.PageIndex = e.NewPageIndex;

        }

        protected void gr_dt_saldo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gr_dt_saldo.PageIndex = e.NewPageIndex;

        }
       

        private void LoadGridOrderstramite()
        {

            string cliente = "0";
            if (this.dl_cliente.getvalue() != "")
            {
                cliente = this.dl_cliente.getvalue();
            }

            string ciudad = "0";
            if (this.dl_ciudad.getvalue() != "")
            {
                ciudad = this.dl_ciudad.getvalue();
            }
            if (this.txt_desde.Text == "")
            {
                this.txt_desde.Text = this.cal_desde.SelectedDate.Value.ToString();
            }

            if (this.txt_hasta.Text == "")
            {
                this.txt_hasta.Text = this.cal_hasta.SelectedDate.Value.ToString();
            }

            string crear_tabla = new Proceso_cierreBC().NewProcesoTabla(this.txt_desde.Text, this.txt_hasta.Text, cliente,"0", ciudad, "2", 0, (string)(Session["usrname"]));

            DataTable oper = new Proceso_cierreBC().procesos_familia(cliente, "0", ciudad, "2", "0", "TBL_REPORTE_PROCESO_COBRANZA_FACTURA" + (string)(Session["usrname"]));


            DataTable tabla = oper;
          

            if (this.gr_tramite.Columns.Count <= 1)
            {
                foreach (DataColumn colum in tabla.Columns)
                {
                    var columna = new BoundField
                    {
                        DataField = colum.ColumnName,
                        HeaderText = colum.ColumnName,

                    };
                    if (colum.ColumnName == "Column1")
                    {
                        columna.Visible = false;
                    }
                    //if (colum.ColumnName == "familia")
                    //{
                    //    columna.Visible = false;
                    //}
                    if (colum.ColumnName == "Column2")
                    {
                        columna.Visible = false;
                    }
                    if (colum.ColumnName == "ID_FAMILIA")
                    {
                        columna.Visible = false;
                    }

                    columna.ItemStyle.CssClass = "td_centro_grande";
                    columna.HeaderStyle.CssClass = "td_cabecera_grande";
                    gr_tramite.Columns.Add(columna);

                    //gvOrders.DataBind();

                }

            }

            var dt = new DataTable();
            foreach (DataColumn dc in oper.Columns)
            {
                if (dc.ColumnName == "producto")
                {
                    dt.Columns.Add(new DataColumn(dc.ColumnName));
                    dt.Columns.Add(new DataColumn(dc.ColumnName + "_url"));
                }
                else
                {

                    dt.Columns.Add(new DataColumn(dc.ColumnName));

                }
            }

          

            foreach (DataRow dtRow in oper.Rows)
            {
                DataRow dr = dt.NewRow();
                foreach (DataColumn dc in oper.Columns)
                {

                    if (dtRow[dc.ColumnName].ToString().Trim() == "")
                    {
                        dr[dc.ColumnName] = "0";
                    }
                    else
                    {

                        if (char.IsNumber(Convert.ToChar(dtRow[dc.ColumnName].ToString().Substring(0, 1))) == true)
                        {
                            dr[dc.ColumnName] = FuncionGlobal.NumeroConFormato(dtRow[dc.ColumnName].ToString().Trim());
                        }
                        else
                        {
                            dr[dc.ColumnName] = dtRow[dc.ColumnName].ToString().Trim();
                        }
                    }


                }

                dt.Rows.Add(dr);
            }


          

            this.gr_tramite.AutoGenerateColumns = false;

            this.gr_tramite.DataSource = dt;
            this.gr_tramite.DataBind();
        }

  

        protected void ButtongvProducts_Click(object sender, EventArgs e)
        {

        }


        protected void gr_dt_saldo_RowCreated(object sender, GridViewRowEventArgs e)
        {
            int si = 0;
            int pe = 0;
            int Sf = 0;
            int sb = 0;
            int sc = 0;
            for (int i = 1; i < gr_dt_saldo.Columns.Count; i++)
            {

                string final = "";
                int tamaño = gr_dt_saldo.Columns[i].HeaderText.Length;
                int inicio = tamaño - 2;


                final = gr_dt_saldo.Columns[i].HeaderText.Substring(inicio, 2);


                if (final == "SI")
                {
                    si = si + 1;
                }
                if (final == "PE")
                {
                    pe = pe + 1;
                }
                if (final == "SF")
                {
                    Sf = Sf + 1;
                }
                if (final == "SB")
                {
                    sb = sb + 1;
                }
                if (final == "SC")
                {
                    sc = sc + 1;
                }

            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                //Creating a gridview object            


                //Creating a gridview row object
                GridViewRow objgridviewrow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell cellFamilia = new TableCell();
                cellFamilia = new TableCell();
                cellFamilia.Text = "";
                cellFamilia.ColumnSpan = 1;
                cellFamilia.Style.Add("background-color", System.Drawing.Color.LightSkyBlue.Name);
                cellFamilia.HorizontalAlign = HorizontalAlign.Center;
                objgridviewrow.Cells.Add(cellFamilia);



                //Creating a table cell object
                TableCell objtablecell = new TableCell();

                #region Merge cells


                AddMergedCells(objgridviewrow, objtablecell, si,
                "SALDO INICIAL", System.Drawing.Color.LightGreen.Name);

                AddMergedCells(objgridviewrow, objtablecell, pe,
                "PERIODO", System.Drawing.Color.LightSkyBlue.Name);

                AddMergedCells(objgridviewrow, objtablecell, Sf,
                "SALDO FINAL CALCULADO", System.Drawing.Color.LightGreen.Name);

                AddMergedCells(objgridviewrow, objtablecell, sb,
                "SALDO FINAL BASE ", System.Drawing.Color.LightSkyBlue.Name);

                AddMergedCells(objgridviewrow, objtablecell, sc,
               "DIFERENCIAS", System.Drawing.Color.LightGreen.Name);

                this.gr_dt_saldo.Controls[0].Controls.AddAt(0, objgridviewrow);

                #endregion
            }

        }


        protected void gr_dt_tramite_RowCreated(object sender, GridViewRowEventArgs e)
        {
            int si = 0;
            int pe = 0;
            int Sf = 0;
            int sb = 0;
            int sc = 0;
            for (int i = 1; i < gr_tramite.Columns.Count; i++)
            {

                string final = "";
                int tamaño = gr_tramite.Columns[i].HeaderText.Length;
                int inicio = tamaño - 2;


                final = gr_tramite.Columns[i].HeaderText.Substring(inicio, 2);


                if (final == "SI")
                {
                    si = si + 1;
                }
                if (final == "PE")
                {
                    pe = pe + 1;
                }
                if (final == "SF")
                {
                    Sf = Sf + 1;
                }
                if (final == "SB")
                {
                    sb = sb + 1;
                }
                if (final == "SC")
                {
                    sc = sc + 1;
                }

            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                //Creating a gridview object            


                //Creating a gridview row object
                GridViewRow objgridviewrow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell cellFamilia = new TableCell();
                cellFamilia = new TableCell();
                cellFamilia.Text = "";
                cellFamilia.ColumnSpan = 1;
                cellFamilia.Style.Add("background-color", System.Drawing.Color.LightSkyBlue.Name);
                cellFamilia.HorizontalAlign = HorizontalAlign.Center;
                objgridviewrow.Cells.Add(cellFamilia);



                //Creating a table cell object
                TableCell objtablecell = new TableCell();

                #region Merge cells


                AddMergedCells(objgridviewrow, objtablecell, si,
                "SALDO INICIAL", System.Drawing.Color.LightGreen.Name);

                AddMergedCells(objgridviewrow, objtablecell, pe,
                "PERIODO", System.Drawing.Color.LightSkyBlue.Name);

                AddMergedCells(objgridviewrow, objtablecell, Sf,
                "SALDO FINAL CALCULADO", System.Drawing.Color.LightGreen.Name);

                AddMergedCells(objgridviewrow, objtablecell, sb,
                "SALDO FINAL BASE", System.Drawing.Color.LightSkyBlue.Name);

                AddMergedCells(objgridviewrow, objtablecell, sc,
               "DIFERENCIA", System.Drawing.Color.LightGreen.Name);

                this.gr_tramite.Controls[0].Controls.AddAt(0, objgridviewrow);

                #endregion
            }

        }

        protected void ib_exportar_Click(object sender, ImageClickEventArgs e)
        {
          
            string add = "";
            add = new MatrizExcelBC().getMatrizReporteCobranza(Session["usrname"].ToString(),"1");

            string strAlerta = "window.open('http://sistema.agpsa.cl/Reportes_Excel/" + add.ToString().Trim() + "');";
            //string strAlerta = "window.open('http://localhost:51835/Reportes_Excel/" + add.ToString().Trim() + "');";
            //string strAlerta = "window.open('http://192.168.1.253:8080//Export_Excel/" + add.ToString().Trim() + "');";
            //ScriptManager.RegisterStartupScript(up, pPagina.GetType(), "", strAlerta, true);
            ScriptManager.RegisterStartupScript(this.up_arriba, this.up_arriba.GetType(), "", strAlerta, true);

        }

        protected void ib_exportar_monto_Click(object sender, ImageClickEventArgs e)
        {
            string add = "";
            add = new MatrizExcelBC().getMatrizReporteCobranza(Session["usrname"].ToString(),"2");

            string strAlerta = "window.open('http://sistema.agpsa.cl/Reportes_Excel/" + add.ToString().Trim() + "');";
            //string strAlerta = "window.open('http://localhost:51835/Reportes_Excel/" + add.ToString().Trim() + "');";
            //string strAlerta = "window.open('http://192.168.1.253:8080//Export_Excel/" + add.ToString().Trim() + "');";
            //ScriptManager.RegisterStartupScript(up, pPagina.GetType(), "", strAlerta, true);
            ScriptManager.RegisterStartupScript(this.up_arriba, this.up_arriba.GetType(), "", strAlerta, true);

        }

        protected void ib_exportar_devolucion_Click(object sender, ImageClickEventArgs e)
        {
            string add = "";
            add = new MatrizExcelBC().getMatrizReporteCobranza(Session["usrname"].ToString(),"3");

            string strAlerta = "window.open('http://sistema.agpsa.cl/Reportes_Excel/" + add.ToString().Trim() + "');";
            //string strAlerta = "window.open('http://localhost:51835/Reportes_Excel/" + add.ToString().Trim() + "');";
            //string strAlerta = "window.open('http://192.168.1.253:8080//Export_Excel/" + add.ToString().Trim() + "');";
            //ScriptManager.RegisterStartupScript(up, pPagina.GetType(), "", strAlerta, true);
            ScriptManager.RegisterStartupScript(this.up_arriba, this.up_arriba.GetType(), "", strAlerta, true);

        }

        protected void ib_exportar_tramite_Click(object sender, ImageClickEventArgs e)
        {
            string add = "";
            add = new MatrizExcelBC().getMatrizReporteCobranza(Session["usrname"].ToString(),"4");

            string strAlerta = "window.open('http://sistema.agpsa.cl/Reportes_Excel/" + add.ToString().Trim() + "');";
            //string strAlerta = "window.open('http://localhost:51835/Reportes_Excel/" + add.ToString().Trim() + "');";
            //string strAlerta = "window.open('http://192.168.1.253:8080//Export_Excel/" + add.ToString().Trim() + "');";
            //ScriptManager.RegisterStartupScript(up, pPagina.GetType(), "", strAlerta, true);
            ScriptManager.RegisterStartupScript(this.up_arriba, this.up_arriba.GetType(), "", strAlerta, true);

        }

    //    protected void ClientFunction(object sender, EventArgs e)
    //    {
    //        TabContainer container = sender as TabContainer;


    //        if (container.ActiveTabIndex == 0)
    //            {
    //                if (this.gvOrders.Columns.Count == 0)
    //                {
    //                    LoadGridOrders();
    //                }
    //            }
    //        if (container.ActiveTabIndex == 1)
    //            {
    //                LoadGridOrdersMonto();
    //            }
    //        if (container.ActiveTabIndex == 2)
    //            {
    //                LoadGridOrdersReembolso();
    //            }
    //        if (container.ActiveTabIndex == 3)
    //            {
    //                LoadGridOrderstramite();
    //            }
                       
    //    }


    //    protected void clickContaninerTAB(object sender, EventArgs e)
    //    {
    //        TabContainer container = sender as TabContainer;


    //        if (container.ActiveTabIndex == 0)
    //        {
    //            if (this.gvOrders.Columns.Count == 0)
    //            {
    //                LoadGridOrders();
    //            }
    //        }
    //        if (container.ActiveTabIndex == 1)
    //        {
    //            LoadGridOrdersMonto();
    //        }
    //        if (container.ActiveTabIndex == 2)
    //        {
    //            LoadGridOrdersReembolso();
    //        }
    //        if (container.ActiveTabIndex == 3)
    //        {
    //            LoadGridOrderstramite();
    //        }

    //    }



    }


}  