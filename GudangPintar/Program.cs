using System;
using System.Collections.Generic;
using GudangPintar.Model;

namespace GudangPintar
{
    class Program
    {
        static List<User> users = new List<User>();
        static List<Stock> stocks = new List<Stock>();
        static List<StockHistory> histories = new List<StockHistory>();

        static User currentUser;

        static void Main(string[] args)
        {
            SeedData();

            currentUser = Login();

            if (currentUser.Role == Role.Admin)
                MenuAdmin();
            else
                MenuPegawai();
        }

        // ================= SAFE CLEAR =================
        // OutputTpe WinEXE error kalau langsung Console.Clear, Fix later
        static void SafeClear()
        {
            try
            {
                if (!Console.IsOutputRedirected)
                    Console.Clear();
            }
            catch { }
        }

        // ================= DATA AWAL =================
        static void SeedData()
        {
            users.Add(new User("admin", "admin123", Role.Admin));
            users.Add(new User("pegawai", "pegawai123", Role.Employee));

            stocks.Add(new Stock("Buku", Category.ATK, 20, 5000));
            stocks.Add(new Stock("Beras", Category.Sembako, 5, 12000));
        }

        // ================= LOGIN =================
        static User Login()
        {
            while (true)
            {
                SafeClear();
                Console.WriteLine("=== LOGIN ===");

                Console.Write("Username: ");
                string usernameInput = Console.ReadLine();

                Console.Write("Password: ");
                string passwordInput = Console.ReadLine();

                foreach (var dataUser in users)
                {
                    if (dataUser.Username == usernameInput && dataUser.Password == passwordInput)
                    {
                        Console.WriteLine("Login berhasil!");
                        Console.ReadKey();
                        return dataUser;
                    }
                }

                Console.WriteLine("Login gagal!");
                Console.ReadKey();
            }
        }

        // ================= MENU ADMIN =================
        static void MenuAdmin()
        {
            while (true)
            {
                SafeClear();
                Console.WriteLine("=== MENU ADMIN ===");
                Console.WriteLine("1. Lihat Stok");
                Console.WriteLine("2. Kelola Akun");
                Console.WriteLine("3. Kelola Stok");
                Console.WriteLine("4. Lihat Histori");
                Console.WriteLine("5. Logout");

                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1": LihatStok(); break;
                    case "2": KelolaAkun(); break;
                    case "3": KelolaStok(); break;
                    case "4": LihatHistori(); break;
                    case "5": return;
                }
            }
        }

