using Task = lab11.domain.Task;

namespace lab11.container;

public class StackContainer : AbstractContainer
{
    public override Task remove()
    {
        Task task = tasks[tasks.Count - 1];
        tasks.RemoveAt(tasks.Count - 1);
        return task;
    }
}