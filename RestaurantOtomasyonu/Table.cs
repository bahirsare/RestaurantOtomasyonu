namespace RestaurantOtomasyonu
{
    internal class Table
    {
        int TableId;
        int ClientCount;
        bool IsOccupied;
        List<Order> Orders = new List<Order>();
        static List<Table> Tables = new List<Table>();
        public Table(int ClientCount)
        {
            this.ClientCount = ClientCount;
            this.IsOccupied = true;
            this.TableId = Tables.Count + 1;
            Tables.Add(this);
        }
        public Table()
        {
            this.TableId = Tables.Count + 1;
            this.ClientCount = 0;
            this.IsOccupied = false;
            Tables.Add(this);
        }
        internal void TakeOrder()
        {
            Table selectedTable = SelectTable();
            if (selectedTable != null)
            {
                Console.WriteLine($"Hoşgeldiniz, Masa {selectedTable.TableId} geçebilirsiniz.\nKaç kişi olacaksınız?");
                if (int.TryParse(Console.ReadLine(), out int clientCount) && clientCount > 0)
                {
                    selectedTable.IsOccupied = true;
                    for (int i = 0; i < clientCount; i++)
                    {
                        Console.Clear();
                        Menu menu = new Menu();
                        menu.ListMenu();
                        while (true)
                        {
                            Console.WriteLine("Siparişinizi ID olarak giriniz:");
                            if (int.TryParse(Console.ReadLine(), out int id))
                            {
                                bool itemFound = false;
                                foreach (Menu item in Menu.WholeMenu)
                                {
                                    if (item.Id == id)
                                    {
                                        SaveOrder(item, selectedTable);
                                        itemFound = true;
                                        Thread.Sleep(1000);
                                        break;
                                    }
                                }
                                if (!itemFound)
                                {
                                    Console.WriteLine("Geçersiz ID. Lütfen tekrar deneyin.");
                                }
                                Console.WriteLine("Başka bir isteğiniz var mı? (E/H)");
                                string answer = Console.ReadLine().ToUpper();
                                if (answer != "E")
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("ID değeri yalnızca sayı olabilir.");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz Giriş! Lütfen 1 veya daha büyük bir sayı girin.");
                }
            }
            else
            {
                Console.WriteLine("Boş masa bulunamadı.");
            }
        }
        internal Table SelectTable()
        {
            foreach (Table table in Tables)
            {
                if (table.IsOccupied == false)
                {
                    return table;
                }
            }
            return null;
        }
        internal Table SelectTable(int id)
        {
            foreach (Table table in Tables)
            {
                if (table.TableId == id)
                {
                    return table;
                }
            }
            return null;
        }
        void ListOrders()
        {
            foreach (Order item in Orders)
            {
                Console.WriteLine($"Ürün Adı: {item.Name} Fiyatı: {item.Price} Adet:{item.quantity}");
            }
        }
        void ListOrders(int tableId)
        {
            foreach (Order item in Orders)
            {
                if (item.TableId == tableId)
                    Console.WriteLine($"Ürün Adı: {item.Name} Fiyatı: {item.Price} Masa Numarası: {tableId} Adet:{item.quantity}");
            }
        }
        void SaveOrder(Menu item, Table selectedTable)
        {
            foreach (Order order1 in Orders)
            {
                if (order1.Name == item.Name)
                {
                    order1.quantity++;
                    Console.WriteLine("Sipariş alındı.");
                    ListOrders(selectedTable.TableId);
                    return;
                }
            }
            Order order = new Order(item.Id, item.Name, selectedTable.TableId, item.Price);
            Orders.Add(order);
            Console.WriteLine("Sipariş alındı.");
            ListOrders(selectedTable.TableId);

        }
        internal void GenerateBill()
        {
            Console.WriteLine("Hesap Almak İstediğiniz Masa idsini Giriniz.");
            double bill = 0;
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                ListOrders(id);
                for (int i = 0; i < Orders.Count; i++)
                {
                    if (Orders[i].TableId == id)
                    {
                        bill += Orders[i].Price * Orders[i].quantity;
                        Orders.RemoveAt(i);
                        i--;
                    }
                }
                if (bill > 0)
                {
                    Table selectedTable = SelectTable(id);
                    if (selectedTable != null)
                    {
                        selectedTable.IsOccupied = false;
                        Console.WriteLine($"Masa {id} için Hesap:{bill}\nAfiyet Olsun, Yine Bekleriz!");
                    }
                }
                else
                {
                    Console.WriteLine("Girilen Masada Hesap Yok.");
                }
            }
            else { Console.WriteLine("Geçersiz masa idsi"); }
        }
    }
}
