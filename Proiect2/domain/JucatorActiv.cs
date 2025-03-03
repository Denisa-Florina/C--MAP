namespace lab12.domain;

public class JucatorActiv : Entity<Tuple<int, int>>
{
    public int IdJucator { get; set; }
    public int IdMeci { get; set; }
    public int NrPuncteInscrise { get; set; }
    public TipJucator Tip { get; set; }

    public JucatorActiv(int idJucator, int idMeci, int nrPuncteInscrise, TipJucator tip)
    {
        this.IdJucator = idJucator;
        this.IdMeci = idMeci;
        this.NrPuncteInscrise = nrPuncteInscrise;
        this.Tip = tip;
    }
    
    public JucatorActiv() { }

    public override string ToString()
    {
        return $"Jucator Activ {this.IdJucator}, {this.IdMeci}, {this.NrPuncteInscrise}, {this.Tip}";
    }

}