class Proizvoditel extends Lek
implements Add, Cloneable
    {
        int[] date = new int[3];
        String[] world_naz = new String[10];
        Game()
        {
            name = "-";
            mass = "-";
            price = 0;
            amount = 0;
            date[0] = date[1] = date[2] = -1;
            world_naz[0] = "-";
        }
        Proizvoditel(String mass, String name, double price, int amount, int[] date1, String[] world_naz1)
        {
            super(mass, name, price, amount);
            int i;
            for (i = 0; i < 3; i++)
            {
                date[i] = date1[i];
            }
            for (i = 0; i < world_naz1.length; i++)
            {
                world_naz[i] = world_naz1[i];
            }
        }
        void read(int d)
        {
            String encoding = System.getProperty("console.encoding", "cp866");
            Scanner in = new Scanner(System.in, encoding);
            super.read();
            System.out.println("Введите дату (00.00.0000), после нажмите Enter)");
            date[0] = in.nextInt();
            date[1] = in.nextInt();
            date[2] = in.nextInt();
            in.nextLine();
            System.out.println("Введите страну производства (чтобы закончить введите пустую строку)");
            d = -1;
            do
            {
                d++;
                world_naz[d] = in.nextLine();
            } while (!world_naz[d].equals(""));
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
            s += "Дата: " + date[0] + "." + date[1] + "." + date[2] + "\n";
            s += "Страны производства: ";
            for (d = 0; d < world_naz.length; d++)
            {
                s += world_naz[d] + ", ";
            }
            return s;
        }
        public void add()
        {
            String encoding = System.getProperty("console.encoding", "cp866");
            Scanner in = new Scanner(System.in, encoding);
            int i;
            i = 0;
            while (!world_naz[i].equals(""))
            {
                i++;
            }
            System.out.println("Введите страны производства: ");
            world_naz[i] = in.nextLine();
        }
        public Object clone()
        {
            try{
                return (Proizvoditel)super.clone();
            }
            catch(CloneNotSupportedException e){
                return this;
            }
        }
    }
