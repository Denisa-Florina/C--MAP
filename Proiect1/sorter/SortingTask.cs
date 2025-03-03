using lab11.strategy;
using domain_Task = lab11.domain.Task;

namespace lab11.sorter;

public class SortingTask : domain_Task
{
    private int[] numbers;
    private AbstractSorter sorter;
    private SortStrategy sortStrategy;

    public SortingTask(string taskID, string description, int[] numbers, SortStrategy sortStrategy):base(taskID, description)
    {
        this.numbers = numbers;
        this.sortStrategy = sortStrategy;
        if (sortStrategy == SortStrategy.BUBBLESORT)
        {
            sorter = new BubbleSort();
        }

        if (sortStrategy == SortStrategy.QUICKSORT)
        {   
            sorter = new QuickSort();
        }

    }

    public override void execute()
    {
        sorter.sort(numbers);
        foreach (var number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}