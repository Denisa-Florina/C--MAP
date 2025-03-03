namespace lab11.runner;

public class DelayTaskRunner(TaskRunner taskRunner) : AbstractTaskRunner(taskRunner)
{
    public override void ExecuteAllTasks()
    {
        while (hasTask())
        {
            base.executeOneTask();
            try
            {
                Thread.Sleep(3000);
            }
            catch (ThreadAbortException)
            {

            }
        }
    }
}