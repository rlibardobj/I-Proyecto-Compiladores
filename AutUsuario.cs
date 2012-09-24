/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 20/09/2012
 * Time: 08:06 p.m.
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
	/// Ventana para autenticar un usuario.
	/// </summary>
	public partial class AutUsuario : Form
	{
		Metodos insMetodos=new Metodos();
		public AutUsuario()
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
				if (insMetodos.AutenticarUsuario(textBox1.Text,textBox2.Text)){
					textBox1.Text="";
					textBox2.Text="";
					MessageBox.Show("Usuario Válido");
				}
				else{
					MessageBox.Show("Usuario o Contraseña Inválidos");
				}
			}
			catch (Exception exc){
				MessageBox.Show(exc.Message.ToString());
			}
		}
	}
}
