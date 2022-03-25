var g = new Giraffe();
var d = new Dog();
var a = new Animal();
FeedMammals(g);
FeedMammals(a);
// Output:
// Eating.
// Animal is not a Mammal

SuperNova sn = new SuperNova();
TestForMammals(g);
TestForMammals(d);
TestForMammals(sn);
TestForCastingTypes(g);
TestForAnimalListCasting(g);
TestForAnimalListCasting(d);

//will throw exception
TestNotAMammal(sn);

static void FeedMammals(Animal a)
{
    if (a is Mammal m)
    {
        m.Eat();
    }
    else
    {
        // variable 'm' is not in scope here, and can't be used.
        Console.WriteLine($"{a.GetType().Name} is not a Mammal");
    }
}

static void TestForMammals(object o)
{
    // You also can use the as operator and test for null
    // before referencing the variable.
    var m = o as Mammal;
    if (m != null)
    {
        Console.WriteLine(m.ToString());
    }
    else
    {
        Console.WriteLine($"{o.GetType().Name} is not a Mammal");
    }
}

static void TestForCastingTypes(object o)
{
    var a = (Animal)o;
    
}
static void TestForAnimalListCasting(object o)
{
    var listOfAnimal = new List<object>();
    for (int i = 0; i < 5; i++)
    {
        listOfAnimal.Add(new Giraffe());
        Console.WriteLine(listOfAnimal + " " + i);
    }
    //cast the list of an animal to a generic animal
    var animalList = listOfAnimal.Cast<Animal>().ToList();

    for (int i = 0; i < animalList.Count; i++)
    {
        if (animalList is List<Animal>)
        {
            Console.WriteLine("GiraffeList is not an animal list");
        }
    }
}

static void TestNotAMammal(object o)
{
    var fakeAnimal = o as Mammal;

    Console.WriteLine(fakeAnimal.ToString());
}
// Output:
// I am an animal.
// SuperNova is not a Mammal

public class Animal
{
    public void Eat() { Console.WriteLine("Eating."); }
    public override string ToString()
    {
        return "I am an animal.";
    }
}

public class Mammal : Animal { }
public class Giraffe : Mammal { }
public class Dog : Animal { }

public class SuperNova { }