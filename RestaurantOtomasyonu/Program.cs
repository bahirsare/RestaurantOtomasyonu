namespace RestaurantOtomasyonu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu m1 = new Menu("yiyecek", "Kızartılmış Tavuk Kanatları", 200);
            Menu m2 = new Menu("yiyecek", "Sebzeli Pizza", 250);
            Menu m3 = new Menu("yiyecek", "Kumpir", 120);
            Menu m4 = new Menu("icecek", "Taze Sıkılmış Portakal Suyu", 30);
            Menu m5 = new Menu("icecek", "Ayran", 30);
            Menu m6 = new Menu("tatli", "Baklava", 75);
            Menu m7 = new Menu("tatli", "Çikolatalı Sufle", 87);


            MainMenu();
        }
        internal static void MainMenu()
        {
            Table table1 = new Table();
            Table table2 = new Table();
            Table table3 = new Table();
            Table table4 = new Table();
            Table table5 = new Table();
            Menu m = new Menu();
            while (true)
            {
                Console.WriteLine("****ANA MENU****\n1-Sipariş Girişi\n2-Hesap Oluştur\n3-Menü Düzenle\n4-Çıkış");
                string choice = Console.ReadLine();
               if (choice == "1")//sipariş al
                {
                    table1.TakeOrder();   
                }
                else if (choice == "2")//hesap al
                {
                    table1.GenerateBill();
                }
                else if (choice == "3")
                {
                    Console.WriteLine("****MENÜ DÜZENLE****\n1-Yeni Ürün Kaydı\n2-Ürün Düzenleme\n3-Ürün Silme\n4-Ana Menü");
                    string subChoice= Console.ReadLine();
                    if (subChoice == "1")
                    {                        
                        m.AddItemtoMenu();
                    }
                    else if (subChoice == "2")
                    {                        
                        m.UpdateMenu();
                    }
                    else if (subChoice == "3")
                    {                        
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
