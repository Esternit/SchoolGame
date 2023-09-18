using System;
using System.IO;
using System.Threading;

namespace PROJECTDUELS
{
    class Card
    {
        private string name;
        private int type; //1- человек 0- аммуниция
        private int hp;
        private int defence;
        private int attack;
        private static Random rnd = new Random();

        private Card()
        {
            StreamReader read = new StreamReader("Characters.txt");
            int take;
            string line = "";
            line = read.ReadLine();
            take = rnd.Next(0,13);
            for (int i = 0; i < take-1; i++)
            {
                line = read.ReadLine();
            }
            FromLine(out name, out hp, out defence, out attack, line);
        }
        private Card(string name,int type,int hp, int defence, int attack)
        {
            this.name = name;
            this.type = type;
            this.hp = hp;
            this.defence = defence;
            this.attack = attack;
        }
        
        public static Card CreateCard(int type)
        {
            Card objcard;
            if (type == 1)
            {
                return objcard = new Card();
            }
            else
            {
                StreamReader read = new StreamReader("Equipment.txt");
                int chance = rnd.Next(1, 101);//шанс
                int take;// выбирает строку
                
                string line="";
                line = read.ReadLine();
                if (chance <= 65)
                {
                    take = rnd.Next(0, 7);
                }
                else if(chance>65 && chance <= 87)
                {
                    take = rnd.Next(7, 13); 
                }
                else
                {
                    take = rnd.Next(13, 15);
                }
                for (int i = 0; i < take-1; i++)
                {
                    line = read.ReadLine();
                }
                string namel;
                int hpl;
                int defencel;
                int attackl;
                FromLine(out namel, out hpl, out defencel, out attackl, line);
                read.Close();
                return objcard = new Card(namel, 0, hpl, defencel, attackl);
            }
        }
        private static void FromLine(out string namel, out int hpl, out int defencel, out int attackl,string line)
        {
            namel = line.Substring(0, line.Length - (line.Length - line.IndexOf(';')));
            line = line.Substring(line.IndexOf(';') + 1, line.Length - 1 - line.IndexOf(';'));
            hpl = int.Parse(line.Substring(0, line.Length - (line.Length - line.IndexOf(';'))));
            line = line.Substring(line.IndexOf(';') + 1, line.Length - 1 - line.IndexOf(';'));
            defencel = int.Parse(line.Substring(0, line.Length - (line.Length - line.IndexOf(';'))));
            line = line.Substring(line.IndexOf(';') + 1, line.Length - 1 - line.IndexOf(';'));
            attackl = int.Parse(line.Substring(0, line.Length - (line.Length - line.IndexOf(';'))));
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public int Defence
        {
            get { return defence; }
            set { defence = value; }
        }
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        public int Type
        {
            get { return type; }
        }

    }
    class Fighter
    {
        private string name;
        private int hp;
        private int defence;
        private int attack;

        public Fighter()
        {
            name = "Week Guy (For Losers)";
            hp = 23;
            defence = 12;
            attack = 4;
        }
        public Fighter(Card card1,Card card2,Card card3,Card card4)
        {
            this.name = card1.Name;
            this.hp = card1.Hp+card2.Hp+card3.Hp+card4.Hp;
            this.defence = card1.Defence + card2.Defence + card3.Defence + card4.Defence;
            this.attack = card1.Attack + card2.Attack + card3.Attack + card4.Attack;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public int Defence
        {
            get { return defence; }
            set { defence = value; }
        }
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
    }

    class Computer
    {
        private static Random rnd = new Random();

