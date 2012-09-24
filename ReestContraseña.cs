/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 20/09/2012
 * Time: 08:07 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;
using Active;

namespace Active
{
	/// <summary>
	/// Description of ReestContraseña.
	/// </summary>
	public partial class ReestContraseña : Form
	{
		UserPrincipal usuario;
		Metodos insMetodos = new Metodos();
		int searchFlag=0;
		public ReestContraseña()
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
			if (textBox1.Text!=""){
				usuario=insMetodos.EncontrarUsuario(textBox1.Text);
				if (usuario!=null){
					searchFlag=1;
					MessageBox.Show("La búsqueda ha sido exitosa.");
				}
				else{
					MessageBox.Show("La búsqueda no obtuvo resultados.");
				}
			}
			else{
					MessageBox.Show("No se ha ingresado un nombre para realizar la búsqueda.");
			}
			}
			catch(Exception exc){
				MessageBox.Show(exc.Message.ToString());
			}						
		}
		
		void Label2Click(object sender, EventArgs e)
		{
			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			try{
				if (searchFlag!=0){
					if (textBox2.Text!=""){
						insMetodos.ReestablecerContraseña(usuario,textBox2.Text);
						MessageBox.Show("Contraseña Reestablecida con Éxito.");
						textBox2.Text="";
						searchFlag=0;
						textBox1.Text="";
					}
					else{
						MessageBox.Show("No se ingreso nada en el campo para la contraseña.");
					}
				}
				else{
					MessageBox.Show("No se ha realizado ninguna búsqueda.");
				}
			}
			catch (Exception exc){
				MessageBox.Show(exc.Message.ToString());
			}
		}
	}
}
