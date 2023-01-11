interface IAnimalBasicData
{
    float Weight { get; set; }
    void MakeSound();
    void Eat(string meal);
}

interface IAnimalData
{
    int Height { get; set; }
    Guid ShowMyID();
    void Move();
}

abstract class Animal
{
    protected Animal()
    {
        id = Guid.NewGuid();
    }

    protected Guid id;
    protected float weight;
    protected int height;

    public abstract string Family
    {
        get;
    }

    public abstract void WhatAnimalIsThis(object o);
}

class Cat : Animal, IAnimalData, IAnimalBasicData
{
    public float Weight
    {
        get
        {
            return weight;
        }
        set
        {
            if (value < 5 && value > 0)
            {
                weight = value;
            }
            else
            {
                throw new Exception("Impossible weight");
            }
        }
    }

    public int Height
    {
        get { return height; }
        set
        {
            if (value < 25 && value > 0)
            {
                height = value;
            }
            else
            {
                throw new Exception("impossible height");
            }
        }
    }

    public override string Family { get { return "cats"; } }

    public override void WhatAnimalIsThis(object o)
    {
        string tmp = Convert.ToString(o.GetType().Name);
        if (tmp == "Cat")
        {
            Console.WriteLine("this is a cat");
        }
        else
        {
            Console.WriteLine("this is NOT a cat");
        }
    }

    public Guid ShowMyID()
    {
        return id;
    }

    public void Eat(string meal)
    {
        switch (meal)
        {
            case "Cat meal": { Console.WriteLine("Сat is full and happy!"); break; }
            case "Fish meal": { Console.WriteLine("Cat doesn't eat this."); break; }
            case "Bird meal": { Console.WriteLine("Cat doesn't eat this."); break; }

            default: { throw new Exception("Incorrect type"); }
        }
    }

    public void MakeSound()
    {
        Console.WriteLine("meow");
    }

    public void Move()
    {
        Console.WriteLine("Walking");
    }

    public override string ToString()
    {
        return $"\nWeight: {weight}\nHeight: {height}\nFamily: {Family}";
    }
}

class Fish : Animal, IAnimalData, IAnimalBasicData
{
    public float Weight
    {
        get
        {
            return weight;
        }
        set
        {
            if (value < 6.6 && value > 0)
            {
                weight = value;
            }
            else
            {
                throw new Exception("Impossible weight");
            }
        }
    }

    public int Height
    {
        get { return height; }
        set
        {
            if (value < 40 && value > 0)
            {
                height = value;
            }
            else
            {
                throw new Exception("impossible height");
            }
        }
    }

    public override string Family { get { return "fishes"; } }

    public override void WhatAnimalIsThis(object o)
    {
        string tmp = Convert.ToString(o.GetType().Name);
        if (tmp == "Fish")
        {
            Console.WriteLine("this is a fish");
        }
        else
        {
            Console.WriteLine("this is NOT a fish");
        }
    }

    public Guid ShowMyID()
    {
        return id;
    }

    public void Eat(string meal)
    {
        switch (meal)
        {
            case "Cat meal": { Console.WriteLine("Fish doesn't eat this."); break; }
            case "Fish meal": { Console.WriteLine("Fish is full and happy!"); break; }
            case "Bird meal": { Console.WriteLine("Fish doesn't eat this."); break; }

            default: { throw new Exception("Incorrect type"); }
        }
    }

    public void MakeSound()
    {
        Console.WriteLine("*fish sounds*");
    }

    public void Move()
    {
        Console.WriteLine("Swimming");
    }

    public override string ToString()
    {
        return $"\nWeight: {weight}\nHeight: {height}\nFamily: {Family}";
    }
}

class Bird : Animal, IAnimalData, IAnimalBasicData
{
    public float Weight
    {
        get
        {
            return weight;
        }
        set
        {
            if (value < 0.25 && value > 0)
            {
                weight = value;
            }
            else
            {
                throw new Exception("Impossible weight");
            }
        }
    }

    public int Height
    {
        get { return height; }
        set
        {
            if (value < 14 && value > 0)
            {
                height = value;
            }
            else
            {
                throw new Exception("impossible height");
            }
        }
    }

    public override string Family { get { return "birds"; } }

    public override void WhatAnimalIsThis(object o)
    {
        string tmp = Convert.ToString(o.GetType().Name);
        if (tmp == "Bird")
        {
            Console.WriteLine("this is a bird");
        }
        else
        {
            Console.WriteLine("this is NOT a bird");
        }
    }

    public Guid ShowMyID()
    {
        return id;
    }

    public void Eat(string meal)
    {
        switch (meal)
        {
            case "Cat meal": { Console.WriteLine("Bird doesn't eat this."); break; }
            case "Fish meal": { Console.WriteLine("Bird doesn't eat this."); break; }
            case "Bird meal": { Console.WriteLine("Bird is full and happy!"); break; }

            default: { throw new Exception("Incorrect type"); }
        }
    }

    public void MakeSound()
    {
        Console.WriteLine("*birds sounds*");
    }

    public void Move()
    {
        Console.WriteLine("Flying");
    }

    public override string ToString()
    {
        return $"\nWeight: {weight}\nHeight: {height}\nFamily: {Family}";
    }
}

class Program
{
    static void FirstMethod(IAnimalBasicData animalBasicData)
    {
        Console.Write("Enter weight: ");
        while (true)
        {
            try
            {
                animalBasicData.Weight = float.Parse(Console.ReadLine());
                break;
            }
            catch (Exception) { Console.Write("Wrong data! Please try again: "); }
        }

        Console.WriteLine($"Weight: {animalBasicData.Weight}");
        animalBasicData.MakeSound();
        Console.Write("Enter meal name: ");
        while (true)
        {
            try
            {
                string tmp = Console.ReadLine();
                animalBasicData.Eat(tmp);
                break;
            }
            catch (Exception) { Console.WriteLine("Wrong data! Please try again: "); }
        }

        Console.WriteLine();
    }

    static void SecondMethod(IAnimalData animalData)
    {
        Console.Write("Enter weight: ");
        while (true)
        {
            try
            {
                animalData.Height = int.Parse(Console.ReadLine());
                break;
            }
            catch (Exception) { Console.Write("Wrong data! Please try again: "); }
        }

        animalData.ShowMyID();
        animalData.Move();
    }

    static void ThirdMethod(Animal animal)
    {
        animal.WhatAnimalIsThis(animal);
        Console.WriteLine(animal.Family);
    }

    static void Main(string[] args)
    {
        Cat cat = new Cat();
        Fish fish = new Fish();
        Bird bird = new Bird();

        Console.WriteLine("First method start");
        Console.ForegroundColor = ConsoleColor.Green;
        FirstMethod(cat);
        Console.ForegroundColor = ConsoleColor.Red;
        FirstMethod(fish);
        Console.ForegroundColor = ConsoleColor.Blue;
        FirstMethod(bird);


        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("\nSecond method start");
        Console.ForegroundColor = ConsoleColor.Green;
        SecondMethod(cat);
        Console.ForegroundColor = ConsoleColor.Red;
        SecondMethod(fish);
        Console.ForegroundColor = ConsoleColor.Blue;
        SecondMethod(bird);


        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("\nThird method start");
        Console.ForegroundColor = ConsoleColor.Green;
        ThirdMethod(cat);
        Console.ForegroundColor = ConsoleColor.Red;
        ThirdMethod(fish);
        Console.ForegroundColor = ConsoleColor.Blue;
        ThirdMethod(bird);


        Console.ForegroundColor = ConsoleColor.White;
    }
}


