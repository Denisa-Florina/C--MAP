using lab11.container;
using lab11.strategy;

namespace lab11.factory;

public interface Factory
{
    public Container createContainer(ContainerStrategy strategy);
}