namespace lab11.sorter;

public class BubbleSort : AbstractSorter
{
    public override void sort(int[] numbers)
    {
        int nr = numbers.Length;
        for (int i = 0; i < nr; i++)
        {
            for (int j = 0; j < nr - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
                }
            }
        }
    }
}