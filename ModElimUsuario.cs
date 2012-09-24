/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 20/09/2012
 * Time: 07:07 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Active;
using System.DirectoryServices.AccountManagement;

namespace Active
{
	/// <summary>
	/// Ventana para eliminar o modificar un usuario.
	/// </summary>
	public partial class ModElimUsuario : Form
	{
		UserPrincipal usuario;
		int searchFlag=0;
		Metodos insMetodos=new Metodos();
		public ModElimUsuario()
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
				textBox2.Text=usuario.DisplayName;
				textBox3.Text=usuario.Description;
				textBox1.Text="";
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
		
		void Button2Click(object sender, EventArgs e)
		{
			try{
			if (searchFlag!=0){
				insMetodos.ModificarUsuario(usuario,textBox2.Text,textBox3.Text);
				MessageBox.Show("Usuario modificado con Éxito");
				textBox2.Text="";
				textBox3.Text="";
				searchFlag=0;
			}
			else{
				MessageBox.Show("Debe buscar un usuario primero.");
			}
			}
			catch(Exception exc){
				MessageBox.Show(exc.Message.ToString());
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			try{
			if (searchFlag!=0){
				insMetodos.EliminarUsuario(usuario);
				MessageBox.Show("Usuario eliminado con Éxito");
				textBox2.Text="";
				textBox3.Text="";
				searchFlag=0;
			}
			else{
				MessageBox.Show("Debe buscar un usuario primero.");
			}
			}
			catch(Exception exc){
				MessageBox.Show(exc.Message.ToString());
			}
		}
	}
}
