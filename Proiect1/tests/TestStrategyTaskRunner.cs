using lab11.domain;
using lab11.runner;
using lab11.strategy;

namespace lab11.tests;

public class TestStrategyTaskRunner
{
    public static void strategyTest(ContainerStrategy containerStrategy) {
        TaskRunner taskRunner = new StrategyTaskRunner(containerStrategy);

        MessageTask messageTask1 = new MessageTask(
            "Ana", "Feedback lab", "Ai obtinut 9", DateTime.Now, "1", "GIGI");

        MessageTask messageTask2 = new MessageTask(
            "Ana", "Feedback seminar", "Ai obtinut 10", new DateTime(2019, 10, 20, 10, 34, 0), "2", "GIGI");

        MessageTask messageTask3 = new MessageTask(
            "Ana", "Feedback curs", "Ai obtinut 3", new DateTime(2019, 10, 7, 9, 34, 0), "3", "GIGI");

        MessageTask messageTask4 = new MessageTask(
            "Ana", "Note", "Ai obtinut 9, 10, 3", new DateTime(2019, 10, 7, 9, 34, 0), "4", "GIGI");

        MessageTask messageTask5 = new MessageTask(
            "Ana", "Observatii", "Trebuie recontractat cursul", new DateTime(2019, 10, 7, 9, 34, 0), "5", "GIGI");

        MessageTask[] tasks = new MessageTask[]{messageTask1, messageTask2, messageTask3, messageTask4, messageTask5};

        foreach(MessageTask task in tasks) {
            taskRunner.addTask(task);
        }
        taskRunner.ExecuteAllTasks();
    }
}