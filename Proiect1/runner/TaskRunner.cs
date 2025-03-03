using Task = lab11.domain.Task;

namespace lab11.runner;

public interface TaskRunner
{
    void executeOneTask();
    void ExecuteAllTasks();
    void addTask(Task task);
    bool hasTask();
}