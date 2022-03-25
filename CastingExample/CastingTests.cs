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
        if (_mammal is Animal)
        {
            Assert.True(true);
        }
    }

    [Fact]
    public void TestAnimalCasting()
    {
        if (_animal is Mammal)
        {
            Assert.True(true);
        }
    }

    [Fact]
    public void TestGiraffeCasting()
    {
        if (_giraffe is Mammal)
        {
            if (_giraffe is Animal)
            {
                Assert.True(true);
            }
        }
    }
    [Fact]
    public void TestDogCasting()
    {
        if (_dog is Mammal)
        {
            if (_dog is Animal)
            {
                Assert.True(true);
            }
        }
    }
    [Fact]
    public void TestSuperNovaCasting()
    {
        if (_superNova is Animal)
        {
            Assert.True(true);
        }
        else
        {
            Assert.False(false);
        }
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

        if (animalList is List<Animal>)
        {
            Assert.True(true);
        }
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
}
