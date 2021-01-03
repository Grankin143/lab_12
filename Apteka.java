import java.util.Scanner;

public class Apteka {
    String name;
    String num;
    int numOfMeds;
    static int maxNumOfMeds = 10;
    int numOfProzs;
    int numOfWorlds;
    Lek[] lek = new Lek[5];
    Proizvoditel[] proz = new Proizvoditel[5];
    Naz_world[] naz_world = new Naz_world[5];
    void read(){
        int f,i;
        String encoding = System.getProperty("console.encoding", "cp866");
        Scanner in = new Scanner(System.in, encoding);
        System.out.println("Введите название аптеки: ");
        name = in.nextLine();
        System.out.println("Введите номер аптеки: ");
        num = in.nextLine();
        System.out.println("Добавить лекарство ? (1 - да, 0 - нет)");
        f = in.nextInt();
        i = 0;
        while(f == 1 && i < maxNumOfMeds){
            lek[i] = new Lek();
            lek[i].read();
            i++;
            System.out.println("Добавить лекарство ? (1 - да, 0 - нет)");
            f = in.nextInt();
        }
        numOfMeds = i;
        System.out.println("Добавить производителя ?(1 - да, 0 - нет)");
        f = in.nextInt();
        i = 0;
        while(f == 1){
            proz[i] = new Proizvoditel();
            proz[i].read(1);
            i++;
            System.out.println("Добавить ещё производителя ? (1 - да, 0 - нет)");
            f = in.nextInt();
        }
        numOfProzs = i;
        System.out.println("Добавить страну ?(1 - да, 0 - нет)");
        f = in.nextInt();
        i = 0;
        while(f == 1){
            naz_world[i] = new Naz_world();
            naz_world[i].read(1);
            i++;
            System.out.println("Добавить ещё страну ?(1 - да, 0 - нет)");
            f = in.nextInt();
        }
        numOfWorlds = i;
    }
    Apteka(String name1, String num1, int numOfMeds1, Lek lek1[], int numOfProzs1, Proizvoditel[] proz1, int numOfWorlds1, Naz_world[] naz_world1){
        if(numOfMeds1 <= maxNumOfMeds){
            name = name1;
            num = num1;
            numOfMeds = numOfMeds1;
            for(numOfMeds1 = 0; numOfMeds1 < numOfMeds; numOfMeds1++){
                lek[numOfMeds1] = lek1[numOfMeds1];
            }
            numOfProzs = numOfProzs1;
            for(numOfProzs1 = 0; numOfProzs1 < numOfProzs; numOfProzs1++){
                proz[numOfProzs1] = proz1[numOfProzs1];
            }
            numOfWorlds = numOfWorlds1;
            for(numOfWorlds1 = 0; numOfWorlds1 < numOfWordls; numOfWorlds1++){
                naz_world[numOfWorlds1] = naz_world1[numOfWorlds1];
            }
        }
    }
    Apteka(String name1){
        name = name1;
        num = "-";
        numOfMeds = 0;
        numOfProzs = 0;
        numOfWorlds = 0;
    }
    Apteka(){
        name = "-";
        num = "-";
        numOfMedss = 0;
        numOfProzs = 0;
        numOfWorlds = 0;
    }
    void display(){
        int i;
        System.out.println("Название аптеки: " + name);
        System.out.println("Номер аптеки: " + num);
        System.out.println("Колличество лекарств: " + numOfMeds);
        System.out.println("Колличество мест для лекарств: " + maxNumOfMeds);
        for(i = 0;i < numOfMeds; i++){
            System.out.println("Лекарство: " + (i+1));
            lek[i].display();
        }
        for (i = 0; i < numOfProzs; i++)
        {
            System.out.println("Производитель: " + (i + 1));
            proz[i].display();
        }
        for (i = 0; i < numOfWorlds; i++)
        {
            System.out.println("Страны: " + (i + 1));
			naz_world[i].display();
        }
    }
    void add(){
        String encoding = System.getProperty("console.encoding", "cp866");
        Scanner in = new Scanner(System.in, encoding);
        int f;
        System.out.println("Добавить лекарство - 1, производителя - 2, страну - 3");
        f = in.nextInt();
        if(f == 1){
            lek[numOfMeds] = new Lek();
            lek[numOfMeds].read();
            numOfMeds++;
        }
        else if(f == 2){
            proz[numOfProzs] = new Proizvoditel();
            proz[numOfProzs].read(1);
            numOfProzs++;
        }
        else {
            naz_world[numOfWorlds] = new Naz_world();
            naz_world[numOfWorlds].read(1);
            numOfWorlds++;
        }
    }
    void priceChange(String mass, double price){
        int i, f;
        i = f = 0;
        while(i < numOfMeds){
            if(mass.equals(lek[i].getMass())){
                lek[i].setPrice(price);
                i = numOfMeds;
                f = 1;
            }
            i++;
        }
        if(f == 0){
            i = 0;
            while(i < numOfProzs){
                if(mass.equals(proz[i].getMass())){
                    proz[i].setPrice(price);
                    i = numOfProzs;
                    f = 1;
                }
                i++;
            }
        }
        if(f == 0){
            i = 0;
            while(i < numOfWorlds){
                if(mass.equals(naz_world[i].getMass())){
                    naz_world[i].setPrice(price);
                    i = numOfWorlds;
                    f = 1;
                }
                i++;
            }
        }
    }
    void displayName(){
        System.out.println("Аптека: " + name);
    }
    boolean aptekacmp(String name1){
       if(name.equals(name1)){
           return true;
       }
       else {
           return false;
       }
    }
    void getNumber(Number k){
        k.number = numOfMeds;
    }
    static void maxNumOfMedsChange(int newMax){
        maxNumOfMeds = newMax;
    }
    void add(String mass)
    {
        int i, f;
        i = f = 0;
        while (i < numOfProzs)
        {
            if (mass.equals(proz[i].getMass()))
            {
                proz[i].add();
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
                if (mass.equals(naz_world[i].getMass()))
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
