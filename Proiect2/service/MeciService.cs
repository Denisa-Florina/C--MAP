using lab12.domain;
using lab12.repository;

namespace lab12.service;

public class MeciService
{
    private Repository<int, Meci> Meciuri;

    public MeciService(Repository<int, Meci> meciuri)
    {
        this.Meciuri = meciuri;
    }

    public IEnumerable<Meci> GetMeciuri()
    {
        return Meciuri.FindAll().ToList();
    }

    public Meci MeciuriDupaEchipe(Echipa Echipa1, Echipa Echipa2)
    {
        List<Meci> meciuri = this.GetMeciuri().ToList();
        var result = meciuri.Where(m => m.FirstEchipa.Nume.Equals(Echipa1.Nume) &&
                                        m.SecondEchipa.Nume.Equals(Echipa2.Nume) ||
                                        m.FirstEchipa.Nume.Equals(Echipa2.Nume) &&
                                        m.SecondEchipa.Nume.Equals(Echipa1.Nume));
        Meci ras = result.FirstOrDefault();
        if (ras == null)
            throw new Exception("Can't find meciuri");
        return ras;
    }

    public IEnumerable<Meci> MeciuriDupaPerioada(DateTime date1, DateTime date2)
    {
        List<Meci> meciuri = this.GetMeciuri().ToList();
        var res = meciuri.Where(g => g.Date >= date1 && g.Date <= date2);
        return res.ToList();
    }

    public Tuple<int, int> Scor(Meci meci, List<JucatorActiv> jucatorActiv1, List<JucatorActiv> jucatorActiv2)
    {
        int firstTeamScore = (from a in jucatorActiv1 select a.NrPuncteInscrise).Sum();
        int secondTeamScore = (from a in jucatorActiv2 select a.NrPuncteInscrise).Sum();
        return new Tuple<int, int>(firstTeamScore, secondTeamScore);
    }
}