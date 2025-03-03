
namespace lab11.domain;

public class MessageTask : Task
{
    private string message;
    private string from;
    private string to;
    private DateTime dateTime;

    public MessageTask(string from, string to, string message, DateTime dateTime, string taskID, string descriere)
        : base(taskID, descriere)
    {
        this.from = from;
        this.to = to;
        this.message = message;
        this.dateTime = dateTime;
    }

    public override void execute()
    {
        Console.WriteLine($"Message from {from} to {to} at {dateTime}: {message}");
    }

    public override string ToString()
    {
        return "MessageTask{" +
               "message='" + message + '\'' +
               ", from='" + from + '\'' +
               ", to='" + to + '\'' +
               ", date=" + dateTime +
               '}';
    }
}