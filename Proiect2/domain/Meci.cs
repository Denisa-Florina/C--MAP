namespace lab12.domain;

public class Meci : Entity<int>
{
    public Echipa FirstEchipa { get; set; }
    public Echipa SecondEchipa { get; set; }
    public DateTime Date { get; set; }
    
    public Meci() { }

    public Meci(int id, Echipa first, Echipa second)
    {
        this.Id = id;
        this.FirstEchipa = first;
        this.SecondEchipa = second;
    }

    public override string ToString()
    {
        return $"Meci: {this.FirstEchipa}, {this.SecondEchipa}, {this.Date}";
    }

}