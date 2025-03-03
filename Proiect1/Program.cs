using lab11.domain;
using lab11.runner;
using lab11.sorter;
using lab11.strategy;
using lab11.tests;

namespace lab11;

class Program
{
    
    static void Main(string[] args)
    {
        Console.WriteLine("Test task(vector initial:1, 4, 3) - BUBBLESORT");
        SortingTask task1 = new SortingTask("1", "Hello", new int[]{1, 4, 3}, SortStrategy.BUBBLESORT);
        task1.execute();
        Console.WriteLine("Testele pentru SortingTask cu BUBBLESORT s-au terminat \n\n");

        Console.WriteLine("Test task(vector initial:4, 3, 2, 1) - QUICKSORT");
        SortingTask task2 = new SortingTask("2", "Hello", new int[]{4, 3, 2, 1}, SortStrategy.QUICKSORT);
        task2.execute();
        Console.WriteLine("Testele pentru SortingTask cu QUICKSORT s-au terminat \n\n");

        int[] n1 = {4, 3, 2, 1};
        BubbleSort bubbleSort = new BubbleSort();
        bubbleSort.sort(n1);
        foreach (int j in n1) {
            Console.Write(j + " ");
        }
        Console.WriteLine("\n");


        int[] n2 = {4, 3, 2, 1};
        QuickSort quickSort = new QuickSort();
        quickSort.sort(n2);
        foreach (int j in n2) {
            Console.Write(j + " ");
        }
        Console.WriteLine("\n");
        
        
        
        TestStrategyTaskRunner.strategyTest(ContainerStrategy.LIFO);
        Console.WriteLine("TestStrategyTask(LIFO) was finished");
        
        TestMessageTask.TestMessageTasks();
        Console.WriteLine("TestMessage was finished");
        
        TestPrinterTaskRunner printerTest1 = new TestPrinterTaskRunner();
        printerTest1.printerTest(ContainerStrategy.FIFO);
        Console.WriteLine("TestPrinter(FIFO) was finished");
        
        TestPrinterTaskRunner printerTest = new TestPrinterTaskRunner();
        printerTest.printerTest(ContainerStrategy.LIFO);
        Console.WriteLine("TestPrinter(LIFO) was finished");
        
        TestDelayTaskRunner.printerTest(ContainerStrategy.FIFO);
        Console.WriteLine("TestDelay(FIFO) was finished");

    }
}