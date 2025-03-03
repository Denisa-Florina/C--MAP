using Task = lab11.domain.Task;

namespace lab11.runner;

public abstract class AbstractTaskRunner : TaskRunner
{
    private readonly TaskRunner taskRunner;

    public AbstractTaskRunner(TaskRunner taskRunners)
    {
        this.taskRunner = taskRunners;
    }
    
    public virtual void executeOneTask()
    {
        this.taskRunner.executeOneTask();
    }

    public virtual void ExecuteAllTasks()
    {
        while (this.hasTask())
        {
            this.taskRunner.executeOneTask();
        }
    }

    public virtual void addTask(Task task)
    {
        this.taskRunner.addTask(task);
    }

    public virtual bool hasTask()
    {
        return this.taskRunner.hasTask();
    }
}