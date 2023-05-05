using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Recomendations
{
    public partial class Form3 : Form
    {
        static private string Login { get; set; }
        public int User_id { get; set; }

        public List<Product> productList = new List<Product>();


        public Form3()
        {
            InitializeComponent();
            CenterToScreen();
            LoadProducts();
        }

        public Form3(string login, int user_id)
        {
            InitializeComponent();
            CenterToScreen();
            Login = login;
            User_id = user_id;
            LoadProducts();
        }

        public static int count = 0;

        private bool isPictureFindClicked = false;

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (textFind.Text == "бургеры" && isPictureFindClicked)
            {
                buttonNext_Click1(sender, e);
            }
            else if (textFind.Text == "курица" && isPictureFindClicked)
            {
                buttonNext_Click2(sender, e);
            }
            else if (textFind.Text == "коктейли" && isPictureFindClicked)
            {
                buttonNext_Click3(sender, e);
            }
            else if (textFind.Text == "кофе" && isPictureFindClicked)
            {
                buttonNext_Click4(sender, e);
            }
            else
            {
                buttonNext_Click4(sender, e);
            }
        }

        private void LoadProducts()
        {
            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM products";

            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
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
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { connection.Close(); }
        }

        private void buttonNext_Click1(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM products";

            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
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
                count++;
                if (count == 3)
                {
                    buttonNext.Enabled = false;
                    buttonPrev.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[count].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[count].Name;
                labelRating.Text = productList[count].Rating.ToString();
                labelOtz.Text = productList[count].Otz.ToString();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (NoNullAllowedException ex)
            {
                MessageBox.Show(ex.Message);
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

            command.CommandText = "SELECT * FROM products";

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
                count++;
                if (count == 7)
                {
                    buttonNext.Enabled = false;
                    buttonPrev.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[count].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[count].Name;
                labelRating.Text = productList[count].Rating.ToString();
                labelOtz.Text = productList[count].Otz.ToString();
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

            command.CommandText = "SELECT * FROM products";

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
                count++;
                if (count == 10)
                {
                    buttonNext.Enabled = false;
                    buttonPrev.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[count].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[count].Name;
                labelRating.Text = productList[count].Rating.ToString();
                labelOtz.Text = productList[count].Otz.ToString();
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

            command.CommandText = "SELECT * FROM products";

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
                count++;
                if (count == 14)
                {
                    buttonNext.Enabled = false;
                    buttonPrev.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[count].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[count].Name;
                labelRating.Text = productList[count].Rating.ToString();
                labelOtz.Text = productList[count].Otz.ToString();
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
            if (textFind.Text == "бургеры" && isPictureFindClicked)
            {
                buttonPrev_Click1(sender, e);
            }
            else if (textFind.Text == "курица" && isPictureFindClicked)
            {
                buttonPrev_Click2(sender, e);
            }
            else if (textFind.Text == "коктейли" && isPictureFindClicked)
            {
                buttonPrev_Click3(sender, e);
            }
            else if (textFind.Text == "кофе" && isPictureFindClicked)
            {
                buttonPrev_Click4(sender, e);
            }
            else
            {
                buttonPrev_Click1(sender, e);
            }
        }

        private void buttonPrev_Click1(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM products";

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
                count--;
                if (count == 0)
                {
                    buttonPrev.Enabled = false;
                    buttonNext.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[count].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[count].Name;
                labelRating.Text = productList[count].Rating.ToString();
                labelOtz.Text = productList[count].Otz.ToString();
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

            command.CommandText = "SELECT * FROM products";

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
                count--;
                if (count == 4)
                {
                    buttonPrev.Enabled = false;
                    buttonNext.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[count].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[count].Name;
                labelRating.Text = productList[count].Rating.ToString();
                labelOtz.Text = productList[count].Otz.ToString();
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

            command.CommandText = "SELECT * FROM products";

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
                count--;
                if (count == 8)
                {
                    buttonPrev.Enabled = false;
                    buttonNext.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[count].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[count].Name;
                labelRating.Text = productList[count].Rating.ToString();
                labelOtz.Text = productList[count].Otz.ToString();
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

            command.CommandText = "SELECT * FROM products";

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
                count--;
                if (count == 11)
                {
                    buttonPrev.Enabled = false;
                    buttonNext.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = true;
                    buttonPrev.Enabled = true;
                }
                string imageUrl = productList[count].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProduct.Image = image;
                }
                labelTitle.Text = productList[count].Name;
                labelRating.Text = productList[count].Rating.ToString();
                labelOtz.Text = productList[count].Otz.ToString();
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
            if (textFind.Text == "бургеры" && isPictureFindClicked)
            {
                NpgsqlConnection connection = DB.GetConnection();
                NpgsqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM products where id_ = 1";

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
                    string imageUrl = productList[count].Ssilka;
                    WebClient client = new WebClient();
                    client.Headers.Add("User-Agent: Other");
                    byte[] imageBytes = client.DownloadData(imageUrl);
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        var image = Image.FromStream(ms);
                        pictureProduct.Image = image;
                    }
                    labelTitle.Text = productList[count].Name;
                    labelRating.Text = productList[count].Rating.ToString();
                    labelOtz.Text = productList[count].Otz.ToString();
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
            else if (textFind.Text == "курица" && isPictureFindClicked)
            {
                NpgsqlConnection connection = DB.GetConnection();
                NpgsqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM products where id_ = 6";

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
                    string imageUrl = productList[count].Ssilka;
                    WebClient client = new WebClient();
                    client.Headers.Add("User-Agent: Other");
                    byte[] imageBytes = client.DownloadData(imageUrl);
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        var image = Image.FromStream(ms);
                        pictureProduct.Image = image;
                    }
                    labelTitle.Text = productList[count].Name;
                    labelRating.Text = productList[count].Rating.ToString();
                    labelOtz.Text = productList[count].Otz.ToString();
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
            else if (textFind.Text == "коктейли" && isPictureFindClicked)
            {
                NpgsqlConnection connection = DB.GetConnection();
                NpgsqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM products where id_ = 10";

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
                    string imageUrl = productList[count].Ssilka;
                    WebClient client = new WebClient();
                    client.Headers.Add("User-Agent: Other");
                    byte[] imageBytes = client.DownloadData(imageUrl);
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        var image = Image.FromStream(ms);
                        pictureProduct.Image = image;
                    }
                    labelTitle.Text = productList[count].Name;
                    labelRating.Text = productList[count].Rating.ToString();
                    labelOtz.Text = productList[count].Otz.ToString();
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
            else if (textFind.Text == "кофе" && isPictureFindClicked)
            {
                NpgsqlConnection connection = DB.GetConnection();
                NpgsqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM products where id_ = 13";

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
                    string imageUrl = productList[count].Ssilka;
                    WebClient client = new WebClient();
                    client.Headers.Add("User-Agent: Other");
                    byte[] imageBytes = client.DownloadData(imageUrl);
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        var image = Image.FromStream(ms);
                        pictureProduct.Image = image;
                    }
                    labelTitle.Text = productList[count].Name;
                    labelRating.Text = productList[count].Rating.ToString();
                    labelOtz.Text = productList[count].Otz.ToString();
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
            else
            {
                NpgsqlConnection connection = DB.GetConnection();
                NpgsqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM products where id_ = 1";

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
                    string imageUrl = productList[count].Ssilka;
                    WebClient client = new WebClient();
                    client.Headers.Add("User-Agent: Other");
                    byte[] imageBytes = client.DownloadData(imageUrl);
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        var image = Image.FromStream(ms);
                        pictureProduct.Image = image;
                    }
                    labelTitle.Text = productList[count].Name;
                    labelRating.Text = productList[count].Rating.ToString();
                    labelOtz.Text = productList[count].Otz.ToString();
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
            isPictureFindClicked = true;
        }

        private void buttonIzbr_Click(object sender, EventArgs e)
        {
            Hide();

            int user_id = -1;
            
            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();
            NpgsqlDataReader reader;

            command.CommandText = $"SELECT user_id FROM userr WHERE login = '{Login}'";

            try
            {
                connection.Open();

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user_id = reader.GetInt32(0);
                }

            } catch (Exception ex)
            {

            }
            finally { connection.Close(); }

            Form6 form6 = new Form6(user_id);
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
            Form4 form4 = new Form4(User_id);
            form4.Show();
        }

        private void buttonAddToIzbr_Click(object sender, EventArgs e)
        {


            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();
            NpgsqlDataReader reader;

            try
            {
                Product product = new Product();
                foreach (var prdct in productList)
                {
                    if (prdct.Name == labelTitle.Text)
                    {
                        product.Name = labelTitle.Text;
                        product.Id = prdct.Id;
                        connection.Open();
                        command.CommandText = $"INSERT INTO izbr(user_id, product_id) values({User_id}, {prdct.Id})";
                        command.ExecuteNonQuery();
                        MessageBox.Show("Продукт добавлен в избранное!");
                    }
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

        private void Form3_Leave(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
