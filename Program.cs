using lab_12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_12
{
    interface Add
    {
        void add();
    }
    class Lek
    {
        protected string mass;
        protected string name;
        protected double price;
        protected int amount;
        public void read()
        {
            Console.WriteLine("Введите название лекарства: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите код лекарства: ");
            mass = Console.ReadLine();
            do
            {
                Console.WriteLine("Введите цену: ");
                try
                {
                    price = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    price = -1;
                }
            } while (price < 0);
            do
            {
                Console.WriteLine("Введите колличество лекарства: ");
                try
                {
                    amount = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    amount = -1;
                }
            } while (amount < 0);
        }
        public Lek(string mass, string name, double price, int amount)
        {
            this.name = name;
            this.mass = mass;
            this.price = price;
            this.amount = amount;
        }
        public Lek()
        {
            this.name = "-";
            this.mass = "-";
            this.price = 0;
            this.amount = 0;
        }
        virtual public void display()
        {
            Console.WriteLine("Название лекарства: " + name);
            Console.WriteLine("Код лекарства: " + mass);
            Console.WriteLine("Цена: " + price);
            Console.WriteLine("Колличество: " + amount);
        }
        public int Amount
        {
            set
            {
                if(value > 0)
                {
                    amount = value;
                }
            }
            get
            {
                return amount;
            }
        }
        public double Price
        {
            set
            {
                if (value > 0)
                {
                    price = value;
                }
            }
        }
        public string Mass
        {
            get
            {
                return mass;
            }
        }
    }
    class Proizvoditel : Lek, Add, ICloneable
    {
        private int[] date = new int[3];
        private string[] world_naz = new string[10];
        public Proizvoditel()
        {
            this.name = "-";
            this.mass = "-";
            this.price = 0;
            this.amount = 0;
            this.date[0] = this.date[1] = this.date[2] = -1;
            world_naz[0] = "-";
        }
        public Proizvoditel(string mass, string name, double price, int amount, int[] date, string[] world_naz)
            : base(mass, name, price, amount)
        {
            int i;
            for (i = 0; i < 3; i++)
            {
                this.date[i] = date[i];
            }
            for (i = 0; i < world_naz.Length; i++)
            {
                this.world_naz[i] = world_naz[i];
            }
        }
        public void read(int d)
        {
            Console.WriteLine("Введите название лекарства: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите код лекарства: ");
            mass = Console.ReadLine();
            do
            {
                Console.WriteLine("Введите цену: ");
                try
                {
                    price = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    price = -1;
                }
            } while (price < 0);
            do
            {
                Console.WriteLine("Введите колличество лекарства: ");
                try
                {
                    amount = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    amount = -1;
                }
            } while (amount < 0);
            Console.WriteLine("Введите дату (00.00.0000), после ввода дня, месяца, года нажмите клавишу Enter: ");
            date[0] = Convert.ToInt32(Console.ReadLine());
            date[1] = Convert.ToInt32(Console.ReadLine());
            date[2] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите страну производства (чтобы закончить введите пустую строку)");
            d = -1;
            do
            {
                d++;
                world_naz[d] = Console.ReadLine();
            } while (world_naz[d] != "");
        }
        public override void display()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            int d;
            string s;
            s = "Код лекарства: " + mass + "\n";
            s += "Название лекарства: " + name + "\n";
            s += "Цена: " + price + "\n";
            s += "Колличество: " + amount + "\n";
            s += "Дата: " + date[0] + "." + date[1] + "." + date[2] + "\n";
            s += "Страна производства: ";
            for (d = 0; d < world_naz.Length; d++)
            {
                s += world_naz[d] + ", ";
            }
            return s;
        }
        public void add()
        {
            int i;
            i = 0;
            while (world_naz[i] != "")
            {
                i++;
            }
            Console.WriteLine("Введите страну производства лекарства: ");
            world_naz[i] = Console.ReadLine();
        }
        public object Clone()
        {
            return new Proizvoditel(mass, name, price, amount, date, world_naz);
        }
    }
    class Naz_world : Lek, Add
    {
        private string[] import = new string[10];
        private string[] export = new string[10];
        public Naz_world()
        {
            this.name = "-";
            this.mass = "-";
            this.price = 0;
            this.amount = 0;
            this.import[0] = "-";
            this.export[0] = "-";
        }
        public Naz_world(string mass, string name, double price, int amount, string[] import, string[] world_naz):base(mass, name, price, amount)
        {
            int i;
            for (i = 0; i < import.Length; i++)
            {
                this.import[i] = import[i];
            }
            for (i = 0; i < world_naz.Length; i++)
            {
                this.export[i] = world_naz[i];
            }
        }
        public void read(int d)
        {
            Console.WriteLine("Введите название лекарства: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите код лекарства: ");
            mass = Console.ReadLine();
            do
            {
                Console.WriteLine("Введите цену: ");
                try
                {
                    price = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    price = -1;
                }
            } while (price < 0);
            do
            {
                Console.WriteLine("Введите колличество лекарства: ");
                try
                {
                    amount = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    amount = -1;
                }
            } while (amount < 0);
            Console.WriteLine("Введите название страны привоза (чтобы закончить введите пустую строку)");
            d = -1;
            do
            {
                d++;
                import[d] = Console.ReadLine();
            } while (import[d] != "");
            Console.WriteLine("Введите название страны вывоза(чтобы закончить введите пустую строку)");
            d = -1;
            do
            {
                d++;
                export[d] = Console.ReadLine();
            } while (export[d] != "");
        }
        public override void display()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            int d;
            string s;
            s = "Код лекарства: " + mass + "\n";
            s += "Название лекарства: " + name + "\n";
            s += "Цена: " + price + "\n";
            s += "Колличество: " + amount + "\n";
            s += "Импорт: ";
            for (d = 0; d < import.Length; d++)
            {
                s += import[d] + ", ";
            }
            s += "\n" + "Экспорт: ";
            for (d = 0; d < export.Length; d++)
            {
                s += export[d] + ", ";
            }
            return s;
        }
        public void add()
        {
            int i;
            i = 0;
            while (import[i] != "")
            {
                i++;
            }
            Console.WriteLine("Введите название страны привоза: ");
            import[i] = Console.ReadLine();
        }
    }
}
    class Apteka
    {
        private string name;
        private string num;
        private int numOfMeds;
        private static int maxNumOfMeds = 10;
        private int numOfProzs;
        private int numOfWorlds;
        private Lek[] lek = new Lek[5];
        private Proizvoditel[] proizvoditel = new Proizvoditel[5];
        private Naz_world[] naz_world = new Naz_world[5];
        public void read()
        {
            string f;
            Console.WriteLine("Введите название аптеки: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите номер аптеки: ");
            num = Console.ReadLine();
            numOfMeds = 0;
            Console.WriteLine("Добавить лекарство ?(1 - да, 0 - нет)");
            f = Console.ReadLine();
            while (f == "1" && numOfMeds < maxNumOfMeds)
            {
                lek[numOfMeds] = new Lek();
                lek[numOfMeds].read();
                numOfMeds++;
                Console.WriteLine("Добавить лекарство ?(1 - да, 0 - нет)");
                f = Console.ReadLine();
                if (f == "0")
                {
                    break;
                }
            }
            numOfProzs = 0;
            Console.WriteLine("Добавить производителя ?(1 - да, 0 - нет)");
            f = Console.ReadLine();
            while (f == "1")
            {
                proizvoditel[numOfProzs] = new Proizvoditel();
                proizvoditel[numOfProzs].read(1);
                numOfProzs++;
                Console.WriteLine("Добавить ещё производителя ?(1 - да, 0 - нет)");
                f = Console.ReadLine();
                if (f == "0")
                {
                    break;
                }
            }
            numOfWorlds = 0;
            Console.WriteLine("Добавить страну производства ?(1 - да, 0 - нет)");
            f = Console.ReadLine();
            while (f == "1")
            {
                naz_world[numOfWorlds] = new Naz_world();
                naz_world[numOfWorlds].read(1);
                numOfWorlds++;
                Console.WriteLine("Добавить ещё страну производства ?(1 - да, 0 -нет)");
                f = Console.ReadLine();
            }
        }
        public Apteka(string name, string num, int numOfMeds, Lek[] lek, int numOfProzs, Proizvoditel[] proz, int numOfWorlds, Naz_world[] world)
        {
            int i;
            if (numOfMeds < Apteka.maxNumOfMeds)
            {
                this.name = name;
                this.num = num;
                this.numOfMeds = numOfMeds;
                for (i = 0; i < this.numOfMeds; i++)
                {
                    this.lek[i] = lek[i];
                }
                this.numOfProzs = numOfProzs;
                for (i = 0; i < this.numOfProzs; i++)
                {
                    this.proizvoditel[i] = proz[i];
                }
                this.numOfWorlds = numOfWorlds;
                for (i = 0; i < this.numOfWorlds; i++)
                {
                    this.naz_world[i] = world[i];
                }
            }
        }
        public Apteka(string name)
        {
            this.name = name;
            this.num = "-";
            this.numOfMeds = 0;
            this.numOfProzs = 0;
            this.numOfWorlds = 0;
        }
        public Apteka()
        {
            this.name = "-";
            this.num = "-";
            this.numOfMeds = 0;
            this.numOfProzs = 0;
            this.numOfWorlds = 0;
        }
        public void display()
        {
            int i;
            Console.WriteLine("Название аптеки: " + name);
            Console.WriteLine("Номер: " + num);
            Console.WriteLine("Колличество уникальных лекарств: " + numOfMeds);
            Console.WriteLine("Колличество мест для лекарств: " + maxNumOfMeds);
            for (i = 0; i < numOfMeds; i++)
            {
                Console.WriteLine("Лекарство: " + (i + 1));
                lek[i].display();
            }
            for (i = 0; i < numOfProzs; i++)
            {
                Console.WriteLine("Производитель: " + (i + 1));
                proizvoditel[i].display();
            }
            for (i = 0; i < numOfWorlds; i++)
            {
                Console.WriteLine("Страна производства: " + (i + 1));
                naz_world[i].display();
            }
        }
        public static Apteka operator ++ (Apteka apteka)
        {
            Apteka newApteka = new Apteka();
            Exception a;
            string f;
            int n;
            try
            {
                if (apteka.numOfMeds >= Apteka.maxNumOfMeds)
                {
                    throw a = new Exception("0");
                }
                newApteka.name = apteka.name;
                newApteka.num = apteka.num;
                newApteka.numOfMeds = apteka.numOfMeds;
                newApteka.numOfProzs = apteka.numOfProzs;
                newApteka.numOfWorlds = apteka.numOfWorlds;
                for (n = 0; n < apteka.numOfMeds; n++)
                {
                    newApteka.lek[n] = new Lek();
                    newApteka.lek[n] = apteka.lek[n];
                }
                for (n = 0; n < apteka.numOfProzs; n++)
                {
                    newApteka.proizvoditel[n] = new Proizvoditel();
                    newApteka.proizvoditel[n] = apteka.proizvoditel[n];
                }
                for (n = 0; n < apteka.numOfWorlds; n++)
                {
                    newApteka.naz_world[n] = new Naz_world();
                    newApteka.naz_world[n] = apteka.naz_world[n];
                }
                Console.WriteLine("Добавить лекарство - 1, производителя - 2, страну производства - 3");
                f = Console.ReadLine();
                if (f == "1")
                {
                    newApteka.lek[apteka.numOfMeds] = new Lek();
                    newApteka.lek[apteka.numOfMeds].read();
                    newApteka.numOfMeds = ++apteka.numOfMeds;
                }
                else if (f == "2")
                {
                    newApteka.proizvoditel[apteka.numOfProzs] = new Proizvoditel();
                    newApteka.proizvoditel[apteka.numOfProzs].read(1);
                    newApteka.numOfProzs = ++apteka.numOfProzs;
                }
                else
                {
                    newApteka.naz_world[apteka.numOfWorlds] = new Naz_world();
                    newApteka.naz_world[apteka.numOfWorlds].read(1);
                    newApteka.numOfWorlds = ++apteka.numOfWorlds;
                }
                return newApteka;
            }
            catch(Exception)
            {
                return apteka;
            }
        }
        public void priceChange(string mass, double price)
        {
            int i, f;
            i = f = 0;
            while (i < numOfMeds)
            {
                if (lek[i].Mass == mass)
                {
                    lek[i].Price = price;
                    i = numOfMeds;
                    f = 1;
                }
                i++;
            }
            if (f == 0)
            {
                i = 0;
                while (i < numOfProzs)
                {
                    if (proizvoditel[i].Mass == mass)
                    {
                        proizvoditel[i].Price = price;
                        i = numOfProzs;
                        f = 1;
                    }
                    i++;
                }
            }
            if (f == 0)
            {
                i = 0;
                while (i < numOfWorlds)
                {
                    if (naz_world[i].Mass == mass)
                    {
                        naz_world[i].Price = price;
                        i = numOfWorlds;
                        f = 1;
                    }
                    i++;
                }
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public static Apteka operator + (Apteka apteka1, Apteka apteka2) {
            int n, i;
            Apteka newApteka = new Apteka();
            Exception a;
            try
            {
                if (apteka1.numOfMeds + apteka2.numOfMeds > Apteka.maxNumOfMeds)
                {
                    throw a = new Exception("0");
                }
                newApteka.name = apteka1.name;
                newApteka.num = apteka1.num;
                newApteka.numOfMeds = apteka1.numOfMeds + apteka2.numOfMeds;
                for (n = 0; n < apteka1.numOfMeds; n++)
                {
                    newApteka.lek[n] = apteka1.lek[n];
                }
                i = apteka1.numOfMeds;
                for (n = 0; n < apteka2.numOfMeds; n++)
                {
                    newApteka.lek[i] = apteka2.lek[n];
                    i++;
                }
                newApteka.numOfProzs = apteka1.numOfProzs + apteka2.numOfProzs;
                for (n = 0; n < apteka1.numOfProzs; n++)
                {
                    newApteka.proizvoditel[n] = apteka1.proizvoditel[n];
                }
                i = apteka1.numOfProzs;
                for (n = 0; n < apteka2.numOfProzs; n++)
                {
                    newApteka.proizvoditel[i] = apteka2.proizvoditel[n];
                    i++;
                }
                newApteka.numOfWorlds = apteka1.numOfWorlds + apteka2.numOfWorlds;
                for (n = 0; n < apteka1.numOfWorlds; n++)
                {
                    newApteka.naz_world[n] = apteka1.naz_world[n];
                }
                i = apteka1.numOfWorlds;
                for (n = 0; n < apteka2.numOfWorlds; n++)
                {
                    newApteka.naz_world[i] = apteka2.naz_world[n];
                    i++;
                }
                return newApteka;
            }
            catch (Exception)
            {
                return apteka1;
            }
        }
        public void getNumber(out int number)
        {
            number = numOfMeds;
        }
        public void getNumber1(ref int number)
        {
            number = numOfMeds;
        }
        public static void maxNumOfMedsChange(int newMax)
        {
            Apteka.maxNumOfMeds = newMax;
        }
        public void add(string mass)
        {
            int i, f;
            i = f = 0;
            while (i < numOfProzs)
            {
                if (proizvoditel[i].Mass == mass)
                {
                    proizvoditel[i].add();
                    i = numOfProzs;
                    f = 1;
                }
                i++;
            }
            if (f == 0)
            {
                i = 0;
                while (i < numOfWorlds)
                {
                    if (naz_world[i].Mass == mass)
                    {
                        naz_world[i].add();
                        i = numOfWorlds;
                        f = 1;
                    }
                    i++;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Apteka[] apteka1 = new Apteka[10];
            Lek[] lek1 = new Lek[10];
            Proizvoditel[] proz1 = new Proizvoditel[10];
            Naz_world[] world1 = new Naz_world[10];
            int numOfMeds, i, max, n, numOfProzs, numOfWorlds = 0, lekAmount, d;
            int[] date = new int[3];
            double price;
            double lekPrice;
            string f, mass, name, num, lekMass, lekName;
            string[] s1 = new string[10], worlds = new string[10], world_naz = new string[10], import = new string[10];
            Console.WriteLine("Использовать или read чтобы ввести данные(1 - read, 2 - init)");
            f = Console.ReadLine();
            if (f == "1")
            {
                apteka1[0] = new Apteka();
                apteka1[0].read();
            }
            else if (f == "2")
            {
                Console.WriteLine("Ввести все параметры (1), только название (2), не вводить параметры(3)");
                f = Console.ReadLine();
                if (f == "1")
                {
                    Console.WriteLine("Введите название аптеки: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Введите номер аптеки: ");
                    num = Console.ReadLine();
                    numOfMeds = 0; ;
                    Console.WriteLine("Добавить лекарство ?(1 - да, 0 - нет)");
                    f = Console.ReadLine();
                    while (f == "1")
                    {
                        Console.WriteLine("Введите название лекарства: ");
                        lekName = Console.ReadLine();
                        Console.WriteLine("Введите код лекарства: ");
                        lekMass = Console.ReadLine();
                        do
                        {
                            Console.WriteLine("Введите цену: ");
                            try
                            {
                                lekPrice = Convert.ToDouble(Console.ReadLine());
                            }
                            catch (FormatException){
                                lekPrice = -1;
                            }
                        } while (lekPrice < 0);
                        do
                        {
                            Console.WriteLine("Введите колличество лекарства: ");
                            try
                            {
                                lekAmount = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                lekAmount = -1;
                            }
                        } while (lekAmount < 0);
                        lek1[numOfMeds] = new Lek(lekName, lekMass, lekPrice, lekAmount);
                        numOfMeds++;
                        Console.WriteLine("Добавить лекарство ?(1 - да, 0 - нет)");
                        f = Console.ReadLine();
                        if (f == "0")
                        {
                            break;
                        }
                    }
                    numOfProzs = 0;
                    Console.WriteLine("Добавить производителя ? (1 - да, 0 - нет)");
                    f = Console.ReadLine();
                    while (f == "1")
                    {
                        Console.WriteLine("Введите название производителя: ");
                        lekName = Console.ReadLine();
                        Console.WriteLine("Введите код производителя: ");
                        lekMass = Console.ReadLine();
                        do {
                            Console.WriteLine("Введите цену: ");
                            try
                            {
                                lekPrice = Convert.ToDouble(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                lekPrice = -1;
                            }
                        } while (lekPrice < 0);
                        do
                        {
                            Console.WriteLine("Введите колличество лекарства: ");
                            try
                            {
                                lekAmount = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                lekAmount = -1;
                            }
                        } while (lekAmount < 0);
                        Console.WriteLine("Введите дату (00.00.0000) день, месяц, год после ввода дня, месяца, года нажимайте Enter)");
                        date[0] = Convert.ToInt32(Console.ReadLine());
                        date[1] = Convert.ToInt32(Console.ReadLine());
                        date[2] = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите страну производства (чтобы закончить введите пустую строку)");
                        numOfWorlds = 0;
                        d = -1;
                        do
                        {
                            numOfWorlds++;
                            d++;
                            worlds[d] = Console.ReadLine();
                        } while (worlds[d] != "");
                        proz1[numOfProzs] = new Proizvoditel(lekName, lekMass, lekPrice, lekAmount, date, worlds);
                        numOfProzs++;
                        Console.WriteLine("Добавить ещё производителя ?(1 - да, 0 - нет)");
                        f = Console.ReadLine();
                    }
                    apteka1[0] = new Apteka(name, num, numOfMeds, lek1, numOfProzs, proz1, numOfWorlds, world1);
                }
                else if (f == "2")
                {
                    Console.WriteLine("Введите название аптеки: ");
                    name = Console.ReadLine();
                    apteka1[0] = new Apteka(name);
                }
                else {
                    apteka1[0] = new Apteka();
                }
            }
            i = 0;
            max = 1;
            f = "1";
            while (f != "10")
            {
                Console.WriteLine("Введите номер следующего действия:");
                Console.WriteLine("1 - показать информацию о аптеки");
                Console.WriteLine("2 - добавить новое лекарство");
                Console.WriteLine("3 - изменить цену лекарства");
                Console.WriteLine("4 - добавить аптеку");
                Console.WriteLine("5 - показать все аптеки");
                Console.WriteLine("6 - сменить аптеку");
                Console.WriteLine("7 - сложить аптеки");
                Console.WriteLine("8 - добавить страну производства лекарства");
                Console.WriteLine("9 - копирование");
                Console.WriteLine("10 - выйти");
                f = Console.ReadLine();
                if (f == "1")
                {
                    apteka1[i].display();
                }
                else if (f == "2")
                {
                    apteka1[i] = ++apteka1[i];
                }
                else if (f == "3")
                {
                    Console.WriteLine("Введите код лекарства: ");
                    mass = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Введите новую цену: ");
                        try
                        {
                            price = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            price = -1;
                        }
                    } while (price < 0);
                    apteka1[i].priceChange(mass, price);
                }
                else if (f == "4")
                {
                    apteka1[max] = new Apteka();
                    apteka1[max].read();
                    i = max;
                    max++;

                }
                else if (f == "5")
                {
                    for (n = 0; n < max; n++)
                    {
                        Console.WriteLine("Аптека: " + apteka1[n].Name);
                    }
                }
                else if (f == "6")
                {
                    Console.WriteLine("Введите название аптеки: ");
                    name = Console.ReadLine();
                    for (n = 0; n < max; n++)
                    {
                        if (apteka1[n].Name == name)
                        {
                            i = n;
                            n = max;
                        }
                    }
                }
                else if (f == "7")
                {
                    Console.WriteLine("Введите название аптеки: ");
                    name = Console.ReadLine();
                    for (n = 0; n < max; n++)
                    {
                        if (apteka1[n].Name == name)
                        {
                            apteka1[i] = apteka1[i] + apteka1[n];
                            n = max;
                        }
                    }
                }
                else if (f == "8")
                {
                    Console.WriteLine("Введите код лекарства: ");
                    mass = Console.ReadLine();
                    apteka1[i].add(mass);
                }
                else if (f == "9")
                {
                    date[0] = date[1] = date[2] = 1;
                    worlds[0] = "aaa";
                    proz1[0] = new Proizvoditel("proz", "proz", 1, 1, date, world_naz);
                    worlds[0] = "zzz";
                    world1[0] = new Naz_world("world", "world", 2, 2, import, world_naz);
                    proz1[1] = (Proizvoditel)proz1[0].Clone();
                    proz1[1].Amount = 2;
                    proz1[0].display();
                    world1[1] = world1[0];
                    world1[1].Amount = 3;
                    world1[0].display();
                }
            }
        }
    }