using System.Collections;

public class Lake : IEnumerable<int>
{
    private readonly List<int> stones;

    public Lake(IEnumerable<int> stones)
    {
        
        this.stones = stones.ToList();
    }

    
    public IEnumerator<int> GetEnumerator()
    {
        foreach (var stone in stones.Where(x => x % 2 != 0))
        {
            yield return stone;
        }

        foreach (var stone in stones.Where(x => x % 2 == 0).Reverse())
        {
            yield return stone;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        var stones = new Lake(new int[] {  13 , 23 , 1 , -8 , 4 , 9 });
        foreach (var stone in stones)
        {
            Console.Write(stone + " ");
        }
    }
}
