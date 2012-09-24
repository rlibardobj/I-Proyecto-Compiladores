/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 21/09/2012
 * Time: 11:54 a.m.
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
	/// Description of consultar_miembros.
	/// </summary>

	
	public partial class consultar_miembros : Form
	{
		GroupPrincipal grupo;
		int searchFlag=0;
		Metodos insMetodos=new Metodos();
		public consultar_miembros()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		
		
		public void Button1Click(object sender, EventArgs e)
		{
			try{
			if (textBox1.Text!=""){
				grupo=insMetodos.EncontrarGrupo(textBox1.Text);
						    
				//textBox2.Text=grupo.Name;
				//textBox3.Text=grupo.Description;
				textBox1.Text="";
				if (grupo!=null){
					
				foreach(UserPrincipal user in grupo.GetMembers()){
                   listBox1.Items.Add(user);
                 }	
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
	}
}
