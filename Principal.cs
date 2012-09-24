/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 20/09/2012
 * Time: 06:19 p.m.
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
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{
		public Form1()
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
			NuevoUsuario nuevousuario=new NuevoUsuario();
			nuevousuario.Show();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			ModElimUsuario nuevomodelimusuario=new ModElimUsuario();
			nuevomodelimusuario.Show();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			AutUsuario nuevoautusuario=new AutUsuario();
			nuevoautusuario.Show();
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			ReestContraseña nuevoreestcontraseña=new ReestContraseña();
			nuevoreestcontraseña.Show();
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			crear_grupo nuevogrupo = new crear_grupo();
			nuevogrupo.Show();
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			ModElimGrupo grupo = new ModElimGrupo();
			grupo.Show();
		}
		
		void Button7Click(object sender, EventArgs e)
		{
			consultar_miembros ins = new consultar_miembros();
			ins.Show();
		}
		
		void Button8Click(object sender, EventArgs e)
		{
			usuario_grupo inst = new usuario_grupo();
			inst.Show();
			
		}
	}
}
