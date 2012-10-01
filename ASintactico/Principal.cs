/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 01/10/2012
 * Time: 09:12 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ASintactico
{
	/// <summary>
	/// Description of Principal.
	/// </summary>
	public partial class Principal : Form
	{
		string path;
		public Principal()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			string texto;
			if (tabControl1.SelectedTab!=null){
			string tab=tabControl1.SelectedTab.Text;
			for (int i = 0; i < tabControl1.TabPages.Count; i++)
			{
				if (tabControl1.TabPages[i].Text==tab)
    			{
    				RichTextBox rtb = (RichTextBox)tabControl1.TabPages[i].Controls["rtb"];
    				path=tabControl1.TabPages[i].Name.ToString();
        			tabControl1.TabPages.RemoveAt(i);
        			texto=rtb.Rtf;
        			System.IO.File.WriteAllText(@path,texto);
        			break;
    			}
			}
			}
			else
				richTextBox1.Text="No hay archivos abiertos";
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			string patharch=tabControl1.SelectedTab.Name;
			StreamReader archivo=new StreamReader(patharch);
			Scanner sc=new Scanner(archivo);
			parser parse = new parser(sc);
			parse.parse();
			archivo.Close();
			MessageBox.Show("Proceso de Compilación Finalizado.");
			richTextBox1.Text=parse.errores;
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			
		}
	}
}
