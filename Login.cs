using System;
using System.Collections;
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
    public partial class Login : Form
    {
        private Panel targetPanel;
        private Form1 parentForm; // Ссылка на родительский Form1

        private void UpdateUI()
        {
            int lang = File_User.Get_language();

            Dictionary<int, Dictionary<string, string>> Word_TEXT = new Dictionary<int, Dictionary<string, string>>();
            Word_TEXT[0] = new Dictionary<string, string>();
            Word_TEXT[0]["label1"] = "LOGIN";
            Word_TEXT[0]["animatedButton1"] = "Login";
            Word_TEXT[0]["animatedButton2"] = "Registration";

            Word_TEXT[1] = new Dictionary<string, string>();
            Word_TEXT[1]["label1"] = "ВХОД";
            Word_TEXT[1]["animatedButton1"] = "Вход";
            Word_TEXT[1]["animatedButton2"] = "Регистрация";

            Word_TEXT[2] = new Dictionary<string, string>();
            Word_TEXT[2]["label1"] = "ВХІД";
            Word_TEXT[2]["animatedButton1"] = "Вхід";
            Word_TEXT[2]["animatedButton2"] = "Реєстрація";


           
            label1.Text = Word_TEXT[lang]["label1"];
            animatedButton1.Text = Word_TEXT[lang]["animatedButton1"];
            animatedButton2.Text = Word_TEXT[lang]["animatedButton2"];
            
            
        }
        public Login(Panel target, Form1 parent)
        {
            targetPanel = target;
            parentForm = parent;
            InitializeComponent();

            BD_Clietn.Open_Base("User");

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void animatedButton2_Click(object sender, EventArgs e)
        {
            BD_Clietn.Close_BD();
            targetPanel.Controls.Clear();

            // Создаем Registration на той же панели
            Registration regForm = new Registration(targetPanel, parentForm); // Передаём parentForm
            regForm.TopLevel = false;
            regForm.FormBorderStyle = FormBorderStyle.None;
            regForm.Dock = DockStyle.Fill;
            targetPanel.Controls.Add(regForm);
            regForm.BringToFront();
            regForm.Show();
            
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void animatedButton1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;  // Имя пользователя
            string password = textBox2.Text;  // Пароль

            var users = BD_Clietn.GetUsers(); // Получаем коллекцию пользователей

            if (BD_Clietn.CheckLogin(users, username, password))
            {
                Save_Config_User config = File_User.Open_File_To_Read();
                config.name = username;
                config.password = password;
                File_User.Save_File(config);
                targetPanel.Controls.Clear();
                parentForm.RestorePanel2Content();
                // Закрываем форму Login
                this.Close();
                BD_Clietn.Close_BD();

            }
            
        }
    }
}