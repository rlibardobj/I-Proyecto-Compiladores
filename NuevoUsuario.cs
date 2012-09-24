/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 20/09/2012
 * Time: 06:32 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Active;

namespace Active
{
	/// <summary>
	/// Description of NuevoUsuario.
	/// </summary>
	public partial class NuevoUsuario : Form
	{
		Metodos insMetodos = new Metodos();
		public NuevoUsuario()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			try{
			insMetodos.CrearUsuario(textBox1.Text,textBox2.Text);
			MessageBox.Show("Usuario Creado con Éxito");
			textBox1.Text="";
			textBox2.Text="";
			}
			catch(Exception exc){
				MessageBox.Show(exc.Message.ToString());
			}
		}
	}
}
