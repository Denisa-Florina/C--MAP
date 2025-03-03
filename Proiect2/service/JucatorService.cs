using lab12.domain;
using lab12.repository;

namespace lab12.service;

public class JucatorService
{
    private Repository<int, Jucator> jucatorRepository;

    public JucatorService(Repository<int, Jucator> jucatorRepository)
    {
        this.jucatorRepository = jucatorRepository;
    }

    public IEnumerable<Jucator> GetJucators()
    {
        return jucatorRepository.FindAll().ToList();
    }

    public IEnumerable<Jucator> JucatoriDupaEchipa(Echipa echipa)
    {
        List<Jucator> jucators = this.GetJucators().ToList();
        var result = jucators.Where(j => j.Echipa.Nume.Equals(echipa.Nume));
        List<Jucator> jucatorList = result.ToList();
        if (jucatorList.Count == 0)
            throw new Exception("Echipa nu are jucatori");
        return jucatorList;
    }

    public Jucator JucatorDupaID(int ID)
    {
        return this.jucatorRepository.FindOne(ID);
    }
}