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
        public Form6()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public int сount { get; set; }

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

            command.CommandText = "SELECT * FROM izbr where id_ = 1";

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
