using Task = lab11.domain.Task;

namespace lab11.container;

public class QueueContainer : AbstractContainer
{
    public override Task remove()
    {
        Task task = tasks[0];
        tasks.RemoveAt(0);
        return task;
    }
}