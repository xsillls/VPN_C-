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
    public partial class Prased : Form
    {
        private Panel targetPanel;
        private Form1 parentForm; // Ссылка на родительский Form1

        public Prased(Panel target, Form1 parent)
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

            // В конструкторе или Load формы:
            Color myColor_1 = Color.FromArgb(255, 8, 255, 32);
            Color myColor_2 = Color.FromArgb(255, 7, 112, 6);
            string[] symbols = { "$", "¥", "€" };


            SymbolRain effect = new SymbolRain(panel2, symbols, myColor_1, myColor_2, dropCount: 10,
                                             minSpeed: 0.5f, maxSpeed: 2f,
                                             minAmplitude: 5, maxAmplitude: 25,
                                             minSwingSpeed: 0.02f, maxSwingSpeed: 0.1f,
                                             minFontSize: 12, maxFontSize: 24);

            Color myColor_3 = Color.FromArgb(255, 255, 153, 0);
            Color myColor_4 = Color.FromArgb(255, 143, 112, 0);
            string[] symbols_2 = { "₨", "₦", "₵", "₸" };


            SymbolRain effect_2 = new SymbolRain(panel3, symbols_2, myColor_3, myColor_4, dropCount: 6,
                                             minSpeed: 0.5f, maxSpeed: 2f,
                                             minAmplitude: 5, maxAmplitude: 25,
                                             minSwingSpeed: 0.02f, maxSwingSpeed: 0.1f,
                                             minFontSize: 12, maxFontSize: 24);

            Color myColor_5 = Color.FromArgb(255, 0, 4, 120);
            Color myColor_6 = Color.FromArgb(255, 7, 116, 240);
            string[] symbols_3 = { "Free" };


            SymbolRain effect_3 = new SymbolRain(panel4, symbols_3, myColor_5, myColor_6, dropCount: 2,
                                             minSpeed: 0.5f, maxSpeed: 1f,
                                             minAmplitude: 5, maxAmplitude: 25,
                                             minSwingSpeed: 0.02f, maxSwingSpeed: 0.1f,
                                             minFontSize: 10, maxFontSize: 19);

            panel2.DoubleBuffered(true);


        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void animatedButton1_Click(object sender, EventArgs e)
        {
            targetPanel.Controls.Clear();
            Prom regForm = new Prom(targetPanel, parentForm); // Передаём parentForm
            regForm.TopLevel = false;
            regForm.FormBorderStyle = FormBorderStyle.None;
            regForm.Dock = DockStyle.Fill;
            targetPanel.Controls.Add(regForm);
            regForm.BringToFront();
            regForm.Show();
            // Примечание: Prom теперь возвращается к Form1 через RestorePanel2Content
        }

        private void animatedButton2_Click(object sender, EventArgs e)
        {
            targetPanel.Controls.Clear();
            // Создаем Registration на той же панели
            Registration regForm = new Registration(targetPanel, parentForm);
            regForm.TopLevel = false;
            regForm.FormBorderStyle = FormBorderStyle.None;
            regForm.Dock = DockStyle.Fill;
            targetPanel.Controls.Add(regForm);
            regForm.BringToFront();
            regForm.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}