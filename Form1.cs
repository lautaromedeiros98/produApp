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
using System.Diagnostics;

namespace produApp
{
	public partial class Form1 : Form
	{
		public ExcelReader reader;
		private List<Is> _listaIs = new List<Is>();

		public static float _poca;
		public static float _media;
		public static float _mucha;
		public static float _pocaSpd;
		public static float _mediaSpd;
		public static float _muchaSpd;
		public Form1()
		{
			InitializeComponent();
		}
		

		private void Form1_Load(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
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
					Is isaux = new Is(varAux[0], varAux[1],float.Parse(varAux[5]), float.Parse(varAux[6]), float.Parse(varAux[7]));
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
			foreach(Is aux in this._listaIs)
			{
				if(IsRe.Equals(aux.NumeroIs))
				{
					MessageBox.Show(aux.ToString());
					this.linkLabel1.Text = "wms.mercadolibre.com.ar/reports/shiping-inbound/" + aux.NumeroIs;
					this.linkLabel2.Text = "wms.mercadolibre.com/reports/shiping-inbound/" + aux.NumeroIs;
					this.textBox1.Text = "";
					this.richTextBox1.Text += aux.ToString();
					this.richTextBox1.Text += "\n ---------------- \n";
					return true;
				}
			}
			return false;
		}

		private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
		{
			string aux = "";
			if (e.KeyChar == (char)13)
			{
				if(this.textBox1.Text.Length>7)
				{
					aux=this.textBox1.Text.Substring(0, 7);
					if (!this.mostrarProdu(aux))
					{
						MessageBox.Show("La is no existe en el reporte");
						this.textBox1.Text = "";
					}
				}
				else
				{
					if(!this.mostrarProdu(textBox1.Text))
					{
						MessageBox.Show("La is no existe en el reporte");
						this.textBox1.Text = "";
					}
				}
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://"+linkLabel1.Text);
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://" + linkLabel2.Text);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.richTextBox1.Text = "";
		}

		private void calibrarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form2 formularioCalibrar = new Form2();
			formularioCalibrar.Show();
		}
	}
}
