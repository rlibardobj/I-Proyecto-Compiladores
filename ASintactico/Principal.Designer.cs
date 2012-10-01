/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 01/10/2012
 * Time: 09:12 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
 using System.Windows.Forms;
 using System;
 using System.IO;
namespace ASintactico
{
	partial class Principal
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(436, 301);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(295, 55);
			this.button1.TabIndex = 1;
			this.button1.Text = "Compilar Archivo Actual";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.richTextBox1);
			this.groupBox1.Location = new System.Drawing.Point(436, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(295, 266);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Errores";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(6, 16);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(283, 244);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(436, 375);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(139, 57);
			this.button2.TabIndex = 3;
			this.button2.Text = "Abrir Nuevo Archivo";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(592, 375);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(139, 57);
			this.button3.TabIndex = 4;
			this.button3.Text = "Cerrar y Guardar Archivo Actual";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.ShowHelp = true;
			this.openFileDialog1.Title = "Abrir Archivo";
			// 
			// tabControl1
			// 
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(418, 420);
			this.tabControl1.TabIndex = 0;
			// 
			// Principal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(743, 444);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tabControl1);
			this.Name = "Principal";
			this.Text = "Principal";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.TabControl tabControl1;
		
		void Button2Click(object sender, System.EventArgs e)
		{
			try{
				DialogResult resultado=openFileDialog1.ShowDialog();
				if(resultado==DialogResult.OK){
					StreamReader archivo=new StreamReader(openFileDialog1.FileName);
					TabPage pagina=new TabPage(openFileDialog1.SafeFileName);
					pagina.Size=new System.Drawing.Size(410, 394);
					pagina.Padding=new System.Windows.Forms.Padding(3);;
					RichTextBox texto=new RichTextBox();
					texto.Size=new System.Drawing.Size(410, 394);
					texto.Name="rtb";
					texto.Text=archivo.ReadToEnd();
					pagina.Controls.Add(texto);
					pagina.Name=(openFileDialog1.FileName);
					tabControl1.Controls.Add(pagina);
					richTextBox1.Text=tabControl1.SelectedTab.Text;
					archivo.Close();
				}
			}
			catch (Exception exc){
				richTextBox1.Text=exc.Message.ToString();
			}
		}
	}
}
