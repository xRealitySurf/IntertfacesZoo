using System;


/// создадим свой зоопарк, в котором будут только дикие животные, на данный момент имеются только лисы и медведи, но если появятся другие дикие звери
/// нужно будет редактировать зоопарк, чтобы такого не делать, существует инверсия зависимостей, которая позволяет устранить связи между подсистемами
/// путем установления их общей зависимости от абстракции - интерфейса:
 
public class Zoo
{
    private IWildAnimal[] _wildAnimals; //создали массив, в который мы будем заносить всех диких животных
    public Zoo(Animal[] wildAnimals)//конструктор класса
    {
        IWildAnimal[] newAnimals = new IWildAnimal[wildAnimals.Length]; //создаем новый массив типа IWildAnimal
        int i = 0;
        foreach (Animal animal in wildAnimals) //перебираем переданный массив животных, если среди них есть дикие, то они заносятся в созданный массив newAnimals
            if (animal is IWildAnimal)
            {
                newAnimals[i++] = (IWildAnimal)animal;
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