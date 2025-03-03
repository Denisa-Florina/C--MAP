using Task = lab11.domain.Task;

namespace lab11.container;

public interface Container
{
    Task remove();
    
    void add(Task task);
    
    bool isEmpty();
    
    int size();
}