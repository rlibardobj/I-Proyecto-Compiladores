/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 20/09/2012
 * Time: 10:03 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Active
{
	/// <summary>
	/// Description of crear_grupo.
	/// </summary>
	public partial class crear_grupo : Form
	{
		Metodos insMetodos = new Metodos();
		public crear_grupo()
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
			
			if( (textBox1.Text.Equals("")) | (comboBox1.Text.Equals("Seleccione")) | (comboBox2.Equals("Seleccione")))
			{MessageBox.Show("Seleccione los datos");}
			else {
				
				   try{
			          insMetodos.CrearGrupo(textBox1.Text,comboBox1.Text,comboBox2.Text);
			          MessageBox.Show("Grupo Creado con Éxito");
			          textBox1.Text="";
			          
			          }
			       catch(Exception exc){
			       	MessageBox.Show(exc.Message.ToString());
			}
				 
			     }
			
		}
	}
}
