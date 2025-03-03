using lab12.domain;

namespace lab12.repository;

public class JucatorActivRepo : InFileRepo<Tuple<int, int>,JucatorActiv>
{
    public JucatorActivRepo(string filename) : base(filename, EntityToFile.CreezaJucatorActiv) { }
}