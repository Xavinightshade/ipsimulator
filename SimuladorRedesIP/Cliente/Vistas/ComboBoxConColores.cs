using System.Windows.Forms;
using System.Drawing;
using SimuladorCliente.Vistas;
namespace RedesIP.Vistas
{
	class ComboBoxEx : ComboBox
	{


		public ComboBoxEx()
		{
			DrawMode = DrawMode.OwnerDrawFixed;
		}

		protected override void OnDrawItem(DrawItemEventArgs ea)
		{
			ea.DrawBackground();
			ea.DrawFocusRectangle();

			ComboBoxExItem item;
			Rectangle bounds = ea.Bounds;

			try
			{
				item = (ComboBoxExItem)Items[ea.Index];
				Pen p=new Pen(item.Color,10);
				ea.Graphics.DrawRectangle(p, bounds.X, bounds.Y, 20, bounds.Height);
					
					ea.Graphics.DrawString(item.Marcador.Id.ToString(), ea.Font, new
	  SolidBrush(ea.ForeColor), bounds.Left + 30, bounds.Top);
				

			}
			catch
			{
				if (ea.Index != -1)
				{
					ea.Graphics.DrawString(Items[ea.Index].ToString(), ea.Font, new
	  SolidBrush(ea.ForeColor), bounds.Left, bounds.Top);
				}
				else
				{
					ea.Graphics.DrawString(Text, ea.Font, new
	  SolidBrush(ea.ForeColor), bounds.Left, bounds.Top);
				}
			}

			base.OnDrawItem(ea);
		}
	}

	class ComboBoxExItem
	{
		private Marcador _marcador;
		public Marcador Marcador
		{
			get { return _marcador; }
			set { _marcador = value; }
		}
		private Color _color;

		public Color Color
		{
			get { return _color; }
			set { _color = value; }
		}





		public ComboBoxExItem(Marcador marcador, Color color)
		{
			_marcador=marcador;
			_color = color;
		}


	}
}