        public static Fighter ComputerFighter()
        {
            int amounthp = 0;
            int amountatt = 0;
            Console.WriteLine("Computer`s options:");
            Card obj1 = Card.CreateCard(1);
            Card obj2 = Card.CreateCard(1);
            Card obj3 = Card.CreateCard(1);
            Card obj4 = Card.CreateCard(1);
            Console.WriteLine("1) Character: {0} HP: {1} Defence: {2} Attack: {3}", obj1.Name, obj1.Hp, obj1.Defence, obj1.Attack);
            Console.WriteLine("2) Character: {0} HP: {1} Defence: {2} Attack: {3}", obj2.Name, obj2.Hp, obj2.Defence, obj2.Attack);
            Console.WriteLine("3) Character: {0} HP: {1} Defence: {2} Attack: {3}", obj3.Name, obj3.Hp, obj3.Defence, obj3.Attack);
            Console.WriteLine("4) Character: {0} HP: {1} Defence: {2} Attack: {3}", obj4.Name, obj4.Hp, obj4.Defence, obj4.Attack);
            Card[] lsthp = new Card[] { obj1, obj2, obj3, obj4 };
            Card chosencharacter = ChooseTheBestCard(lsthp,ref amounthp,ref amountatt);
            Console.WriteLine("Computer`s optioons for abilities:");
            Card objcard1 = Card.CreateCard(0);
            Card objcard2 = Card.CreateCard(0);
            Card objcard3 = Card.CreateCard(0);
            Card objcard4 = Card.CreateCard(0);
            Card objcard5 = Card.CreateCard(0);
            Card[] lst = new Card[] { objcard1, objcard2, objcard3, objcard4, objcard5 };
            Console.WriteLine("1) Ammunition: {0} HP: {1} Defence: {2} Attack: {3}", objcard1.Name, objcard1.Hp, objcard1.Defence, objcard1.Attack);
            Console.WriteLine("2) Ammunition: {0} HP: {1} Defence: {2} Attack: {3}", objcard2.Name, objcard2.Hp, objcard2.Defence, objcard2.Attack);
            Console.WriteLine("3) Ammunition: {0} HP: {1} Defence: {2} Attack: {3}", objcard3.Name, objcard3.Hp, objcard3.Defence, objcard3.Attack);
            Console.WriteLine("4) Ammunition: {0} HP: {1} Defence: {2} Attack: {3}", objcard4.Name, objcard4.Hp, objcard4.Defence, objcard4.Attack);
            Console.WriteLine("5) Ammunition: {0} HP: {1} Defence: {2} Attack: {3}", objcard5.Name, objcard5.Hp, objcard5.Defence, objcard5.Attack);

            Card chosenammu1 = ChooseTheBestCard(lst, ref amounthp, ref amountatt);
            Card chosenammu2 = ChooseTheBestCard(lst, ref amounthp, ref amountatt);
            Card chosenammu3 = ChooseTheBestCard(lst, ref amounthp, ref amountatt);
            return new Fighter(chosencharacter, chosenammu1, chosenammu2, chosenammu3);
        }
        private static Card ChooseTheBestCard(Card[] lst, ref int amounthp,ref int amountattack)
        {
            
            Card besthp = lst[0];
            
            Card bestattack = lst[0];
            for (int i = 1; i < lst.Length; i++)
            {
                if (besthp.Defence+besthp.Hp < lst[i].Defence + lst[i].Hp)
                {
                    besthp = lst[i];
                }
                if (bestattack.Attack < lst[i].Attack)
                {
                    bestattack = lst[i];
                }
            }
            if (amountattack >= amounthp)
            {
                amounthp++;
                return besthp;
            }
            else 
            {
                amountattack++;
                return bestattack;
            }
            
        }
    }
    class Game
    {
        private static Random rnd = new Random();
        public static Fighter StarterCreation()
        {
            
            Console.WriteLine("First, select a character");
            Card obj1 = Card.CreateCard(1);
            Card obj2 = Card.CreateCard(1);
            Card obj3 = Card.CreateCard(1);
            Card obj4 = Card.CreateCard(1);
            Console.WriteLine("Your options: ");
            Console.WriteLine("1) Character: {0} HP: {1} Defence: {2} Attack: {3}", obj1.Name, obj1.Hp, obj1.Defence, obj1.Attack);
            Console.WriteLine("2) Character: {0} HP: {1} Defence: {2} Attack: {3}", obj2.Name, obj2.Hp, obj2.Defence, obj2.Attack);
            Console.WriteLine("3) Character: {0} HP: {1} Defence: {2} Attack: {3}", obj3.Name, obj3.Hp, obj3.Defence, obj3.Attack);
            Console.WriteLine("4) Character: {0} HP: {1} Defence: {2} Attack: {3}", obj4.Name, obj4.Hp, obj4.Defence, obj4.Attack);

            int input;
            try
            {
                Console.Write("Enter the number of the desired character: ");
                input = int.Parse(Console.ReadLine());
                if (input <= 0 || input > 4) throw new Exception("You entered a value that is outside the scope of the one suggested.");
            }
            catch(Exception error)
            {
                Console.WriteLine("Error, {0} Let's assume, that you have chosen number 1)",error.Message);
                input = 1;
            }

            Card objcharacter;
            switch (input)
            {
                case 1:
                    objcharacter = obj1;
                    break;
                case 2:
                    objcharacter = obj2;
                    break;
                case 3:
                    objcharacter = obj3;
                    break;
                default:
                    objcharacter = obj4;
                    break;
            }
            Console.WriteLine("Next, select abilities");
            Card objcard1 = Card.CreateCard(0);
            Card objcard2 = Card.CreateCard(0);
            Card objcard3 = Card.CreateCard(0);
            Card objcard4 = Card.CreateCard(0);
            Card objcard5 = Card.CreateCard(0);
            Card[] lst = new Card[] { objcard1, objcard2, objcard3, objcard4, objcard5 };
            Console.WriteLine("Your options: ");
            Console.WriteLine("1) Ammunition: {0} HP: {1} Defence: {2} Attack: {3}", objcard1.Name, objcard1.Hp, objcard1.Defence, objcard1.Attack);
            Console.WriteLine("2) Ammunition: {0} HP: {1} Defence: {2} Attack: {3}", objcard2.Name, objcard2.Hp, objcard2.Defence, objcard2.Attack);
            Console.WriteLine("3) Ammunition: {0} HP: {1} Defence: {2} Attack: {3}", objcard3.Name, objcard3.Hp, objcard3.Defence, objcard3.Attack);
            Console.WriteLine("4) Ammunition: {0} HP: {1} Defence: {2} Attack: {3}", objcard4.Name, objcard4.Hp, objcard4.Defence, objcard4.Attack);
            Console.WriteLine("5) Ammunition: {0} HP: {1} Defence: {2} Attack: {3}", objcard5.Name, objcard5.Hp, objcard5.Defence, objcard5.Attack);
            int inputcard;
            int in1, in2, in3;
            try
            {
                Console.Write("Enter the number of the desired ammunition: ");
                inputcard = int.Parse(Console.ReadLine());
                in3 = inputcard % 10;
                inputcard = inputcard / 10;
                in2 = inputcard % 10;
                inputcard = inputcard / 10;
                in1 = inputcard % 10;
                if (in1 <= 0 || in1 > 5 || in2 <= 0 || in2 > 5 || in3 <= 0 || in3 > 5) throw new Exception("You entered a value that is outside the scope of the one suggested.");
            }
            catch (Exception error)
            {
                Console.WriteLine("Error, {0} Let's assume, that you have chosen numbers 1,2,3)", error.Message);
                in1 = 1;
                in2 = 2;
                in3 = 3;
            }
            Fighter fighter;
            return fighter = new Fighter(objcharacter, lst[in1 - 1], lst[in2 - 1], lst[in3 - 1]);
            
        }

