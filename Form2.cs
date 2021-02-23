using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Clases;

namespace produApp
{
	public partial class Form2 : Form
	{
		private StreamWriter wr;
		private StreamReader sr;
		public Form2()
		{
			InitializeComponent();
			Cargar();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.wr = new StreamWriter("config.txt",false);
			if(Comprobar())
			{
				wr.WriteLine(this.textBox1.Text);
				wr.WriteLine(this.textBox3.Text);
				wr.WriteLine(this.textBox4.Text);
				wr.WriteLine(this.textBox6.Text);
				wr.WriteLine(this.textBox2.Text);
				MessageBox.Show("Las opciones fueron aplicadas");
				CargarPostAplicar();
			}
			wr.Close();
		}

		private void CargarPostAplicar()
		{
			Is._poca = float.Parse(this.textBox1.Text);
			Is._mucha = float.Parse(this.textBox3.Text);
			Is._pocaSpd = float.Parse(this.textBox4.Text);
			Is._muchaSpd = float.Parse(this.textBox6.Text);
			Is._extra = float.Parse(this.textBox2.Text);
			sr.Close();
		}
		
		private void Cargar()
		{
			this.sr = new StreamReader("config.txt");
			this.textBox1.Text = sr.ReadLine();
			this.textBox3.Text = sr.ReadLine();
			this.textBox4.Text = sr.ReadLine();
			this.textBox6.Text = sr.ReadLine();
			this.textBox2.Text = sr.ReadLine();
			CargarPostAplicar();
			sr.Close();
		}


		private bool Comprobar()
		{
			if(this.textBox1.Text == "" || this.textBox3.Text == "" || this.textBox2.Text == "" || this.textBox4.Text == "" || this.textBox6.Text == "")
			{
				MessageBox.Show("Falta un parametro");
				return false;
			}
			else
			{
				return true;
			}

		}
	}
}
