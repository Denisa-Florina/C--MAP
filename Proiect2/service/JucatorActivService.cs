using lab12.domain;
using lab12.repository;

namespace lab12.service;

public class JucatorActivService
{
    private Repository<Tuple<int, int>, JucatorActiv> JucatoriActivi;
    private Repository<int, Jucator> Jucatori;
    public JucatorActivService(Repository<Tuple<int, int>, JucatorActiv> jucatoriActivi, Repository<int, Jucator> jucatori)
    {
        this.JucatoriActivi = jucatoriActivi;
        this.Jucatori = jucatori;
    }

    public IEnumerable<JucatorActiv> GetJucatoriActivi()
    {
        return this.JucatoriActivi.FindAll().ToList();
    }

    public IEnumerable<JucatorActiv> GetJucatoriActiviDinMeci(Meci meci)
    {
        List<JucatorActiv> jucatoriActivi = this.GetJucatoriActivi().ToList();
        var result = jucatoriActivi.Where(a => a.IdMeci.Equals(meci.Id));
        return result.ToList();
    }

    public IEnumerable<JucatorActiv> GetJucatoriActiviDinMeciSiEchipa(Meci meci, Echipa echipa)
    {
        if (!meci.FirstEchipa.Nume.Equals(echipa.Nume) && !meci.SecondEchipa.Nume.Equals(echipa.Nume))
        {
            throw new Exception($"Echipa {echipa.Nume} nu joaca in acest meci");
        }
        List<JucatorActiv> jucatoriActivi = this.GetJucatoriActivi().ToList();
        List<Jucator> jucatori = Jucatori.FindAll().ToList();
        var result = from jucator in jucatori
            join jucatorActiv in jucatoriActivi on jucator.Id equals jucatorActiv.Id.Item1
            where jucatorActiv.IdMeci.Equals(meci.Id) && jucator.Echipa.Nume.Equals(echipa.Nume)
            select jucatorActiv;
        return result.ToList();
    }
    
    

}