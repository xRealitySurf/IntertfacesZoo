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

        }
        public static void MakeHunt(IWildAnimal wildAnimal) { wildAnimal.Hunt(); } //метод, который инициализирует метод охоты у дикого животного
    }

    //В C# запрещено наследование более чем от 1 класса, поэтому существуют интерфейсы, который представляет из себя блок абстрактных членов
    //(в основном методов). Вызывается как interface IНазваниеИнтерфейса {//абстрактные члены} (модификато доступа не нужен, всегда public)

    abstract class Animal
    {
        public abstract void Speak();
        public abstract void Move();
    }
    interface IDomesticAnimal //интерфейст, характеризующий поведение домашних животных
    {
        void Eat();
        void GetLazy();
    }
    interface IWildAnimal
    {
        void Hunt();
        void Fight();
    }
    class Cat : Animal, IDomesticAnimal
    {
        public override void Speak() => Console.WriteLine("Мяу!");
        public override void Move() => Console.WriteLine("Перебирает лапками");
        public void Eat() => Console.WriteLine("Ест сухарики"); //не нужно добавлять override для абстрактно-виртуальных методов интерфейса
        public void GetLazy() => Console.WriteLine("Кот опять уснул");
    }
    class Dog : Animal, IDomesticAnimal
    {
        public override void Speak() => Console.WriteLine("Гав!");
        public override void Move() => Console.WriteLine("Пес-бегун побежал");
        public void Eat() => Console.WriteLine("Ест кость");
        public void GetLazy() => Console.WriteLine("Пес спит");
    }
    class Fox : Animal, IWildAnimal
    {
        public override void Speak() => Console.WriteLine("Фыр фыр фыр!");
        public override void Move() => Console.WriteLine("Лисица-куница побежала");
        public void Hunt() => Console.WriteLine("Выслеживает колобка или что-нибудь покрупнее");
        public void Fight() => Console.WriteLine("Это моя норка-шконка!");
    }
    class Bear : Animal, IWildAnimal
    {
        public override void Speak() => Console.WriteLine("Рык на всю округу!");
        public override void Move() => Console.WriteLine("Косолапый прибыл");
        public void Hunt() => Console.WriteLine("Щас бы медка");
        public void Fight() => Console.WriteLine("Тебе с левой лапы, с правой или с обеих?");
    }
    //создадим свой зоопарк, в котором будут только дикие животные, на данный момент имеются только лисы и медведи, но если появятся другие дикие звери
    //нужно будет редактировать зоопарк, чтобы такого не делать, существует инверсия зависимостей, которая позволяет устранить связи между подсистемами
    //путем установления их общей зависимости от абстракции - интерфейса:
  class Zoo
    {
        private IWildAnimal[] _wildAnimals; //создали массив, в который мы будем заносить всех диких животных
        public Zoo(Animal[] wildAnimals)//конструктор класса
        {
            IWildAnimal[] newAnimals = new IWildAnimal[wildAnimals.Length]; //создаем новый массив типа IWildAnimal
            int i = 0;
            foreach (Animal animal in wildAnimals) //перебираем переданный массив животных, если среди них есть дикие, то они заносятся в созданный массив newAnimals
                if (animal is IWildAnimal)
            {
                newAnimals[i++]=(IWildAnimal)animal;  
            }
            _wildAnimals = new IWildAnimal[i]; //инициализируем наш массив, но уже задаем его размер
            for (int j = 0; j < i; j++)
                _wildAnimals[j] = newAnimals[j];//заполняем массив 
        }
        public void FeedAllAnimals()
        {
            foreach (IWildAnimal animal in _wildAnimals)
                animal.Hunt();
        }
    }
    
}
