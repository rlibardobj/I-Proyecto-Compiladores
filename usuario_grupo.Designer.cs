﻿/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 21/09/2012
 * Time: 01:18 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Active
{
	partial class usuario_grupo
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
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(300, 94);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(187, 20);
			this.textBox2.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(182, 97);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 21);
			this.label3.TabIndex = 10;
			this.label3.Text = "Nombre del Usuario:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(12, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(150, 272);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Búsqueda";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(38, 232);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(73, 30);
			this.button2.TabIndex = 5;
			this.button2.Text = "BUSCAR";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(17, 206);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(123, 20);
			this.textBox3.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(17, 160);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(113, 46);
			this.label4.TabIndex = 3;
			this.label4.Text = "¿Cuál es el nombre del Grupo?";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(38, 119);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(73, 30);
			this.button1.TabIndex = 2;
			this.button1.Text = "BUSCAR";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(17, 93);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(123, 20);
			this.textBox1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(17, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 46);
			this.label2.TabIndex = 0;
			this.label2.Text = "¿Cuál es el nombre del usuario que desea agregar o eliminar?";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(62, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(441, 35);
			this.label1.TabIndex = 8;
			this.label1.Text = "Agregar o Eliminar Usuario de un Grupo";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(300, 120);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(187, 20);
			this.textBox4.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(182, 123);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 21);
			this.label5.TabIndex = 12;
			this.label5.Text = "Nombre del Grupo:";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(274, 193);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(169, 48);
			this.button3.TabIndex = 14;
			this.button3.Text = "Agregar el Usuario al Grupo";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(274, 247);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(169, 49);
			this.button4.TabIndex = 15;
			this.button4.Text = "Eliminar el Usuario del Grupo";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// usuario_grupo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(527, 339);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Name = "usuario_grupo";
			this.Text = "usuario_grupo";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
	}
}
