using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.IO;
using Clases;
namespace produApp
{
	public partial class Form1 : Form
	{
		public ExcelReader reader;
		private List<Is> _listaIs = new List<Is>();
		public Form1()
		{
			InitializeComponent();
		}
		

		private void Form1_Load(object sender, EventArgs e)
		{
			openFileDialog1 = new OpenFileDialog();
			this.textBox1.Focus();
				if (openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					this.reader = new ExcelReader(openFileDialog1.FileName);
					this.Cargar();
				}
			
		}

		private void Cargar()
		{
			string sr = this.reader.Read(openFileDialog1.FileName);
			string[] a= sr.Split('\n');
			string[] varAux;
			foreach (string aux in a)
			{
				if(!string.IsNullOrEmpty(aux))
				{
					varAux = aux.Split(',');
					Is isaux = new Is(varAux[0], varAux[1], float.Parse(varAux[6]), float.Parse(varAux[7]));
					this._listaIs.Add(isaux);
				}
				else
				{
					break;
				}
			}
		}

		private bool mostrarProdu(string IsRe)
		{
			if(textBox1.Text.Equals("raul"))
			{
				MessageBox.Show("RAULITO MAQUINA, LAUTICUEVAS GIL");
				textBox1.Text = "";
			}
			foreach(Is aux in this._listaIs)
			{
				if(IsRe.Equals(aux.NumeroIs))
				{
					if(aux.Unidades<150)
					{
						MessageBox.Show("POCA PRODU!!! \nLa is tiene " + aux.Unidades + " unidades");
					}
					else
					{
						if(aux.Unidades>150 && aux.Unidades<250)
						{
							MessageBox.Show("MASO MASO!!! \nLa is tiene " + aux.Unidades + " unidades");
						}
						else if(aux.Unidades>250)
						{
							MessageBox.Show("BUENA PRODU!!! \nLa is tiene " + aux.Unidades + " unidades");
						}
					}
					this.textBox1.Text = "";
					return true;
				}
			}
			return false;
		}

		private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				if(!this.mostrarProdu(this.textBox1.Text))
				{
					MessageBox.Show("La is no existe en el reporte seleccionado");
				}
			}
		}
	}
}
