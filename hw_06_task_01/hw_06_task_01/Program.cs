using System.Collections;

public class Lake : IEnumerable<int>
{
    private readonly List<int> stones;

    public Lake(IEnumerable<int> stones)
    {
        
        this.stones = stones.OrderBy(x => x).ToList();
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
    static void Main(string[] args)
    {
        var stones = new Lake(new int[] { 1,2,3,4,5,6,7,8 });
        foreach (var stone in stones)
        {
            Console.Write(stone + " ");
        }
    }
}
