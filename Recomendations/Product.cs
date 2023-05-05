using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendations
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sostav { get; set; }
        public string Ostr { get; set; }
        public string Ssilka { get; set; }
        public int Otz { get; set; }
        public double Rating { get; set; }

        public Product(int id, string name, string sostav, string ostr, string ssilka, int otz, double rating)
        {
            Id = id;
            Name = name;
            Sostav = sostav;
            Ostr = ostr;
            Ssilka = ssilka;
            Otz = otz;
            Rating = rating;
        }

        public Product()
        {
        }
    }
}
