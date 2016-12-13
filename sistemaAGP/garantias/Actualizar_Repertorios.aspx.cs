using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.garantias
{
	public partial class Actualizar_Repertorios : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.lbl_error.Text = "";
				this.lbl_titulo.Text = "";
			}
		}

		protected void bt_procesar_Click(object sender, EventArgs e)
		{
			this.procesarArchivo();
		}

		protected void procesarArchivo()
		{
			if (this.fu_archivo.HasFile)
			{
				FileInfo fi_documento = new FileInfo(this.fu_archivo.FileName);
				if (fi_documento.Extension.ToLower() == ".xls")
				{
					string sSave = string.Format("{0}\\{1}", Server.MapPath("/garantias"), Session["usrname"].ToString().Trim().ToUpper() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + fi_documento.Extension);

					DataTable dt = new DataTable("Observaciones");
					dt.Columns.Add("id_solicitud");
					dt.Columns.Add("observacion");
					dt.Columns.Add("icon");
					try
					{
						this.fu_archivo.PostedFile.SaveAs(sSave);

						//Procesa el archivo
						string strCnn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sSave + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";
						OleDbConnection cnn = new OleDbConnection(strCnn);
						cnn.Open();
						OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Hoja1$]", cnn);
						cmd.CommandType = CommandType.Text;
						OleDbDataReader dr = cmd.ExecuteReader();
						while (dr.Read())
						{
							int id_solicitud;
							DateTime fecha_rnp;
							int repertorio_rnp;
							DateTime fecha_not;
							int repertorio_not;

							DataRow resultado = dt.NewRow();

							if (int.TryParse(dr["id_solicitud"].ToString(), out id_solicitud))
							{
								resultado["id_solicitud"] = id_solicitud;
								if (DateTime.TryParse(dr["fecha_rnp"].ToString(), out fecha_rnp))
								{
									if (int.TryParse(dr["repertorio_rnp"].ToString(), out repertorio_rnp))
									{
										if (DateTime.TryParse(dr["fecha_not"].ToString(), out fecha_not))
										{
											if (int.TryParse(dr["repertorio_not"].ToString(), out repertorio_not))
											{
												try
												{
													Garantia garantia = new GarantiaBC().GetgarantiabyIdSolicitud(id_solicitud);
													if (garantia != null)
													{
														garantia.N_RepertorioRNP = repertorio_rnp.ToString();
														garantia.Fecha_repertorio_rnp = fecha_rnp.ToShortDateString();

														garantia.N_RepertorioNotaria = repertorio_not.ToString();
														garantia.Fecha_repertorio = fecha_not.ToShortDateString();

														string aux = new GarantiaBC().add_Garantia(garantia.Operacion.Id_solicitud, garantia.Adquiriente.Rut, garantia.Cliente.Id_cliente, (garantia.Compra_para != null) ? garantia.Compra_para.Rut : 0, garantia.Creada, (garantia.Compra_repre != null) ? garantia.Compra_repre.Rut : 0,
																										garantia.Repertorio, garantia.N_factura, garantia.Fechafactura, garantia.Sucursal_origen.Id_sucursal, (garantia.Emisor != null) ? garantia.Emisor.Rut : 0, garantia.Monto, garantia.N_cuotas, garantia.Fecha_primera,
																										garantia.Fecha_ultima, garantia.Cta_corriente, garantia.Bancofinanciera, garantia.Titular, garantia.Notario, garantia.Ciudad_notario, garantia.Fecha_contrato, garantia.N_cheques, garantia.Neto,
																										garantia.Tipo_pago_factura, garantia.Factura_intereses, garantia.Fecha_factura_intereses, garantia.Monto_factura_intereses, garantia.Fecha_protocolizacion, garantia.N_protocolizacion, garantia.N_RepertorioNotaria, garantia.N_RepertorioRNP,
																										garantia.Fecha_repertorio, garantia.Oficina_Registro, garantia.Ing_alza_PN_registro, garantia.Ing_alza_PH_registro, garantia.N_solicitud_PN_registro, garantia.N_solicitud_PH_registro, garantia.NombreEstado, garantia.FechaUltimoEstado,
																										garantia.Valor_vehiculo, garantia.Monto_pie, garantia.Factura_gastos, garantia.Fecha_factura_gastos, garantia.Monto_factura_gastos, garantia.Nro_credito, garantia.Doc_fundante, garantia.Solicitante,
																										garantia.Notaria_protocolizacion, garantia.Ciudad_notaria_protocolizacion, garantia.Fecha_repertorio_rnp, garantia.Estado_solicitud_rnp, garantia.Estado_prenda, garantia.Observaciones, garantia.Cav_comprado, garantia.Nro_declaracion,garantia.Fecha_pagare,
                                                                                                        garantia.Valor_Cuotas,garantia.Capital_pagare,garantia.Tasa,garantia.Dia);
														if (aux == "")
														{
															resultado["observacion"] = "Actualizada exitosamente";
															resultado["icon"] = "../imagenes/sistema/static/109_AllAnnotations_Default_16x16_72.png";
														}
														else
														{
															resultado["observacion"] = aux;
															resultado["icon"] = "../imagenes/sistema/static/109_AllAnnotations_Error_16x16_72.png";
														}
													}
													else
													{
														resultado["observacion"] = "No se encontró la operación solicitada";
														resultado["icon"] = "../imagenes/sistema/static/109_AllAnnotations_Info_16x16_72.png";
													}
												}
												catch (Exception ex)
												{
													resultado["observacion"] = ex.Message;
													resultado["icon"] = "../imagenes/sistema/static/109_AllAnnotations_Error_16x16_72.png";
												}
											}
											else
											{
												resultado["id_solicitud"] = id_solicitud;
												resultado["observacion"] = "Número Repertorio Notaría: El valor '" + dr["repertorio_not"].ToString() + "' no es un número válido";
												resultado["icon"] = "../imagenes/sistema/static/109_AllAnnotations_Error_16x16_72.png";
											}
										}
										else
										{
											resultado["id_solicitud"] = id_solicitud;
											resultado["observacion"] = "Fecha Repertorio Notaría: El valor '" + dr["fecha_not"].ToString() + "' no es una fecha válida";
											resultado["icon"] = "../imagenes/sistema/static/109_AllAnnotations_Error_16x16_72.png";
										}
									}
									else
									{
										resultado["id_solicitud"] = id_solicitud;
										resultado["observacion"] = "Número Repertorio RNP: El valor '" + dr["repertorio_rnp"].ToString() + "' no es un número válido";
										resultado["icon"] = "../imagenes/sistema/static/109_AllAnnotations_Error_16x16_72.png";
									}
								}
								else
								{
									resultado["id_solicitud"] = id_solicitud;
									resultado["observacion"] = "Fecha Repertorio RNP: El valor '" + dr["fecha_rnp"].ToString() + "' no es una fecha válida";
									resultado["icon"] = "../imagenes/sistema/static/109_AllAnnotations_Error_16x16_72.png";
								}
							}
							else
							{
								resultado["id_solicitud"] = dr["id_solicitud"].ToString();
								resultado["observacion"] = "Id. Solicitud: El valor '" + dr["id_solicitud"].ToString() + "' no es un número válido";
								resultado["icon"] = "../imagenes/sistema/static/109_AllAnnotations_Error_16x16_72.png";
							}
							dt.Rows.Add(resultado);
						}
						dr.Close();
						cnn.Close();
						cnn.Dispose();
						if (File.Exists(sSave)) File.Delete(sSave);

						this.lbl_titulo.Text = this.fu_archivo.PostedFile.FileName;
						this.gr_info.DataSource = dt;
						this.gr_info.DataBind();

					}
					catch (Exception ex)
					{
						this.lbl_error.Text = string.Format("Error al subir el archivo {0}\n\n{1}", this.fu_archivo.FileName, ex.Message);
					}
				}
				else
				{
					this.lbl_error.Text = "Debe seleccionar un archivo en formato Excel 97-2003 (.xls)";
				}
			}
			else
			{
				this.lbl_error.Text = "No se ha seleccionado ningún archivo";
			}
		}
	}
}