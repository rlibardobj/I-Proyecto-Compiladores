/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 20/09/2012
 * Time: 08:06 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Active
{
	partial class AutUsuario
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(104, 98);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(163, 20);
			this.textBox2.TabIndex = 8;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(104, 59);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(163, 20);
			this.textBox1.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(18, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 19);
			this.label3.TabIndex = 6;
			this.label3.Text = "Contraseña:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(18, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 19);
			this.label2.TabIndex = 5;
			this.label2.Text = "Nombre:";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(55, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(198, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "Autenticar Usuario";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(83, 141);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(118, 25);
			this.button1.TabIndex = 10;
			this.button1.Text = "Autenticar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// AutUsuario
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 186);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Name = "AutUsuario";
			this.Text = "AutUsuario";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
	}
}
