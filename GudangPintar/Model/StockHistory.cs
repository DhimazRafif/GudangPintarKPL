using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintar.Model
{
    public class StockHistory
    {
        private int historyid;
        private Stock stock {  get; set; }
        private int changed_quantity {  get; set; }
        private User changed_by_user { get; set; }
        private DateTime change_date { get; set; }

        public StockHistory(Stock stock, int changed_quantity, User changed_by_user, DateTime change_date)
        {
            this.stock = stock;
            this.changed_quantity = changed_quantity;
            this.changed_by_user = changed_by_user;
            this.change_date = change_date;
        }
    }
}
