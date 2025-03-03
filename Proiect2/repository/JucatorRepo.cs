using lab12.domain;

namespace lab12.repository;

public class JucatorRepo : InFileRepo<int, Jucator>
{
    public JucatorRepo(string filename) : base(filename, EntityToFile.CreezaJucator)
    {
    }
}