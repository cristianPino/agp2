using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sistemaAGP
{
	public partial class barra_progreso : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			double porcentaje = 0.5;
			if (Request.QueryString["porcentaje"] != null)
				porcentaje = Convert.ToDouble(Request.QueryString["porcentaje"].Replace(".", ","));
			this.Dibujar_Barra(porcentaje);
		}

		protected void Dibujar_Barra(double porcentaje)
		{
			Bitmap bmp = new Bitmap(60, 20);
			Graphics grp = Graphics.FromImage(bmp);
			float width = Convert.ToSingle(porcentaje) * Convert.ToSingle(bmp.Width);
			grp.FillRegion(new SolidBrush(Color.White), new Region(new RectangleF(0F, 0F, Convert.ToSingle(bmp.Width), Convert.ToSingle(bmp.Height))));
			grp.FillRectangle(new SolidBrush(Color.FromArgb(204, 40, 220, 40)), new RectangleF(0F, 0F, width, 20F));
			grp.DrawString(porcentaje.ToString("#0.##%", System.Globalization.CultureInfo.InvariantCulture), new Font("Arial", 12, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(2F, 2F));
			bmp.Save(Response.OutputStream, ImageFormat.Png);
		}
	}
}