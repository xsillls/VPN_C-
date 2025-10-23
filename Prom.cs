using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Menu_Test
{
    public partial class Prom : Form
    {
        private Panel targetPanel;
        private Form1 parentForm; // Ссылка на родительский Form1

        public Prom(Panel target, Form1 parent)
        {
            targetPanel = target;
            parentForm = parent;
            InitializeComponent();
            Color myColorWithAlpha = Color.FromArgb(24, 29, 43, 255);
            FullRain rain = new FullRain(panel1,
                                         dropCount: 100,
                                         dropColor: myColorWithAlpha,
                                         minSpeed: 150f,
                                         maxSpeed: 200f,
                                         minLength: 2f,
                                         maxLength: 10f,
                                         lineWidth: 2f);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void animatedButton2_Click(object sender, EventArgs e)
        {
            // Очищаем панель Form1, на которой отображена Prom
            targetPanel.Controls.Clear();
            // Создаем Prased на той же панели
            Prased regForm = new Prased(targetPanel, parentForm);
            regForm.TopLevel = false;
            regForm.FormBorderStyle = FormBorderStyle.None;
            regForm.Dock = DockStyle.Fill;
            targetPanel.Controls.Add(regForm);
            regForm.BringToFront();
            regForm.Show();
        }
    }
}