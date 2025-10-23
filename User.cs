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
    public partial class User : Form
    {
        private Panel targetPanel;
        private Form1 parentForm; // Ссылка на родительский Form1

        private void UpdateUI()
        {
            int lang = File_User.Get_language();

            if (lang == 0)
            {
                label1.Text = "USER";
                label7.Text = "language";
                label3.Text = "Email";
                label4.Text = "Rate";
                label8.Text = "Remaining";
            }

            else if (lang == 1)
            {
                label1.Text = "ПОЛЬЗОВАТЕЛЬ";
                label7.Text = "Язык";
                label3.Text = "Почта";
                label4.Text = "Тариф";
                label8.Text = "Осталось";
            }

            else if (lang == 2)
            {
                label1.Text = "КОРИСТУВАЧ";
                label7.Text = "Мова";
                label3.Text = "Тариф";
                label8.Text = "Залишилось";
            }
        }

        public User(Panel target, Form1 parent)
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

            UpdateUI();

        }

        




        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void animatedButton2_Click(object sender, EventArgs e)
        {
            // Восстанавливаем содержимое panel2 в Form1
            parentForm.RestorePanel2Content();
            // Закрываем форму User
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void animatedButton1_Click(object sender, EventArgs e)
        {
            File_User.Set_language(2);
            UpdateUI();
        }

        private void animatedButton3_Click(object sender, EventArgs e)
        {
            File_User.Set_language(1);
            UpdateUI();
        }

        private void animatedButton4_Click(object sender, EventArgs e)
        {
            File_User.Set_language(0);
            UpdateUI();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}