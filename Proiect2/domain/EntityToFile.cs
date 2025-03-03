using Microsoft.VisualBasic.FileIO;

namespace lab12.domain;

public class EntityToFile
{
    public static Elev CreeazaElev(string line)
    {
        string[] lines = line.Split(',');
        Elev elev = new Elev()
        {
            Id = int.Parse(lines[0]),
            Nume = lines[1],
            Scoala = lines[2]
        };
        return elev;
    }

    public static Echipa CreeazaEchipa(string line)
    {
        string[] linie = line.Split(';');
        Echipa e = new Echipa()
        {
            Id = int.Parse(linie[0]),
            Nume = linie[1]
        };
        return e;
    }

    public static Jucator CreezaJucator(string line)
    {
        string[] linie = line.Split(';');
        Jucator j = new Jucator()
        {
            Id = int.Parse(linie[0]),
            Nume = linie[1],
            Scoala = linie[2],
            Echipa = new Echipa(int.Parse(linie[3]), linie[4])
        };
        return j;
    }

    public static JucatorActiv CreezaJucatorActiv(string line)
    {
        string[] linie = line.Split(';');
        TipJucator Tip;
        if (linie[3] == "Rezerva")
            Tip = TipJucator.Rezerva;
        else
            Tip = TipJucator.Participant;
        JucatorActiv ja = new JucatorActiv()
        {
            Id = new Tuple<int, int>(int.Parse(linie[0]), int.Parse(linie[1])),
            IdJucator = int.Parse(linie[0]),
            IdMeci = int.Parse(linie[1]),
            NrPuncteInscrise = int.Parse(linie[2]),
            Tip = Tip
        };
        return ja;
    }

    public static Meci CreezaMeci(string line)
    {
        string[] linie = line.Split(';');
        Echipa firstTeam = new Echipa()
        {
            Id = int.Parse(linie[1]),
            Nume = linie[2]
        };
        Echipa secondTeam = new Echipa()
        {
            Id = int.Parse(linie[3]),
            Nume = linie[4]
        };
        Meci m = new Meci()
        {
            Id = int.Parse(linie[0]),
            FirstEchipa = firstTeam,
            SecondEchipa = secondTeam,
            Date = DateTime.ParseExact(linie[5], @"d/M/yyyy", null)
        };
        return m;
    }

}