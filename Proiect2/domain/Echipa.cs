namespace lab12.domain;

public class Echipa : Entity<int>
{
    public string Nume { get; set; }

    public Echipa(int id, string nume)
    {
        this.Id = id;
        this.Nume = nume;
    }

    public Echipa() { }

    public override string ToString()
    {
        return $"Echipa: {this.Id}, {this.Nume}";
    }
}