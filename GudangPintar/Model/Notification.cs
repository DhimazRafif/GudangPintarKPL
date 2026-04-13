using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintar.Model
{
    public class Notification
    {
        private Stock Stock;
        private string message {  get; set; }
        private DateTime timestamp {  get; set; }

        public Notification(Stock stock, string message)
        {
            this.Stock = stock;
            this.message = message;
        }
    }
}