        public static void Duel(Fighter fighter1,Fighter fighter2)
        {
            Console.WriteLine("Casting lots.....");
            int lot = rnd.Next(1, 3);
            while (true)
            {
                if (lot == 1)
                {
                    Console.WriteLine("First player attacks");
                    Console.WriteLine("Player 1 attack: {0}", fighter1.Attack);
                    Console.WriteLine("Player 2 defence+hp: {0}\n", fighter2.Defence + fighter2.Hp);
                    PodDuel(fighter1, ref fighter2);
                    lot = 2;
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("Second player attacks");
                    Console.WriteLine("Player 2 attack: {0}", fighter2.Attack);
                    Console.WriteLine("Player 1 defence+hp: {0}\n", fighter1.Defence+fighter1.Hp);
                    PodDuel(fighter2, ref fighter1);
                    lot = 1;
                    Thread.Sleep(2000);
                }
                if (fighter1.Hp == 0)
                {
                    Console.WriteLine("Second player wins");
                    break;
                }
                else if (fighter2.Hp == 0)
                {
                    Console.WriteLine("First player wins");
                    break;
                }
            }
            
        }
        private static void PodDuel(Fighter first, ref Fighter second)
        {
            int attackfirst = first.Attack;
            int defencesecond = second.Defence;
            int hpsecond = second.Hp;
            defencesecond -= attackfirst;
            attackfirst = 0;
            if (defencesecond < 0) 
            {
                attackfirst = Math.Abs(defencesecond);
                defencesecond = 0;
            }
            hpsecond -= attackfirst;
            if (hpsecond < 0)
            {
                hpsecond = 0;
            }
            second.Hp = hpsecond;
            second.Defence = defencesecond;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DUEL");
            Console.Write("Do you want to play with computer? 1-Yes 0-No:");
            int choice=0;
            try
            {
                choice = int.Parse(Console.ReadLine());
                if (choice != 1 && choice != 0) throw new Exception("Your input isn`t correct");
            }
            catch(Exception error)
            {
                Console.WriteLine("Error. {0} Let's assume, that you have chosen to play with person",error.Message);    
            }
            Fighter obj;
            Fighter obj1;
            if (choice == 0)
            {
                obj = Game.StarterCreation();
                Console.WriteLine("Name: {0} HP: {1} Defence: {2} Attack: {3}\n", obj.Name, obj.Hp, obj.Defence, obj.Attack);
                obj1 = Game.StarterCreation();
                Console.WriteLine("Name: {0} HP: {1} Defence: {2} Attack: {3}", obj1.Name, obj1.Hp, obj1.Defence, obj1.Attack);
            }
            else
            {
                obj = Game.StarterCreation();
                Console.WriteLine("Name: {0} HP: {1} Defence: {2} Attack: {3}\n", obj.Name, obj.Hp, obj.Defence, obj.Attack);
                obj1 = Computer.ComputerFighter();
                Console.WriteLine("Name: {0} HP: {1} Defence: {2} Attack: {3}", obj1.Name, obj1.Hp, obj1.Defence, obj1.Attack);
            }
            Game.Duel(obj, obj1);
            
        }
    }
}
