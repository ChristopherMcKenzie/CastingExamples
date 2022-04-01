namespace CastingExample;

using Xunit;
public class CastingTests
{
    private static Mammal _mammal= new Mammal();
    private Animal _animal = new Animal();
    private Giraffe _giraffe = new Giraffe();
    private Dog _dog = new Dog();
    private SuperNova _superNova = new SuperNova();
    
    [Fact]
    public void TestMammalCasting()
    {
        Assert.True(_mammal is Animal);
    }

    [Fact]
    public void TestAnimalCasting()
    {
        Assert.False(_animal is Mammal);
    }

    [Fact]
    public void TestGiraffeCasting()
    {
        Assert.True(_giraffe is Mammal);
    }
    [Fact]
    public void TestDogCasting()
    {
        Assert.True(_dog is Animal);
        Assert.False(_dog is Mammal);
    }
    [Fact]
    public void TestSuperNovaCasting()
    {
        Assert.False(_superNova is Animal);
    }

    [Fact]
    public void TestListOfGiraffeCasting()
    {
        var listOfAnimal = new List<object>();
        for (int i = 0; i < 5; i++)
        {
            listOfAnimal.Add(new Giraffe());
        }
        //cast the list of an animal to a generic animal
        var animalList = listOfAnimal.Cast<Animal>().ToList();
        
        Assert.True(animalList is List<Animal>);
        
    }
    
    //Using the as operator

    [Fact]
    public void TestGiraffeAsOperator()
    {
        var g = _giraffe as Mammal;
        Assert.NotNull(g);
        //Can't convert g from mammal to animal
    }

    [Fact]
    public void TestDogAsOperator()
    {
        var g = _dog as Animal;
        Assert.NotNull(g);
    }

    [Fact]
    public void TestTypeCastingGirafee()
    {
        Animal a = new Giraffe();

        Giraffe g = (Giraffe) a;
        
        Assert.Equal(typeof(Giraffe), g.GetType());
        
    }

    [Fact]
    public void TestListCasting2()
    {
        List<Animal> listOfAnimals = new List<Animal>();
        listOfAnimals.Add(_dog);
        listOfAnimals.Add(_giraffe);

        //can't convert
        //var a = listOfAnimals as Animal[];

        Animal[] a = new Animal[] { _dog, _giraffe };
        
        //Can't convert
        //var newa = a as List<Animal>

        Assert.Equal(2, a.ToList().Count);
        Assert.Equal(2, a.ToArray().Length);

    }

    [Fact]
    public void TestThrowsException()
    {
        List<Mammal> listMammal = new List<Mammal>();

        listMammal.ToArray();
    }
}
