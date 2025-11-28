using LiteDB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace C_Menu_Test
{
    public partial class Form1 : Form
    {
        private bool isExpanded = false;
        private Size originalSize;
        private Timer resizeTimer;
        private int currentStep = 0;
        private int totalSteps = 20;
        private List<Control> panel2Controls;

        public Form1()
        {
            InitializeComponent();

            panel1.DoubleBuffered(true);
            BD_Clietn.Open_Base("User");

            resizeTimer = new Timer();
            resizeTimer.Interval = 10;
            resizeTimer.Tick += ResizeTimer_Tick;

            animatedButton4.Text = ">";

            if (File_User.File_Exists_Seting())
                File_User.Set_language(0);

            Color myColorWithAlpha = Color.FromArgb(24, 29, 43, 255);
            FullRain rain = new FullRain(panel2,
                                     dropCount: 100,
                                     dropColor: myColorWithAlpha,
                                     minSpeed: 150f,
                                     maxSpeed: 200f,
                                     minLength: 2f,
                                     maxLength: 10f,
                                     lineWidth: 2f);

            panel2Controls = new List<Control>();
            foreach (Control control in panel2.Controls)
                panel2Controls.Add(control);

            if (!File_User.File_Exists())
            {
                BD_Clietn.Close_BD();
                panel2.Controls.Clear();
                Login loginForm = new Login(panel2, this);
                loginForm.TopLevel = false;
                loginForm.FormBorderStyle = FormBorderStyle.None;
                loginForm.Dock = DockStyle.Fill;
                panel2.Controls.Add(loginForm);
                loginForm.BringToFront();
                loginForm.Show();
            }
        }

        // --- Перетаскивание формы ---
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        // --- Раскрытие меню ---
        private void animatedButton4_Click_1(object sender, EventArgs e)
        {
            // Читаем конфиг каждый раз при нажатии
            Save_Config_User config = File_User.Open_File_To_Read();
            ApplyVPNLevel(config.rait);

            if (originalSize.IsEmpty)
            {
                originalSize = this.Size;
                animatedButton2.Tag = animatedButton2.Location;
                animatedButton3.Tag = animatedButton3.Location;
                animatedButton4.Tag = animatedButton4.Location;
            }

            currentStep = 0;
            resizeTimer.Start();

            isExpanded = !isExpanded;
        }

        private void ResizeTimer_Tick(object sender, EventArgs e)
        {
            if (currentStep <= totalSteps)
            {
                double progress = (double)currentStep / totalSteps;
                int newWidth = isExpanded
                    ? (int)(originalSize.Width + 200 * progress)
                    : (int)(originalSize.Width + 200 * (1 - progress));

                this.Size = new Size(newWidth, originalSize.Height);
                panel1.Width = newWidth;

                Point originalLocation2 = (Point)animatedButton2.Tag;
                Point originalLocation3 = (Point)animatedButton3.Tag;

                int offset = isExpanded
                    ? (int)(200 * progress)
                    : (int)(200 * (1 - progress));

                animatedButton2.Location = new Point(originalLocation2.X + offset, originalLocation2.Y);
                animatedButton3.Location = new Point(originalLocation3.X + offset, originalLocation3.Y);

                animatedButton4.Location = new Point(panel1.Right - animatedButton4.Width, animatedButton4.Location.Y);

                panel1.Invalidate();
                animatedButton4.Invalidate();

                currentStep++;
            }
            else
            {
                resizeTimer.Stop();
                animatedButton4.Text = isExpanded ? "<" : ">";
                animatedButton4.Invalidate();
            }
        }

        private void animatedButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void animatedButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // пусто
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // пусто
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BD_Clietn.Close_BD();
            panel2.Controls.Clear();
            Login loginForm = new Login(panel2, this);
            loginForm.TopLevel = false;
            loginForm.FormBorderStyle = FormBorderStyle.None;
            loginForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(loginForm);
            loginForm.BringToFront();
            loginForm.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (Pen pen = new Pen(Color.LightGray, 2))
            {
                g.DrawLine(pen, 162, 30, 162, 200);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            User regForm = new User(panel2, this)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(regForm);
            regForm.BringToFront();
            regForm.Show();
        }

        private void SelectVPN(string countryName)
        {
            label2.Text = countryName;
            animatedButton4_Click_1(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Logo_1_32;
            pictureBox1.MouseEnter += (s, ev) => pictureBox1.Image = Properties.Resources.Logo_2_32;
            pictureBox1.MouseLeave += (s, ev) => pictureBox1.Image = Properties.Resources.Logo_1_32;
        }

        // --- Ограничение VPN по уровню ---
        private void ApplyVPNLevel(string rait)
        {
            Button[] vpnButtons =
            {
                button7, button2, button3, button4, button5, button6
            };

            int showCount = 6;
            if (rait == "3") showCount = 2;
            else if (rait == "2") showCount = 4;
            else if (rait == "1") showCount = 6;

            for (int i = 0; i < vpnButtons.Length; i++)
                vpnButtons[i].Visible = i < showCount;
        }

        public void RestorePanel2Content()
        {
            panel2.Controls.Clear();
            foreach (Control control in panel2Controls)
                panel2.Controls.Add(control);

            Color myColorWithAlpha = Color.FromArgb(24, 29, 43, 255);
            FullRain rain = new FullRain(panel2,
                                     dropCount: 100,
                                     dropColor: myColorWithAlpha,
                                     minSpeed: 150f,
                                     maxSpeed: 200f,
                                     minLength: 2f,
                                     maxLength: 10f,
                                     lineWidth: 2f);
        }

        private void button7_Click(object sender, EventArgs e) => SelectVPN("🇸🇬 Singapore");
        private void button2_Click_1(object sender, EventArgs e) => SelectVPN("🇺🇸 United States");
        private void button3_Click(object sender, EventArgs e) => SelectVPN("🇳🇴 Norway");
        private void button4_Click(object sender, EventArgs e) => SelectVPN("🇨🇦 Canada");
        private void button5_Click(object sender, EventArgs e) => SelectVPN("🇯🇵 Japan");
        private void button6_Click(object sender, EventArgs e) => SelectVPN("🇸🇪 Sweden");
    }
}
