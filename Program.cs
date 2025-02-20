using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intertfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // рассмотрим интерфейсные переменные (интерфесного типа)
            try
            {
                IWildAnimal fox = new Fox(); //объяевление переменной, соответсвующая интерфейсу. Как и с абстрактным классом нельзя создать экземпляр интерфейса
                fox.Hunt();
                fox.Fight();
            }
            catch { Console.WriteLine("Несоответствие типа"); }
            try
            {
                IWildAnimal cat = (IWildAnimal)new Cat(); //явное приведение типов, что позволяет положить экземпляр типа кота в переменную типа дикого животного
                cat.Hunt();
                cat.Fight(); //типы не соответствуют, так как кот не наследует интерфейс дикого животного
            }
            catch { Console.WriteLine("Несоответствие типа\n"); }

            //можно сортировать объекты по их интерфейсам:
            Animal[] animals = { new Cat(), new Dog(), new Fox(), new Bear(), new Cat(), new Fox()};
            foreach (Animal animal in animals)
            {
                if (animal is IWildAnimal) //если животное относится к указаному типу, то
                    MakeHunt((IWildAnimal)animal);
            }
            
            Console.WriteLine("\n");
            Zoo zoo = new Zoo(animals);
            zoo.FeedAllAnimals();
            Console.ReadLine();


        }
        public static void MakeHunt(IWildAnimal wildAnimal) { wildAnimal.Hunt(); } //метод, который инициализирует метод охоты у дикого животного
    }

    

  
  
  

}
