using lab12.domain;
using lab12.repository;

namespace lab12.service;

public class EchipaService
{
    private Repository<int, Echipa> repositoryEchipa;

    public EchipaService(Repository<int, Echipa> repositoryEchipa)
    {
        this.repositoryEchipa = repositoryEchipa;
    }

    public Echipa SaveEchipa(Echipa echipa)
    {
        if (echipa.Nume == null)
            throw new Exception("Echipa nu are nume");
        return this.repositoryEchipa.Save(echipa);
    }

    public IEnumerable<Echipa> GetEchipa()
    {
        return this.repositoryEchipa.FindAll().ToList();
    }

    public Echipa EchipaDupaNume(string nume)
    {
        List<Echipa> echipe = this.GetEchipa().ToList();
        var res = echipe.Where(t => t.Nume.Equals(nume));
        Echipa echipeDupaNume = res.FirstOrDefault();
        if (echipeDupaNume == null)
        {
            throw new Exception("Nu exista o echipe cu numele" + nume);
        }
        return echipeDupaNume;
    }
}