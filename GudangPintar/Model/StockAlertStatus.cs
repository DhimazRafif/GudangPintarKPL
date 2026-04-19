using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintar.Model
{
    public enum AlertState
    {
        Aman,
        Menipis,
        Habis
    }

    public class StockAlertStatus
    {
        public static AlertState GetState(int jumlah)
        {
            if (jumlah == 0)
                return AlertState.Habis;
            else if (jumlah < 10)
                return AlertState.Menipis;
            else
                return AlertState.Aman;
        }

        public static void HandleState(Stock stock)
        {
            AlertState state = GetState(stock.Jumlah);

            switch (state)
            {
                case AlertState.Aman:
                    Console.WriteLine($"[AMAN] {stock.NamaBarang} : {stock.Jumlah}");
                    break;

                case AlertState.Menipis:
                    Console.WriteLine($"[PERINGATAN] {stock.NamaBarang} menipis! Sisa: {stock.Jumlah}");
                    break;

                case AlertState.Habis:
                    Console.WriteLine($"[KRITIS] {stock.NamaBarang} HABIS!");
                    break;

                default:
                    Console.WriteLine("Status tidak diketahui");
                    break;
            }
        }
    }
}