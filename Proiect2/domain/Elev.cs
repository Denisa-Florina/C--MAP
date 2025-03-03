namespace lab12.domain;

public class Elev : Entity<int>
{
    public string Scoala { get; set; }
    public string Nume { get; set; }
    
    public Elev(int id, string nume, string scoala)
    {
        this.Id = id;
        this.Nume = nume;
        this.Scoala = scoala;
        
    }

    public Elev() { }

    public override string ToString()
    {
        return $"Elev: {this.Id}, {this.Nume}, {this.Scoala}";
    }



}