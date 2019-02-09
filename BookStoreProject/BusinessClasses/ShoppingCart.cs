using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreProject.BusinessClasses
{
    
    public class ShoppingCart
    {

        public List<CartItem> Items { get; private set; }

        public static readonly ShoppingCart Instance;

        static ShoppingCart()
        {
            if (HttpContext.Current.Session["ASPNETShoppingCart"] == null)
            {
                Instance = new ShoppingCart();
                Instance.Items = new List<CartItem>();
                HttpContext.Current.Session["ASPNETShoppingCart"] = Instance;
            }
            else
            {
                Instance = (ShoppingCart)HttpContext.Current.Session["ASPNETShoppingCart"];
            }
        }
                
            

        protected ShoppingCart() { }

        public void RemoveAllItems()
        {
            Items.Clear();
        }
        public void AddItem(int productId)
        {
            CartItem newItem = new CartItem(productId);

            if (Items.Contains(newItem))
            {
                foreach (CartItem item in Items)
                {
                    if (item.Equals(newItem))
                    {
                        item.Quantity++;
                        return;
                    }
                }
            }
            else
            {
                newItem.Quantity = 1;
                Items.Add(newItem);
            }

        }

        public void SetItemQuantity(int productId, int quantity)
        {
            if (quantity == 0)
            {
                RemoveItem(productId);
                return;
            }

            CartItem updatedItem = new CartItem(productId);

            foreach (CartItem item in Items)
            {
                if (item.Equals(updatedItem))
                {
                    item.Quantity = quantity;
                    return;
                }
            }
        }

        public void RemoveItem(int productId)
        {
            CartItem removedItem = new CartItem(productId);
            Items.Remove(removedItem);
        }

        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (CartItem item in Items)
            {
                subTotal += item.TotalPrice;
            }
            return subTotal;
        }
        
    }
}