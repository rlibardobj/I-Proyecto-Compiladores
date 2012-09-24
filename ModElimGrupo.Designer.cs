/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 21/09/2012
 * Time: 12:20 a.m.
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
	partial class ModElimGrupo
	{
		GroupPrincipal grupo;
		int searchFlag=0;
		Metodos insMetodos=new Metodos();
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(12, 67);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(150, 209);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Búsqueda";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(38, 148);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(73, 30);
			this.button1.TabIndex = 2;
			this.button1.Text = "BUSCAR";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(15, 106);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(123, 20);
			this.textBox1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(15, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 46);
			this.label2.TabIndex = 0;
			this.label2.Text = "¿Cuál es el nombre del grupo que desea modificar o eliminar?";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(544, 193);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(99, 75);
			this.button3.TabIndex = 20;
			this.button3.Text = "Eliminar";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(544, 85);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(99, 75);
			this.button2.TabIndex = 19;
			this.button2.Text = "Modificar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(310, 125);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(188, 151);
			this.textBox3.TabIndex = 18;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(311, 74);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(187, 20);
			this.textBox2.TabIndex = 17;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(238, 128);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(66, 21);
			this.label7.TabIndex = 16;
			this.label7.Text = "Descripción:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(193, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 21);
			this.label3.TabIndex = 15;
			this.label3.Text = "Nombre para Mostrar:";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(178, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(320, 35);
			this.label1.TabIndex = 14;
			this.label1.Text = "Modificar o Eliminar Grupo";
			// 
			// ModElimGrupo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(683, 309);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Name = "ModElimGrupo";
			this.Text = "ModElimGrupo";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		
		void Button1Click(object sender, System.EventArgs e)
		{
			try{
			if (textBox1.Text!=""){
				grupo=insMetodos.EncontrarGrupo(textBox1.Text);
				if (grupo!=null){
				textBox2.Text=grupo.Name;
				textBox3.Text=grupo.Description;
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
		
		void Button3Click(object sender, EventArgs e)
		{
			try{
			if (searchFlag!=0){
				insMetodos.EliminarGrupo(grupo);
				MessageBox.Show("Grupo eliminado con Éxito");
				textBox2.Text="";
				textBox3.Text="";
				searchFlag=0;
			}
			else{
				MessageBox.Show("Debe buscar un grupo primero.");
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
				insMetodos.ModificarGrupo(grupo,textBox2.Text,textBox3.Text);
				MessageBox.Show("Grupo modificado con Éxito");
				textBox2.Text="";
				textBox3.Text="";
				searchFlag=0;
			}
			else{
				MessageBox.Show("Debe buscar un Grupo primero.");
			}
			}
			catch(Exception exc){
				MessageBox.Show(exc.Message.ToString());
			}
		}
	}
}
