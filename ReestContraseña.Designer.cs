﻿/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 20/09/2012
 * Time: 08:07 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Active
{
	partial class ReestContraseña
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(12, 80);
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
			this.label2.Location = new System.Drawing.Point(17, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 46);
			this.label2.TabIndex = 0;
			this.label2.Text = "¿Cuál es el nombre del usuario que desea modificar?";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label2.Click += new System.EventHandler(this.Label2Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(100, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(250, 23);
			this.label1.TabIndex = 10;
			this.label1.Text = "Reestablecer Contraseña";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(245, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(105, 24);
			this.label3.TabIndex = 11;
			this.label3.Text = "Nueva Contraseña.";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(205, 143);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(187, 20);
			this.textBox2.TabIndex = 12;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(218, 218);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(159, 33);
			this.button2.TabIndex = 13;
			this.button2.Text = "Reestablecer";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// ReestContraseña
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(442, 311);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Name = "ReestContraseña";
			this.Text = "ReestContraseña";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
