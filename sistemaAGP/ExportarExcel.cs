using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace sistemaAGP
{
	public static class ExportarExcel
	{
		public static void ExportStoredProcedure(string fileName, string commandText, SqlParameter[] param)
		{
			HttpContext.Current.Response.Clear();
			HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
			HttpContext.Current.Response.Charset = "UTF-8";
			HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
			HttpContext.Current.Response.ContentType = "application/ms-excel";
			using (StringWriter sw = new StringWriter())
			{
				using (HtmlTextWriter htw = new HtmlTextWriter(sw))
				{
					//Crear la tabla que contendrá los datos
					Table table = new Table();
					using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONECCION"].ConnectionString))
					{
						//Agrega las cabeceras
						TableRow row = new TableRow();

						cnn.Open();
						SqlCommand cmd = new SqlCommand(commandText, cnn);
						cmd.CommandType = CommandType.StoredProcedure;

						if (param.Length > 0)
							cmd.Parameters.AddRange(param);

						SqlDataReader dr = cmd.ExecuteReader();
						
						for (int col = 0; col < dr.FieldCount; col++){
							TableCell cell = new TableCell();
							cell.Style.Add(HtmlTextWriterStyle.Color, "#000000");
							cell.Style.Add(HtmlTextWriterStyle.FontSize, "10pt");
							cell.Style.Add(HtmlTextWriterStyle.FontWeight, "bold");
							cell.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
							cell.Text = dr.GetName(col);
							row.Cells.Add(cell);
						}
						table.Rows.Add(row);

						while (dr.Read())
						{
							row = new TableRow();
							for (int col = 0; col < dr.FieldCount; col++)
							{
								TableCell cell = new TableCell();
								cell.Style.Add(HtmlTextWriterStyle.Color, "#000000");
								cell.Style.Add(HtmlTextWriterStyle.FontSize, "10pt");
								cell.Style.Add(HtmlTextWriterStyle.FontWeight, "normal");
								if (dr.GetDataTypeName(col).ToUpper() == "DECIMAL" || dr.GetDataTypeName(col).ToUpper() == "NUMERIC" || dr.GetDataTypeName(col).ToUpper() == "REAL" || dr.GetDataTypeName(col).ToUpper() == "FLOAT" || dr.GetDataTypeName(col).ToUpper() == "DOUBLE" || dr.GetDataTypeName(col).ToUpper() == "")
								{
									cell.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
									cell.Text = Convert.ToDouble(dr[col]).ToString("N");
								}
								else if (dr.GetDataTypeName(col).ToUpper() == "SMALLINT" || dr.GetDataTypeName(col).ToUpper() == "INTEGER" || dr.GetDataTypeName(col).ToUpper() == "TINYINT" || dr.GetDataTypeName(col).ToUpper() == "BIGINT")
								{
									cell.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
									cell.Text = Convert.ToInt64(dr[col]).ToString("N");
								}
								else if (dr.GetDataTypeName(col).ToUpper() == "DATE" || dr.GetDataTypeName(col).ToUpper() == "INTEGER" || dr.GetDataTypeName(col).ToUpper() == "DATETIME")
								{
									cell.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
									cell.Text = Convert.ToDateTime(dr[col]).ToString("dd-MM-yyyy");
								}
								else if (dr.GetDataTypeName(col).ToUpper() == "TIME")
								{
									cell.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
									cell.Text = Convert.ToDateTime(dr[col]).ToString("hh:mm:ss");
								}
								else if (dr.GetDataTypeName(col).ToUpper() == "TIMESTAMP")
								{
									cell.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
									cell.Text = Convert.ToDateTime(dr[col]).ToString();
								}
								else
								{
									cell.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
									cell.Text = dr[col].ToString();
								}
								row.Cells.Add(cell);
							}
							table.Rows.Add(row);
						}
						cnn.Close();
					}
					table.RenderControl(htw);
					HttpContext.Current.Response.Write(sw.ToString());
				}
			}
			HttpContext.Current.Response.End();
		}
	}
}