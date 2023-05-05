using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recomendations
{
    public partial class Form6 : Form
    {
        private int count;

        public int User_id { get; set; }
        static public int сount { get; set; } = 0;
        public Form6(int id)
        {
            User_id = id;
            InitializeComponent();
            CenterToScreen();
        }


        private void button10_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Hide();
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = $"SELECT r.* FROM izbr l LEFT JOIN products r ON l.product_id = r.id_ WHERE l.user_id = {User_id}";

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
                buttonPrevIzbr.Enabled = false;
                buttonNextIzbr.Enabled = true;
                if (productList.Count != 0)
                {
                    string imageUrl = productList[сount].Ssilka;
                    WebClient client = new WebClient();
                    client.Headers.Add("User-Agent: Other");
                    byte[] imageBytes = client.DownloadData(imageUrl);
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        var image = Image.FromStream(ms);
                        pictureProductIzbr.Image = image;
                    }
                    labelTitleIzbr.Text = productList[сount].Name;
                    labelRatingIzbr.Text = productList[сount].Rating.ToString();
                    labelOtzIzbr.Text = productList[сount].Otz.ToString();
                }
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

        private void buttonNextIzbr_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = $"SELECT l.* FROM products l LEFT JOIN izbr r ON r.product_id = l.id_ WHERE r.user_id = {User_id}";

            int length;

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
                length = productList.Count;
                if (count == length)
                {
                    buttonNextIzbr.Enabled = false;
                    buttonPrevIzbr.Enabled = true;
                    return;
                }
                else
                {
                    buttonNextIzbr.Enabled = true;
                    buttonPrevIzbr.Enabled = true;
                }
                string imageUrl = productList[count].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProductIzbr.Image = image;
                }
                labelTitleIzbr.Text = productList[count].Name;
                labelRatingIzbr.Text = productList[count].Rating.ToString();
                labelOtzIzbr.Text = productList[count].Otz.ToString();
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

        private void buttonPrevIzbr_Click_1(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DB.GetConnection();
            NpgsqlCommand command = connection.CreateCommand();

            command.CommandText = $"SELECT l.* FROM products l LEFT JOIN izbr r ON r.product_id = l.id_ WHERE r.user_id = {User_id}";

            int length;
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
                length = productList.Count;
                count--;
                if (count == length)
                {
                    buttonPrevIzbr.Enabled = false;
                    buttonNextIzbr.Enabled = true;
                    return;
                }
                else
                {
                    buttonNextIzbr.Enabled = true;
                    buttonPrevIzbr.Enabled = true;
                }
                string imageUrl = productList[count].Ssilka;
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent: Other");
                byte[] imageBytes = client.DownloadData(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    var image = Image.FromStream(ms);
                    pictureProductIzbr.Image = image;
                }
                labelTitleIzbr.Text = productList[count].Name;
                labelRatingIzbr.Text = productList[count].Rating.ToString();
                labelOtzIzbr.Text = productList[count].Otz.ToString();
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
}
