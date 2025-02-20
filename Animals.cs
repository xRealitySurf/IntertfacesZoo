using System;

abstract class Animal
{
    public abstract void Speak();
    public abstract void Move();
}

//В C# запрещено наследование более чем от 1 класса, поэтому существуют интерфейсы, который представляет из себя блок абстрактных членов
//(в основном методов). Вызывается как interface IНазваниеИнтерфейса {//абстрактные члены} (модификато доступа не нужен, всегда public)

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
        public void Fight() => Console.WriteLine("Тебе с левой лапы, с правой или с обеих?");logic here
		
}

