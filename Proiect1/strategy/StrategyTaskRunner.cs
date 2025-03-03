using lab11.container;
using lab11.factory;
using lab11.runner;
using Task = lab11.domain.Task;

namespace lab11.strategy;

public class StrategyTaskRunner : TaskRunner
{
    private Container container;

    public StrategyTaskRunner(ContainerStrategy containerStrategy)
    {
        this.container = TaskContainerFactory.getInstance().createContainer(containerStrategy);
    }


    public void executeOneTask()
    {
        this.container.remove().execute();
    }

    public void ExecuteAllTasks()
    {
        while (hasTask())
        {
            executeOneTask();
        }
    }

    public void addTask(Task task)
    {
        container.add(task);
    }

    public bool hasTask()
    {
        return !container.isEmpty();
    }
}