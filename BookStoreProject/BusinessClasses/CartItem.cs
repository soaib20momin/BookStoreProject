using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreProject.BusinessClasses
{
    public class CartItem:IEquatable<CartItem>
    {
        

        public int Quantity { get; set; }
        private int _productId;

        public int ProductId
        {
            get { return _productId; }
            set
            {
                _product = null;
                _productId = value;
            }
        }

        private Product _product = null;

        public Product Prod
        {
            get
            {
                if (_product == null)
                {
                    _product = new Product(ProductId);
                }
                return _product;
            }
        }

		public CartItem(int productId)
		{
			this.ProductId = productId;
		}

		public string Title
        {
            get { return Prod.Title; }
        }

        public string ISBN
        {
            get { return Prod.ISBN; }
        }

        public string Author
        {
            get { return Prod.Author; }
        }

        public string Publisher
        {
            get { return Prod.Publisher; }
        }

        public decimal UnitPrice
        {
            get { return Prod.Price; }
        }

        public decimal TotalPrice
        {
            get { return UnitPrice * Quantity; }
        }
		public bool Equals(CartItem item)
		{
			return item.ProductId == this.ProductId;
		}


    }
}