        // ================= MENU PEGAWAI =================
        static void MenuPegawai()
        {
            while (true)
            {
                SafeClear();
                Console.WriteLine("=== MENU PEGAWAI ===");
                Console.WriteLine("1. Lihat Stok");
                Console.WriteLine("2. Kelola Stok");
                Console.WriteLine("3. Lihat Histori");
                Console.WriteLine("4. Logout");

                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1": LihatStok(); break;
                    case "2": KelolaStok(); break;
                    case "3": LihatHistori(); break;
                    case "4": return;
                }
            }
        }

        // Tampilkan daftar akun di Kelola Akun
        static void TampilkanDaftarAkun()
        {
            Console.WriteLine("=== DAFTAR AKUN ===");
            int no = 1;
            foreach (var userItem in users)
            {
                Console.WriteLine($"{no}. {userItem.Username} | {userItem.Role}");
                no++;
            }
            Console.WriteLine();
        }

        // Tampilkan daftar stik di Kelola Stok
        static void TampilkanDaftarStok()
        {
            Console.WriteLine("=== DAFTAR STOK ===");
            int no = 1;
            foreach (var stockItem in stocks)
            {
                Console.WriteLine($"{no}. {stockItem.NamaBarang} | {stockItem.Kategori} | {stockItem.Jumlah} | {stockItem.Harga}");
                no++;
            }
            Console.WriteLine();
        }

        // Pilih daftar kategori saat tambah barang baru
        static Category PilihKategori()
        {
            Console.WriteLine("Pilih Kategori:");
            var listKategori = Enum.GetValues(typeof(Category));

            for (int i = 0; i < listKategori.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {listKategori.GetValue(i)}");
            }

            Console.Write("Pilihan: ");
            int pilihan = int.Parse(Console.ReadLine());

            return (Category)listKategori.GetValue(pilihan - 1);
        }

        // ================= LIHAT STOK =================
        static void LihatStok()
        {
            SafeClear();
            Console.WriteLine("=== DATA STOK ===");

            foreach (var stockItem in stocks)
            {
                Console.WriteLine($"{stockItem.NamaBarang} | {stockItem.Kategori} | {stockItem.Jumlah} | {stockItem.Harga}");
                Notification.TampilkanNotifikasi(stockItem);
            }

            Console.ReadKey();
        }

        // ================= KELOLA AKUN =================
        static void KelolaAkun()
        {
            SafeClear();
            TampilkanDaftarAkun();

            Console.WriteLine("1. Tambah Akun");
            Console.WriteLine("2. Hapus Akun");
            Console.WriteLine("3. Edit Akun");

            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    Console.Write("Username: ");
                    string newUsername = Console.ReadLine();

                    Console.Write("Password: ");
                    string newPassword = Console.ReadLine();

                    Console.WriteLine("1. Admin\n2. Employee");
                    string roleInput = Console.ReadLine();

                    Role newRole = roleInput == "1" ? Role.Admin : Role.Employee;

                    users.Add(new User(newUsername, newPassword, newRole));
                    Console.WriteLine("Akun berhasil ditambahkan!");
                    break;

                case "2":
                    Console.Write("Username yang dihapus: ");
                    string deleteUsername = Console.ReadLine();

                    users.RemoveAll(x => x.Username == deleteUsername);
                    Console.WriteLine("Akun dihapus!");
                    break;

                case "3":
                    Console.Write("Username yang diedit: ");
                    string editUsername = Console.ReadLine();

                    User foundUser = users.Find(x => x.Username == editUsername);

                    if (foundUser != null)
                    {
                        Console.Write("Password baru: ");
                        foundUser.Password = Console.ReadLine();
                        Console.WriteLine("Berhasil diupdate!");
                    }
                    else
                    {
                        Console.WriteLine("User tidak ditemukan!");
                    }
                    break;
            }

            Console.ReadKey();
        }

        // ================= KELOLA STOK =================
        static void KelolaStok()
        {
            SafeClear();
            TampilkanDaftarStok();

            Console.WriteLine("1. Tambah Barang");
            Console.WriteLine("2. Tambah Stok");
            Console.WriteLine("3. Kurangi Stok");
            Console.WriteLine("4. Edit Barang");

            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    Console.Write("Nama Barang: ");
                    string namaBaru = Console.ReadLine();

                    Category kategoriBaru = PilihKategori();

                    Console.Write("Jumlah: ");
                    int jumlahBaru = int.Parse(Console.ReadLine());

                    Console.Write("Harga: ");
                    double hargaBaru = double.Parse(Console.ReadLine());

                    stocks.Add(new Stock(namaBaru, kategoriBaru, jumlahBaru, hargaBaru));
                    Console.WriteLine("Barang ditambahkan!");
                    break;

                case "2":
                    Console.Write("Nama barang: ");
                    string namaTambah = Console.ReadLine();

                    Stock stockTambah = stocks.Find(x => x.NamaBarang == namaTambah);

                    if (stockTambah != null)
                    {
                        Console.Write("Jumlah tambah: ");
                        int jumlahTambah = int.Parse(Console.ReadLine());

                        stockTambah.TambahStok(jumlahTambah);
                        histories.Add(new StockHistory(stockTambah.NamaBarang, "Tambah", jumlahTambah, currentUser.Username));
                    }
                    break;

                case "3":
                    Console.Write("Nama barang: ");
                    string namaKurang = Console.ReadLine();

                    Stock stockKurang = stocks.Find(x => x.NamaBarang == namaKurang);

                    if (stockKurang != null)
                    {
                        Console.Write("Jumlah kurang: ");
                        int jumlahKurang = int.Parse(Console.ReadLine());

                        stockKurang.KurangiStok(jumlahKurang);
                        histories.Add(new StockHistory(stockKurang.NamaBarang, "Kurang", jumlahKurang, currentUser.Username));
                    }
                    break;

                case "4":
                    Console.Write("Nama barang: ");
                    string namaEdit = Console.ReadLine();

                    Stock stockEdit = stocks.Find(x => x.NamaBarang == namaEdit);

                    if (stockEdit != null)
                    {
                        Console.Write("Nama baru: ");
                        string namaUpdate = Console.ReadLine();

                        Category kategoriUpdate = PilihKategori();

                        Console.Write("Harga baru: ");
                        double hargaUpdate = double.Parse(Console.ReadLine());

                        stockEdit.EditStock(namaUpdate, kategoriUpdate, hargaUpdate);
                    }
                    break;
            }

            Console.ReadKey();
        }

        // ================= HISTORI =================
        static void LihatHistori()
        {
            SafeClear();
            Console.WriteLine("=== HISTORI ===");

            foreach (var historyItem in histories)
            {
                historyItem.Tampilkan();
            }

            Console.ReadKey();
        }
    }
}