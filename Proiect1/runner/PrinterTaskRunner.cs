namespace lab11.runner;

public class PrinterTaskRunner : AbstractTaskRunner
{
    
    public PrinterTaskRunner(TaskRunner runner) : base(runner) { }


    public override void ExecuteAllTasks()
    {
        while (hasTask())
        {
            Console.WriteLine($"Task was executed at{DateTime.Now}");
            base.executeOneTask();
        }
    }
}