using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace C_Menu_Test
{
    public partial class Registration : Form
    {
        private Panel targetPanel;
        private Form1 parentForm; // Ссылка на родительский Form1

        public Registration(Panel target, Form1 parent)
        {
            targetPanel = target;
            parentForm = parent;
            InitializeComponent();
            BD_Clietn.Open_Base("User");

            // Дождь на панели Form1
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void animatedButton2_Click(object sender, EventArgs e)
        {
            BD_Clietn.Close_BD();
            targetPanel.Controls.Clear();

            // Создаем Registration на той же панели
            Login regForm = new Login(targetPanel, parentForm); // Передаём parentForm
            regForm.TopLevel = false;
            regForm.FormBorderStyle = FormBorderStyle.None;
            regForm.Dock = DockStyle.Fill;
            targetPanel.Controls.Add(regForm);
            regForm.BringToFront();
            regForm.Show();
        }

        private void animatedButton1_Click(object sender, EventArgs e)
        {
            string userName = textBox2.Text;
            string password = textBox3.Text;
            string email = textBox1.Text;

            // Теперь можешь использовать эти данные
            var users = BD_Clietn.GetUsers();

            uint result = BD_Clietn.Add_User(users, userName, password, email);

            if (result == 1)
                MessageBox.Show($"Такое имя уже существует! {result}");
            else if (result == 2)
                MessageBox.Show($"Такая почта уже используется! {result}");
            else
            {
                Save_Config_User config = File_User.Open_File_To_Read();
                config.name = userName;
                config.password = password;
                config.email = email;

                BD_Clietn.Close_BD();
                targetPanel.Controls.Clear();
                Prased regForm = new Prased(targetPanel, parentForm); // Передаём parentForm
                regForm.TopLevel = false;
                regForm.FormBorderStyle = FormBorderStyle.None;
                regForm.Dock = DockStyle.Fill;
                targetPanel.Controls.Add(regForm);
                regForm.BringToFront();
                regForm.Show();

                
            }
            // Примечание: если Prased должна возвращаться к Form1, добавьте Form1 в её конструктор
        }

        
    }
}