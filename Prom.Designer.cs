namespace C_Menu_Test
{
    partial class Prom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.animatedButton1 = new AnimatedButton();
            this.animatedButton2 = new AnimatedButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.animatedButton2);
            this.panel1.Controls.Add(this.animatedButton1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 230);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "PROMOTIONAL \r\nCODE";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 124);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "XXX-XXX-XXX-XXX";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // animatedButton1
            // 
            this.animatedButton1.ClickColor = System.Drawing.Color.DodgerBlue;
            this.animatedButton1.HoverColor = System.Drawing.Color.LightSkyBlue;
            this.animatedButton1.Location = new System.Drawing.Point(43, 150);
            this.animatedButton1.Name = "animatedButton1";
            this.animatedButton1.Size = new System.Drawing.Size(75, 23);
            this.animatedButton1.TabIndex = 2;
            this.animatedButton1.Text = "Activate";
            this.animatedButton1.UseVisualStyleBackColor = true;
            // 
            // animatedButton2
            // 
            this.animatedButton2.ClickColor = System.Drawing.Color.DodgerBlue;
            this.animatedButton2.HoverColor = System.Drawing.Color.LightSkyBlue;
            this.animatedButton2.Location = new System.Drawing.Point(135, 6);
            this.animatedButton2.Name = "animatedButton2";
            this.animatedButton2.Size = new System.Drawing.Size(19, 19);
            this.animatedButton2.TabIndex = 3;
            this.animatedButton2.Text = ">";
            this.animatedButton2.UseVisualStyleBackColor = true;
            this.animatedButton2.Click += new System.EventHandler(this.animatedButton2_Click);
            // 
            // Prom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(161, 230);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Prom";
            this.Text = "Prom";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private AnimatedButton animatedButton1;
        private AnimatedButton animatedButton2;
    }
}