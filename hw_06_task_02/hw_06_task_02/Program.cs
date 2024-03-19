public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

public class NameLengthComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Name.Length.CompareTo(y.Name.Length);

        if (result == 0)
        {
            result = string.Compare(x.Name.First().ToString(), y.Name.First().ToString(), true); 
        }

        return result;
    }
}

public class AgeComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return x.Age.CompareTo(y.Age);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person person1 = new Person("Bob", 25);
        Person person2 = new Person("ali", 31);
        Person person3 = new Person("Charlie", 20);

        NameLengthComparator nameLengthComparator = new NameLengthComparator();
        AgeComparator ageComparator = new AgeComparator();

        Console.WriteLine("Sorting by name len and fst letter:");
        List<Person> people = new List<Person> { person1, person2, person3 };
        people.Sort(nameLengthComparator);
        foreach (var person in people)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }

        Console.WriteLine();

        Console.WriteLine("Sorting by age:");
        people.Sort(ageComparator);
        foreach (var person in people)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
    }
}
