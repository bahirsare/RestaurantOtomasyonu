namespace RestaurantOtomasyonu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu m = new Menu("yiyecek", "patlıcan", 122);
            Menu m2 = new Menu("icecek", "su", 12);
            Menu m3 = new Menu("tatli", "muhallebi", 52);
            Menu m4 = new Menu("yiyecek", "pilav", 102);
            MainMenu();
        }
        internal static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("****ANA MENU****\n1-Sipariş Girişi\n2-Hesap Oluştur\n3-Menü Düzenle\n4-Çıkış");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                }
                else if (choice == "2")
                {
                }
                else if (choice == "3")
                {
                    Console.WriteLine("****MENÜ DÜZENLE****\n1-Yeni Ürün Kaydı\n2-Ürün Düzenleme\n3-Ürün Silme\n4-Ana Menü");
                    string subChoice= Console.ReadLine();
                    if (subChoice == "1")
                    {
                        Menu m = new Menu();
                        m.AddItemtoMenu();
                    }
                    else if (subChoice == "2")
                    {
                        Menu m =new Menu();
                        m.UpdateMenu();
                    }
                    else if (subChoice == "3")
                    {
                        Menu m = new Menu();
                        m.RemovefromMenu();
                    }
                    else if (subChoice == "4")
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz Değer Girdiniz!");
                        continue;
                    }
                }
                else if (choice == "4")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Geçersiz Değer Girdiniz!");
                    continue;
                }
            }
        }
    }

}
