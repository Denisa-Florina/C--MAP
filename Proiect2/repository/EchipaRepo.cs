using lab12.domain;

namespace lab12.repository;

public class EchipaRepo : InFileRepo<int, Echipa>
{
    public EchipaRepo(string filename) : base(filename, EntityToFile.CreeazaEchipa)
    {
    }
}