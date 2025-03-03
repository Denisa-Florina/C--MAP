using lab11.container;
using lab11.strategy;

namespace lab11.factory;

public class TaskContainerFactory : Factory
{
    private TaskContainerFactory()
    {
        
    }

    private static TaskContainerFactory taskContainerFactory = new TaskContainerFactory();
    
    public static TaskContainerFactory getInstance()
    {
        return taskContainerFactory;
    }
    
    public Container createContainer(ContainerStrategy strategy)
    {
        switch (strategy)
        {
            case ContainerStrategy.LIFO:
                return new StackContainer();
            case ContainerStrategy.FIFO:
                return new QueueContainer();
            default:
                return null;
        }
    }
}