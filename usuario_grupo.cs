/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 21/09/2012
 * Time: 01:18 a.m.
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
	/// Description of usuario_grupo.
	/// </summary>
	public partial class usuario_grupo : Form
	{ 
		UserPrincipal usuario;
		GroupPrincipal grupo;
		//int searchFlag=0;
		Metodos insMetodos=new Metodos();
		public usuario_grupo()
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
				textBox1.Text="";
				//searchFlag=1;
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
			if (textBox3.Text!=""){
				grupo=insMetodos.EncontrarGrupo(textBox3.Text);
				if (grupo!=null){
				textBox4.Text=grupo.Name;
				textBox3.Text="";
				//searchFlag=1;
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
		
		void Button3Click(object sender, EventArgs e)
		{
			if( (usuario != null) & (grupo != null) )
			{ try{
				insMetodos.ingresar_usuario_grupo(usuario,grupo);
				}
				catch(Exception exc){
				MessageBox.Show(exc.Message.ToString());
			    }
			}
			else
			{
			     MessageBox.Show("No se ha realizado las búsquedas de usuario y grupo.");
			}
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			if( (usuario != null) & (grupo != null) )
			{ try{
				insMetodos.eliminar_usuario_grupo(usuario,grupo);
				}
				catch(Exception exc){
				MessageBox.Show(exc.Message.ToString());
			    }
			}
			else
			{
			     MessageBox.Show("No se ha realizado las búsquedas de usuario y grupo.");
			}
		}
	}
}
