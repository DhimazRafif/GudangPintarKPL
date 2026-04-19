using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintar.Model
{
    public class Notification
    {
        public static void TampilkanNotifikasi(Stock stock)
        {
            StockAlertStatus.HandleState(stock);
        }
    }
}