class Naz_world extends Lek
implements Add
    {
        String[] import = new String[10];
        String[] export = new String[10];
        public Naz_world()
        {
            name = "-";
            mass = "-";
            price = 0;
            amount = 0;
            import[0] = "-";
			export[0] = "-";
        }
        public Platform(String mass, String name, double price, int amount, String[] import1, String[] export1)
        {
            super(mass, name, price, amount);
            int i;
            for (i = 0; i < import1.length; i++)
            {
                import[i] = import1[i];
            }
            for (i = 0; i < export1.length; i++)
            {
                export[i] = export1[i];
            }
        }
        public void read(int d)
        {
            String encoding = System.getProperty("console.encoding", "cp866");
            Scanner in = new Scanner(System.in, encoding);
            super.read();
            System.out.println("Введите страну привоза (чтобы закончить введите пустую строку)");
            d = -1;
            do
            {
                d++;
                import[d] = in.nextLine();
            } while (!import[d].equals(""));
            System.out.println("Введите страну экспорта (чтобы закончить введите пустую строку)");
            d = -1;
            do
            {
                d++;
                export[d] = in.nextLine();
            } while (!export[d].equals(""));
        }
        public void display()
        {
            System.out.println(ToString());
        }
        public String ToString()
        {
            int d;
            String s;
            s = "Код лекарства: " + mass + "\n";
            s += "Название лекарства: " + name + "\n";
            s += "Цена: " + price + "\n";
            s += "Колличество: " + amount + "\n";
            s += "Импорт: ";
            for (d = 0; d < import.length; d++)
            {
                s += import[d] + ", ";
            }
            s += "\n" + "Экспорт: ";
            for (d = 0; d < export.length; d++)
            {
                s += export[d] + ", ";
            }
            return s;
        }
        public void add()
        {
            String encoding = System.getProperty("console.encoding", "cp866");
            Scanner in = new Scanner(System.in, encoding);
            int i;
            i = 0;
            while (!import[i].equals(""))
            {
                i++;
            }
            System.out.println("Введите страну: ");
            import[i] = in.nextLine();
        }
    }
