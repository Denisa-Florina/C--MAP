using lab12.domain;

namespace lab12.repository;

public class ElevRepo : InFileRepo<int, Elev>
{
    public ElevRepo(string filename) : base(filename, EntityToFile.CreeazaElev)
    {
    }
}