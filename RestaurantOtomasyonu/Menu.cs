namespace RestaurantOtomasyonu
{//menu oluşturulması düzenlenmesi ile ilgili methodlar için
    internal class Menu
    {
        internal static List<Menu> MainCourse = new List<Menu>();
        internal static List<Menu> Beverages = new List<Menu>();
        internal static List<Menu> Desserts = new List<Menu>();
        internal static List<Menu> WholeMenu = new List<Menu>();
        internal int Id;
        internal string Type;//ürün tipi (yiyecek, içecek, tatlı vb.)
        internal string Name;
        internal double Price;

        public Menu() { }
        public Menu(string type, string name, double price)
        {
            this.Id = WholeMenu.Count;
            this.Type = type;
            this.Name = name;
            this.Price = price;
            AddItemtoMenu(this);
        }
        void ListMenu(List<Menu> list)
        {
            if (list.Count == 0) return;

            foreach (Menu item in list)
            {
                Console.WriteLine($"ID: {item.Id} Ürün Adı: {item.Name} Fiyatı: {item.Price}");
            }
        }
        /// <summary>
        /// Writes lists by using Turkish equivalents of it.
        /// </summary>
        /// <param name="listName">Turkish equivalent of the list to be written </param>
        internal void ListMenu(string listName)
        {
            if (listName == "yiyecek")
            {
                if (MainCourse.Count == 0) return;
                Console.WriteLine("***Yiyecekler***");
                ListMenu(MainCourse);
            }
            else if (listName == "icecek")
            {
                if (Beverages.Count == 0) return;
                Console.WriteLine("***İçececekler***");
                ListMenu(Beverages);
            }
            else if (listName == "tatli")
            {
                if (Desserts.Count == 0) return;
                Console.WriteLine("***Tatlılar***");
                ListMenu(Desserts);
            }
            else
            {
                Console.WriteLine("Geçersiz Menü İsmi!");
            }
        }
       internal void ListMenu()
        {
            ListMenu("yiyecek");
            ListMenu("icecek");
            ListMenu("tatli");
        }
        internal void UpdateMenu()
        {
            ListMenu("all");

            Console.WriteLine("Lütfen güncellemek istediğiniz ürünün ID değerini giriniz:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                foreach (Menu item in WholeMenu)
                {
                    if (item.Id == id)
                    {
                        Console.WriteLine($"ID: {item.Id} Ürün Tipi: {item.Type} Ürün Adı: {item.Name} Fiyatı: {item.Price}");
                        Console.WriteLine("Yeni ürün adı giriniz(Değiştirmek istemiyorsanız 'Enter' tuşuna basınız.):");
                        string newName = Console.ReadLine();
                        if (newName.Length != 0)
                            item.Name = newName;
                        Console.WriteLine("Yeni ürün fiyatı giriniz(Değiştirmek istemiyorsanız 'Enter' tuşuna basınız.):");
                        if (double.TryParse(Console.ReadLine(), out double newPrice))
                        {
                            item.Price = newPrice;
                        }
                    }
                    else { Console.WriteLine("Geçersiz ID!!"); }
                }
            }
        }
        /// <summary>
        /// Creates items based on the user's responses and adds to relevant list.
        /// </summary>
        internal void AddItemtoMenu()
        {
            while (true)
            {
                Console.Clear();
                this.Id = WholeMenu.Count + 1;
                Console.WriteLine("Ürün Tipi Giriniz(yiyecek, icecek, tatli):");
                this.Type = Console.ReadLine().ToLower();

                if (!(Type == "yiyecek" || Type == "icecek" || Type == "tatli"))
                {
                    Console.WriteLine("Ürün Tipi Yanlış Girildi!!");
                    Thread.Sleep(1000);
                    continue;
                }
                else
                {
                    ListMenu(this.Type);
                }
                Console.WriteLine("Ürün Adını Giriniz:");
                this.Name = Console.ReadLine();
                bool nameControl = false;
                foreach (Menu item in WholeMenu)
                {
                    if (item.Name.Contains(this.Name))
                    {
                        Console.WriteLine("Bu isimde ürün zaten var!!");
                        nameControl = true;
                    }
                }
                if (nameControl) continue;
                Console.WriteLine("Ürün Fiyatını Giriniz:");
                if (double.TryParse(Console.ReadLine(), out this.Price))
                {
                    if (this.Price > 0)
                    {
                        AddingItemMethod();
                        Console.WriteLine("Ürün Eklendi!");
                        ListMenu(this.Type);
                        Thread.Sleep(1000);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Fiyat Sıfırdan büyük olmalı!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Fiyat sadece rakamlardan oluşmalı!");
                    Thread.Sleep(1000);
                    continue;
                }
            }
        }
        /// <summary>
        /// Allows creating object with the constructor method.
        /// </summary>
        /// <param name="menu"></param>
        internal void AddItemtoMenu(Menu menu)
        {
            this.Id = WholeMenu.Count + 1;
            if (!(Type == "yiyecek" || Type == "icecek" || Type == "tatli"))
            {
                return;
            }
            bool nameControl = false;
            foreach (Menu item in WholeMenu)
            {
                if (item.Name.Contains(this.Name))
                {
                    nameControl = true;
                }
            }
            if (nameControl) return;
            if (this.Price > 0)
            {
                AddingItemMethod();
            }
            else
            {
                return;
            }
        }
        void AddingItemMethod()
        {
            if (this.Type == "yiyecek")
            {
                WholeMenu.Add(this);
                MainCourse.Add(this);
            }
            else if (this.Type == "icecek")
            {
                WholeMenu.Add(this);
                Beverages.Add(this);
            }
            else if (this.Type == "tatli")
            {
                WholeMenu.Add(this);
                Desserts.Add(this);
            }
            else
            {
                Console.WriteLine("Hatalı giriş!");
                Thread.Sleep(1000);
            }
        }
        internal void RemovefromMenu()
        {
            ListMenu("yiyecek");
            ListMenu("icecek");
            ListMenu("tatli");
            Console.WriteLine("Lütfen silmek istediğiniz ürünün ID değerini giriniz:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                bool isFound = false;
                foreach (Menu item in WholeMenu)
                {
                    if (item.Id == id)
                    {
                        isFound = true;
                        if (MainCourse.Contains(item))
                            MainCourse.Remove(item);
                        else if (Beverages.Contains(item))
                            Beverages.Remove(item);
                        else if (Desserts.Contains(item))
                            Desserts.Remove(item);
                    }
                }
                if (isFound)
                {
                    WholeMenu.RemoveAt(id - 1);
                    Console.WriteLine("Ürün Silindi.");
                    ListMenu("yiyecek");
                    ListMenu("icecek");
                    ListMenu("tatli");
                }
                else
                {
                    Console.WriteLine("Geçersiz ID!!");
                }
            }
        }
    }
    internal class Order
    {
        public int Id;
        public string Name;
        public double Price;
        public int TableId;
        public int quantity;

        public Order(int id, string name, int tableId,double price)
        {
            this.Id = id;
            this.Name = name;
            this.TableId = tableId;
            this.Price = price;
            this.quantity = 1;
        }
        
    }

}