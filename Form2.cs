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
			this.wr = new StreamWriter("config.txt");
			if(Comprobar())
			{
				wr.WriteLine("Poca:" + this.textBox1.Text);
				wr.WriteLine("Media:" + this.textBox2.Text);
				wr.WriteLine("Mucha:" + this.textBox3.Text);
				wr.WriteLine("Poca:" + this.textBox4.Text);
				wr.WriteLine("Media:" + this.textBox5.Text);
				wr.WriteLine("Mucha:" + this.textBox6.Text);
				MessageBox.Show("Las opciones fueron aplicadas");
				CargarPostAplicar();
			}
			wr.Close();
		}

		private void CargarPostAplicar()
		{
			Form1._poca = float.Parse(this.textBox1.Text);
			Form1._media = float.Parse(this.textBox2.Text);
			Form1._mucha = float.Parse(this.textBox3.Text);
			Form1._pocaSpd = float.Parse(this.textBox4.Text);
			Form1._mediaSpd = float.Parse(this.textBox5.Text);
			Form1._muchaSpd = float.Parse(this.textBox6.Text);
			sr.Close();
		}
		
		private void Cargar()
		{
			this.sr = new StreamReader("config.txt");
			this.textBox1.Text = sr.ReadLine();
			this.textBox2.Text = sr.ReadLine();
			this.textBox3.Text = sr.ReadLine();
			this.textBox4.Text = sr.ReadLine();
			this.textBox5.Text = sr.ReadLine();
			this.textBox6.Text = sr.ReadLine();
			sr.Close();
		}


		private bool Comprobar()
		{
			if(this.textBox1.Text == "" || this.textBox2.Text == "" || this.textBox3.Text == "" || this.textBox4.Text == "" ||
				this.textBox5.Text == "" || this.textBox6.Text == "")
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
