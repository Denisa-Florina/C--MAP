using lab12.domain;

namespace lab12.repository;

public class MeciRepo : InFileRepo<int, Meci>
{
    public MeciRepo(string filename) : base(filename, EntityToFile.CreezaMeci)
    {
    }
}