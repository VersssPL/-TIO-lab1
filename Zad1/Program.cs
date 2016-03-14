using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    class Program
    {
        static void Main(string[] args)
        {

            Circus Cyrk1 = new Circus() { Name = "MojCyrk" };
            Zoo Zoo1 = new Zoo() { Name = "MojeZoo" };

            var tmp = Console.ReadKey();
            while (tmp.Key != ConsoleKey.Escape)
            {
                
                Console.WriteLine("Witaj, co chcesz zrobić?");
                Console.WriteLine(String.Format("A.Obejrzyj prezentację zwierząt w cyrku {0}.", Cyrk1.Name));
                Console.WriteLine(String.Format("B.Obejrzyj program cyrku {0}.", Cyrk1.Name));
                Console.WriteLine(String.Format("C.Posłuchaj dźwięków Zoo {0}.", Zoo1.Name));
                Console.WriteLine(String.Format("D.Wyświetl imię pierwszego znalezionego futrzaka w Zoo {0}.", Zoo1.Name));
                Console.WriteLine(String.Format("E.Wyświetl wszystkie imiona zwierząt w Cyrku {0}.", Cyrk1.Name));
                Console.WriteLine("ESC.Wyjdź");

                tmp = Console.ReadKey();
                Console.WriteLine();
                if (tmp.Key == ConsoleKey.A)
                {
                    Cyrk1.ShowPresentation();
                    Console.WriteLine();
                }
                if (tmp.Key == ConsoleKey.B)
                {
                    Console.WriteLine();
                    Console.WriteLine(Cyrk1.Show());
                }
                if (tmp.Key == ConsoleKey.C)
                {
                    Console.WriteLine();
                    Console.WriteLine(Zoo1.Sounds());
                }
                if (tmp.Key == ConsoleKey.D)
                {
                    Console.WriteLine();

                    Animal Animal = Zoo1.Animals.FirstOrDefault(x => x.HaveFur);
                    if (Animal == null)
                    {
                        Console.WriteLine("Brak futrzaków");
                    }
                    else
                    {
                        Console.WriteLine(String.Format("Pierwszy znaleziony futrzak to {0}.", Animal.Name));
                    }
                    Console.WriteLine();
                }
                else if (tmp.Key == ConsoleKey.E)
                {
                    Console.WriteLine();
                    foreach (var A in Zoo1.Animals)
                    {
                        Console.WriteLine(A.Name);
                    }
                    Console.WriteLine();
                }

            }
        }

        public class Animal
        {
            public string Name{ get; set;}
            public float Weight;
            public bool HaveFur = true;

            public virtual string Sound() { return "sound"; }
            public virtual string Trick() { return "Trick"; }
            public virtual int CountLegs() { return 4; }
        }

        public class Circus : ICircus
        {
            public string Name { get; set; }
            public List<Animal> Animals = new List<Animal>();

            public Circus()
            {
                Animals.Add(new Cat { Name = "Czarny kot" });
                Animals.Add(new Cat { Name = "Puszek" });
                Animals.Add(new Pony { Name = "Łysek" });
                Animals.Add(new Pony { Name = "Kucyk Pony" });
                Animals.Add(new Ant { Name = "Ant Man" });
                Animals.Add(new Elephant { Name = "Słoń Trąbalski" });
                Animals.Add(new Elephant { Name = "Benjamin" });
                Animals.Add(new Giraffe { Name = "Sophie" });
                Animals.Add(new Giraffe { Name = "Zyrafka" });
            }

            public string AnimalsIntroduction()
            {
                string soundConc = "";
                foreach (var A in Animals)
                {
                    soundConc += A.Sound() + "\n";
                }
                return soundConc;
            }

            public string Show()
            {
                string trickConc = "";

                foreach (var A in Animals)
                {
                    trickConc += A.Trick() + "\n"; 
                }
                return trickConc;
            }

            public int Patter(int howMuch)
            {
                int result = 0;
                foreach (var A in Animals)
                {
                    result += A.CountLegs() * howMuch;
                }
                return result;
            }

            public void ShowPresentation()
            {
                Console.WriteLine();
                Console.WriteLine("Lista zwierząt w cyrku: ");
                foreach (var A in Animals)
                {
                    Console.WriteLine(A.Name);
                }
            }
        }

        public class Zoo : IZoo
        {
            public string Name;
            public List<Animal> Animals = new List<Animal>();

            public Zoo()
            {
                Animals.Add(new Cat { Name = "Czarny kot" });
                Animals.Add(new Cat { Name = "Puszek" });
                Animals.Add(new Cat { Name = "Bonifacy" });
                Animals.Add(new Pony { Name = "Łysek" });
                Animals.Add(new Pony { Name = "Arab" });
                Animals.Add(new Pony { Name = "Kucyk Pony" });
                Animals.Add(new Ant { Name = "Ant Man" });
                Animals.Add(new Ant { Name = "Johny" });
                Animals.Add(new Elephant { Name = "Słoń Trąbalski" });
                Animals.Add(new Elephant { Name = "Benjamin" });
                Animals.Add(new Elephant { Name = "Bartek" });
                Animals.Add(new Giraffe { Name = "Sophie" });
                Animals.Add(new Giraffe { Name = "Zyrafka" });
            }

            public string Sounds()
            {
                string soundConc = "";
                foreach (var A in Animals)
                {
                    soundConc += A.Sound() + "\n";
                }

                return soundConc;
            }
        }

        public class Cat : Animal
        {
            string Color;

            public Cat()
            {
                Name = "Cat";
                HaveFur = true;
            }

            public override string Sound()
            {
                return "Miauuu";
            }
            public override string Trick()
            {
                return "Skok na cztery łapy";
            }
            public override int CountLegs()
            {
                return base.CountLegs();
            }

        }

        public class Pony : Animal
        {
            bool isMagic;

            public Pony()
            {
                Name = "Pony";
                HaveFur = true;
            }

            public override string Sound()
            {
                return "Ihhhhaaa";
            }
            public override string Trick()
            {
                return "Bieganie po tęczy";
            }
            public override int CountLegs()
            {
                return base.CountLegs();
            }

        }

        public class Ant : Animal
        {
            bool isQueen;

            public Ant()
            {
                Name = "Ant";
                HaveFur = false;
            }

            public override string Sound()
            {
                return "Bzzzzzz";
            }
            public override string Trick()
            {
                return "Noszenie przedmiotów o dużo większej wadze od nich samych";
            }
            public override int CountLegs()
            {
                return 6;
            }

        }
        
        public class Elephant : Animal
        {
            public Elephant()
            {
                Name = "Elephant";
                HaveFur = false;
            }

            public override string Sound()
            {
                return "Hreee-uh";
            }
            public override string Trick()
            {
                return "Sprzątanie po ludziach"; /* https://www.youtube.com/watch?v=NswSP0Hrh9Q */
            }
            public override int CountLegs()
            {
                return base.CountLegs();
            }

        }

        public class Giraffe : Animal
        {
            public Giraffe()
            {
                Name = "Elephant";
                HaveFur = false;
            }

            public override string Sound()
            {
                return "Bleat";
            }
            public override string Trick()
            {
                return "Teleskopowa szyja";
            }
            public override int CountLegs()
            {
                return base.CountLegs();
            }

        }

        public interface ICircus
        {
            string AnimalsIntroduction();
            string Show();
            int Patter(int howMuch);
        }

        public interface IZoo
        {
            string Sounds();
        }

    }
}
