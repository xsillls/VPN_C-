namespace C_Menu_Test
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.animatedButton3 = new AnimatedButton();
            this.animatedButton2 = new AnimatedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.animatedButton4 = new AnimatedButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.animatedButton3);
            this.panel1.Controls.Add(this.animatedButton2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 28);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // animatedButton3
            // 
            this.animatedButton3.ClickColor = System.Drawing.Color.DodgerBlue;
            this.animatedButton3.HoverColor = System.Drawing.Color.LightSkyBlue;
            this.animatedButton3.Location = new System.Drawing.Point(108, 3);
            this.animatedButton3.Name = "animatedButton3";
            this.animatedButton3.Size = new System.Drawing.Size(21, 21);
            this.animatedButton3.TabIndex = 2;
            this.animatedButton3.Text = "-";
            this.animatedButton3.UseVisualStyleBackColor = true;
            this.animatedButton3.Click += new System.EventHandler(this.animatedButton3_Click);
            // 
            // animatedButton2
            // 
            this.animatedButton2.ClickColor = System.Drawing.Color.DodgerBlue;
            this.animatedButton2.HoverColor = System.Drawing.Color.LightSkyBlue;
            this.animatedButton2.Location = new System.Drawing.Point(133, 3);
            this.animatedButton2.Name = "animatedButton2";
            this.animatedButton2.Size = new System.Drawing.Size(21, 21);
            this.animatedButton2.TabIndex = 1;
            this.animatedButton2.Text = "+";
            this.animatedButton2.UseVisualStyleBackColor = true;
            this.animatedButton2.Click += new System.EventHandler(this.animatedButton2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "XSILLL_VPN";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.animatedButton4);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 226);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::C_Menu_Test.Properties.Resources.Logo_1_32;
            this.pictureBox1.Location = new System.Drawing.Point(1, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // animatedButton4
            // 
            this.animatedButton4.ClickColor = System.Drawing.Color.DodgerBlue;
            this.animatedButton4.HoverColor = System.Drawing.Color.LightSkyBlue;
            this.animatedButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.animatedButton4.Location = new System.Drawing.Point(146, 11);
            this.animatedButton4.Name = "animatedButton4";
            this.animatedButton4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.animatedButton4.Size = new System.Drawing.Size(14, 23);
            this.animatedButton4.TabIndex = 1;
            this.animatedButton4.Text = ">";
            this.animatedButton4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.animatedButton4.UseVisualStyleBackColor = true;
            this.animatedButton4.Click += new System.EventHandler(this.animatedButton4_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2 - button7
            // 
            this.button2.Location = new System.Drawing.Point(175, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "🇺🇸 United States";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);

            this.button3.Location = new System.Drawing.Point(175, 78);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 28);
            this.button3.TabIndex = 4;
            this.button3.Text = "🇩🇪 Germany";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);

            this.button4.Location = new System.Drawing.Point(175, 112);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 28);
            this.button4.TabIndex = 5;
            this.button4.Text = "🇨🇦 Canada";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);

            this.button5.Location = new System.Drawing.Point(175, 146);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(161, 28);
            this.button5.TabIndex = 6;
            this.button5.Text = "🇯🇵 Japan";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);

            this.button6.Location = new System.Drawing.Point(175, 180);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(161, 28);
            this.button6.TabIndex = 7;
            this.button6.Text = "🇸🇪 Sweden";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);

            this.button7.Location = new System.Drawing.Point(175, 10);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(161, 28);
            this.button7.TabIndex = 8;
            this.button7.Text = "🇸🇬 Singapore";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "None";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(161, 250);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private AnimatedButton animatedButton2;
        private AnimatedButton animatedButton3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private AnimatedButton animatedButton4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label2;
    }
}
