namespace lab12.domain;

public class Jucator : Elev
{
    public Echipa Echipa { get; set; }

    public Jucator(int id, string nume, string scoala, Echipa echipa)
    {
        this.Id = id;
        this.Echipa = echipa;
        this.Nume = nume;
        this.Scoala = scoala;
    }

    public Jucator() { }

    public override string ToString()
    {
        return base.ToString() + $"Echipa: {Echipa}";
    }
}