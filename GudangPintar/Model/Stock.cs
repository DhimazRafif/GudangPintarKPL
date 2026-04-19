using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintar.Model
{
    public class Stock
    {
        public string NamaBarang { get; set; }
        public Category Kategori { get; set; }
        public int Jumlah { get; set; }
        public double Harga { get; set; }

        public Stock(string nama, Category kategori, int jumlah, double harga)
        {
            NamaBarang = nama;
            Kategori = kategori;
            Jumlah = jumlah;
            Harga = harga;
        }

        public void TambahStok(int jumlah)
        {
            Jumlah += jumlah;
        }

        public void KurangiStok(int jumlah)
        {
            if (Jumlah >= jumlah)
                Jumlah -= jumlah;
            else
                Console.WriteLine("Stok tidak cukup!");
        }

        public void EditStock(string nama, Category kategori, double harga)
        {
            NamaBarang = nama;
            Kategori = kategori;
            Harga = harga;
        }
    }
}