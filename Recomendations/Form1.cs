using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recomendations
{
    public partial class Авторизация : Form
    {
        public int User_id { get; set; }

        public Авторизация()
        {
            InitializeComponent();
            CenterToScreen();

            CenterToScreen();

            passField.AutoSize = false;
            passField.Size = new Size(passField.Width, 18);

            loginField.Text = "Введите логин...";
            loginField.ForeColor = Color.Gray;
        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text == "Введите логин...")
            {
                loginField.Text = "";
                loginField.ForeColor = Color.Black;
            }
        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (loginField.Text == "")
            {
                loginField.Text = "Введите логин...";
                loginField.ForeColor = Color.Gray;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string loginUser = loginField.Text;
            string passUser = passField.Text;

            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = ($"SELECT * FROM userr WHERE login = '{loginUser}' AND password = '{passUser}'");

            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read() && reader.HasRows)
                {
                    Hide();
                    User_id = reader.GetInt32(0);
                    Form3 form3 = new Form3(loginUser, User_id);
                    form3.ShowDialog();
                    form3.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        Point lastPoint;

        private void Авторизация_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void Авторизация_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            Hide();
            Регистрация регистрация = new Регистрация();
            регистрация.ShowDialog();
            регистрация.Close();
        }

        private void buttonLogin_Leave(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
