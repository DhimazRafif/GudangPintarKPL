using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintar.Model
{
    public class Stock
    {
        private int itemid;
        private string name {  get; set; }
        private int quantity {  get; set; }
        private double price {  get; set; }
        private Category category;
        private int notification_treshold {  get; set; }
        private User created_by;
        private DateTime created_at;
        private DateTime updated_at;

        public Stock(string name, int quantity, double price, Category category, int notification_treshold)
        {
            this.name = name;
            this.quantity = quantity;
            this.price = price;
            this.category = category;
            this.notification_treshold = notification_treshold;
        }
    }
}
