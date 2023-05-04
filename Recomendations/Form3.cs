using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recomendations
{
    public partial class Form3 : Form
    {
        static public string Login { get; set; }
        public Form3()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public Form3(string login)
        {
            InitializeComponent();
            CenterToScreen();
            Login = login;
        }

        public static int сount = 0;

        private bool isButtonNextClicked = false;

        private bool isButtonPrevClicked = false;

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (textFind.Text == "")
            {
                buttonNext.Click += new EventHandler(buttonNext_Click4);
            }
            else if (textFind.Text == "бургеры" && isButtonNextClicked)
            {
                buttonNext.Click += new EventHandler(buttonNext_Click1);
            }
            else if (textFind.Text == "курица" && isButtonNextClicked)
            {
                buttonNext.Click += new EventHandler(buttonNext_Click2);
            }
            else if (textFind.Text == "коктейли" && isButtonNextClicked)
            {
                buttonNext.Click += new EventHandler(buttonNext_Click3);
            }
            else if (textFind.Text == "кофе" && isButtonNextClicked)
            {
                buttonNext.Click += new EventHandler(buttonNext_Click4);
            }
        }

        private void buttonNext_Click1(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Products";

            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                List<Product> productList = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = (int)reader["id_"];
                    product.Name = (string)reader["name_"];
                    product.Sostav = (string)reader["sostav_"];
                    product.Ostr = (string)reader["ostr_"];
                    product.Ssilka = (string)reader["ssilka_"];
                    product.Otz = (int)reader["otz_"];
                    product.Rating = (double)reader["rating_"];
                    productList.Add(product);
                }
                сount++;
                if (сount == 3)
                {
                    buttonNext.Enabled = false;
                    buttonPrev.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[сount].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[сount].Name;
                labelRating.Text = productList[сount].Rating.ToString();
                labelOtz.Text = productList[сount].Otz.ToString();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (NoNullAllowedException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonNext_Click2(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Products";

            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                List<Product> productList = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = (int)reader["id_"];
                    product.Name = (string)reader["name_"];
                    product.Sostav = (string)reader["sostav_"];
                    product.Ostr = (string)reader["ostr_"];
                    product.Ssilka = (string)reader["ssilka_"];
                    product.Otz = (int)reader["otz_"];
                    product.Rating = (double)reader["rating_"];
                    productList.Add(product);
                }
                сount++;
                if (сount == 7)
                {
                    buttonNext.Enabled = false;
                    buttonPrev.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[сount].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[сount].Name;
                labelRating.Text = productList[сount].Rating.ToString();
                labelOtz.Text = productList[сount].Otz.ToString();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (NoNullAllowedException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonNext_Click3(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Products";

            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                List<Product> productList = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = (int)reader["id_"];
                    product.Name = (string)reader["name_"];
                    product.Sostav = (string)reader["sostav_"];
                    product.Ostr = (string)reader["ostr_"];
                    product.Ssilka = (string)reader["ssilka_"];
                    product.Otz = (int)reader["otz_"];
                    product.Rating = (double)reader["rating_"];
                    productList.Add(product);
                }
                сount++;
                if (сount == 10)
                {
                    buttonNext.Enabled = false;
                    buttonPrev.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[сount].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[сount].Name;
                labelRating.Text = productList[сount].Rating.ToString();
                labelOtz.Text = productList[сount].Otz.ToString();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (NoNullAllowedException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonNext_Click4(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Products";

            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                List<Product> productList = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = (int)reader["id_"];
                    product.Name = (string)reader["name_"];
                    product.Sostav = (string)reader["sostav_"];
                    product.Ostr = (string)reader["ostr_"];
                    product.Ssilka = (string)reader["ssilka_"];
                    product.Otz = (int)reader["otz_"];
                    product.Rating = (double)reader["rating_"];
                    productList.Add(product);
                }
                сount++;
                if (сount == 14)
                {
                    buttonNext.Enabled = false;
                    buttonPrev.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[сount].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[сount].Name;
                labelRating.Text = productList[сount].Rating.ToString();
                labelOtz.Text = productList[сount].Otz.ToString();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (NoNullAllowedException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (textFind.Text == "")
            {
                buttonPrev.Click += new EventHandler(buttonPrev_Click1);
            }
            else if (textFind.Text == "бургеры" && isButtonPrevClicked)
            {
                buttonPrev.Click += new EventHandler(buttonPrev_Click1);
            }
            else if (textFind.Text == "курица" && isButtonPrevClicked)
            {
                buttonPrev.Click += new EventHandler(buttonPrev_Click2);
            }
            else if (textFind.Text == "коктейли" && isButtonPrevClicked)
            {
                buttonPrev.Click += new EventHandler(buttonPrev_Click3);
            }
            else if (textFind.Text == "кофе" && isButtonPrevClicked)
            {
                buttonPrev.Click += new EventHandler(buttonPrev_Click4);
            }
        }

        private void buttonPrev_Click1(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Products";

            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                List<Product> productList = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = (int)reader["id_"];
                    product.Name = (string)reader["name_"];
                    product.Sostav = (string)reader["sostav_"];
                    product.Ostr = (string)reader["ostr_"];
                    product.Ssilka = (string)reader["ssilka_"];
                    product.Otz = (int)reader["otz_"];
                    product.Rating = (double)reader["rating_"];
                    productList.Add(product);
                }
                сount--;
                if (сount == 0)
                {
                    buttonPrev.Enabled = false;
                    buttonNext.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[сount].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[сount].Name;
                labelRating.Text = productList[сount].Rating.ToString();
                labelOtz.Text = productList[сount].Otz.ToString();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (NoNullAllowedException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonPrev_Click2(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Products";

            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                List<Product> productList = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = (int)reader["id_"];
                    product.Name = (string)reader["name_"];
                    product.Sostav = (string)reader["sostav_"];
                    product.Ostr = (string)reader["ostr_"];
                    product.Ssilka = (string)reader["ssilka_"];
                    product.Otz = (int)reader["otz_"];
                    product.Rating = (double)reader["rating_"];
                    productList.Add(product);
                }
                сount--;
                if (сount == 4)
                {
                    buttonPrev.Enabled = false;
                    buttonNext.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[сount].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[сount].Name;
                labelRating.Text = productList[сount].Rating.ToString();
                labelOtz.Text = productList[сount].Otz.ToString();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (NoNullAllowedException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonPrev_Click3(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Products";

            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                List<Product> productList = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = (int)reader["id_"];
                    product.Name = (string)reader["name_"];
                    product.Sostav = (string)reader["sostav_"];
                    product.Ostr = (string)reader["ostr_"];
                    product.Ssilka = (string)reader["ssilka_"];
                    product.Otz = (int)reader["otz_"];
                    product.Rating = (double)reader["rating_"];
                    productList.Add(product);
                }
                сount--;
                if (сount == 8)
                {
                    buttonPrev.Enabled = false;
                    buttonNext.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[сount].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[сount].Name;
                labelRating.Text = productList[сount].Rating.ToString();
                labelOtz.Text = productList[сount].Otz.ToString();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (NoNullAllowedException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonPrev_Click4(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Products";

            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                List<Product> productList = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = (int)reader["id_"];
                    product.Name = (string)reader["name_"];
                    product.Sostav = (string)reader["sostav_"];
                    product.Ostr = (string)reader["ostr_"];
                    product.Ssilka = (string)reader["ssilka_"];
                    product.Otz = (int)reader["otz_"];
                    product.Rating = (double)reader["rating_"];
                    productList.Add(product);
                }
                сount--;
                if (сount == 11)
                {
                    buttonPrev.Enabled = false;
                    buttonNext.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[сount].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[сount].Name;
                labelRating.Text = productList[сount].Rating.ToString();
                labelOtz.Text = productList[сount].Otz.ToString();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (NoNullAllowedException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (textFind.Text == "")
            {
                NpgsqlConnection connection = DB.GetConnection();
                NpgsqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM Products where id_ = 1";

                try
                {
                    connection.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();
                    List<Product> productList = new List<Product>();
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Id = (int)reader["id_"];
                        product.Name = (string)reader["name_"];
                        product.Sostav = (string)reader["sostav_"];
                        product.Ostr = (string)reader["ostr_"];
                        product.Ssilka = (string)reader["ssilka_"];
                        product.Otz = (int)reader["otz_"];
                        product.Rating = (double)reader["rating_"];
                        productList.Add(product);
                    }
                    buttonPrev.Enabled = false;
                    buttonNext.Enabled = true;
                    string imageUrl = productList[сount].Ssilka;
                    WebClient client = new WebClient();
                    client.Headers.Add("User-Agent: Other");
                    byte[] imageBytes = client.DownloadData(imageUrl);
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        var image = Image.FromStream(ms);
                        pictureProduct.Image = image;
                    }
                    labelTitle.Text = productList[сount].Name;
                    labelRating.Text = productList[сount].Rating.ToString();
                    labelOtz.Text = productList[сount].Otz.ToString();
                    reader.Close();
                    command.Dispose();
                    connection.Close();
                }
                catch (NoNullAllowedException ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else if (textFind.Text == "бургеры" && isButtonPrevClicked)
            {
                NpgsqlConnection connection = DB.GetConnection();
                NpgsqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM Products where id_ = 1";

                try
                {
                    connection.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();
                    List<Product> productList = new List<Product>();
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Id = (int)reader["id_"];
                        product.Name = (string)reader["name_"];
                        product.Sostav = (string)reader["sostav_"];
                        product.Ostr = (string)reader["ostr_"];
                        product.Ssilka = (string)reader["ssilka_"];
                        product.Otz = (int)reader["otz_"];
                        product.Rating = (double)reader["rating_"];
                        productList.Add(product);
                    }
                    buttonPrev.Enabled = false;
                    buttonNext.Enabled = true;
                    string imageUrl = productList[сount].Ssilka;
                    WebClient client = new WebClient();
                    client.Headers.Add("User-Agent: Other");
                    byte[] imageBytes = client.DownloadData(imageUrl);
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        var image = Image.FromStream(ms);
                        pictureProduct.Image = image;
                    }
                    labelTitle.Text = productList[сount].Name;
                    labelRating.Text = productList[сount].Rating.ToString();
                    labelOtz.Text = productList[сount].Otz.ToString();
                    reader.Close();
                    command.Dispose();
                    connection.Close();
                }
                catch (NoNullAllowedException ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else if (textFind.Text == "курица" && isButtonPrevClicked)
            {
                NpgsqlConnection connection = DB.GetConnection();
                NpgsqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM Products where id_ = 6";

                try
                {
                    connection.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();
                    List<Product> productList = new List<Product>();
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Id = (int)reader["id_"];
                        product.Name = (string)reader["name_"];
                        product.Sostav = (string)reader["sostav_"];
                        product.Ostr = (string)reader["ostr_"];
                        product.Ssilka = (string)reader["ssilka_"];
                        product.Otz = (int)reader["otz_"];
                        product.Rating = (double)reader["rating_"];
                        productList.Add(product);
                    }
                    buttonPrev.Enabled = false;
                    buttonNext.Enabled = true;
                    string imageUrl = productList[сount].Ssilka;
                    WebClient client = new WebClient();
                    client.Headers.Add("User-Agent: Other");
                    byte[] imageBytes = client.DownloadData(imageUrl);
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        var image = Image.FromStream(ms);
                        pictureProduct.Image = image;
                    }
                    labelTitle.Text = productList[сount].Name;
                    labelRating.Text = productList[сount].Rating.ToString();
                    labelOtz.Text = productList[сount].Otz.ToString();
                    reader.Close();
                    command.Dispose();
                    connection.Close();
                }
                catch (NoNullAllowedException ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else if (textFind.Text == "коктейли" && isButtonPrevClicked)
            {
                NpgsqlConnection connection = DB.GetConnection();
                NpgsqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM Products where id_ = 10";

                try
                {
                    connection.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();
                    List<Product> productList = new List<Product>();
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Id = (int)reader["id_"];
                        product.Name = (string)reader["name_"];
                        product.Sostav = (string)reader["sostav_"];
                        product.Ostr = (string)reader["ostr_"];
                        product.Ssilka = (string)reader["ssilka_"];
                        product.Otz = (int)reader["otz_"];
                        product.Rating = (double)reader["rating_"];
                        productList.Add(product);
                    }
                    buttonPrev.Enabled = false;
                    buttonNext.Enabled = true;
                    string imageUrl = productList[сount].Ssilka;
                    WebClient client = new WebClient();
                    client.Headers.Add("User-Agent: Other");
                    byte[] imageBytes = client.DownloadData(imageUrl);
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        var image = Image.FromStream(ms);
                        pictureProduct.Image = image;
                    }
                    labelTitle.Text = productList[сount].Name;
                    labelRating.Text = productList[сount].Rating.ToString();
                    labelOtz.Text = productList[сount].Otz.ToString();
                    reader.Close();
                    command.Dispose();
                    connection.Close();
                }
                catch (NoNullAllowedException ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else if (textFind.Text == "кофе" && isButtonPrevClicked)
            {
                NpgsqlConnection connection = DB.GetConnection();
                NpgsqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM Products where id_ = 13";

                try
                {
                    connection.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();
                    List<Product> productList = new List<Product>();
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Id = (int)reader["id_"];
                        product.Name = (string)reader["name_"];
                        product.Sostav = (string)reader["sostav_"];
                        product.Ostr = (string)reader["ostr_"];
                        product.Ssilka = (string)reader["ssilka_"];
                        product.Otz = (int)reader["otz_"];
                        product.Rating = (double)reader["rating_"];
                        productList.Add(product);
                    }
                    buttonPrev.Enabled = false;
                    buttonNext.Enabled = true;
                    string imageUrl = productList[сount].Ssilka;
                    WebClient client = new WebClient();
                    client.Headers.Add("User-Agent: Other");
                    byte[] imageBytes = client.DownloadData(imageUrl);
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        var image = Image.FromStream(ms);
                        pictureProduct.Image = image;
                    }
                    labelTitle.Text = productList[сount].Name;
                    labelRating.Text = productList[сount].Rating.ToString();
                    labelOtz.Text = productList[сount].Otz.ToString();
                    reader.Close();
                    command.Dispose();
                    connection.Close();
                }
                catch (NoNullAllowedException ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void pictureFind_Click(object sender, EventArgs e)
        {
            isButtonNextClicked = true;
            isButtonPrevClicked = true;
        }

        private void buttonIzbr_Click(object sender, EventArgs e)
        {
            Hide();
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void buttonPodbor_Click(object sender, EventArgs e)
        {
            Hide();
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void buttonOtz_Click(object sender, EventArgs e)
        {
            Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
