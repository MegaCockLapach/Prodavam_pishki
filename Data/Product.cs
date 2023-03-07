using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin.Data
{
    public class Product
    {
		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private decimal price;
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
		private int stock;

		public int Stock
		{
			get { return stock; }
			set { stock = value; }
		}
		public Product(int id,string name,decimal price,int stock)
		{
			ID= id;
			Name = name;
			Price = price;
			Stock = stock;
		}
		public Product()
		{
			ID = 0;
			Name = null;
			Price = 0;
			Stock = 0;
		}
	}
}
