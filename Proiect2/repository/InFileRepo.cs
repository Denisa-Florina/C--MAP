using lab12.domain;

namespace lab12.repository;

public delegate E CreateEntity<E>(string line);

public class InFileRepo<ID,E> : InMemoryRepo<ID,E> where E:Entity<ID>
{
    private string filename;
    private CreateEntity<E> createEntity;
    public InFileRepo(string filename, CreateEntity<E> createEntity)
    {
        this.filename = filename;
        this.createEntity = createEntity;
        if (this.createEntity != null)
            this.LoadFromFile();
    }

    private void LoadFromFile()
    {
        List<E> list = DataReader.ReadData(this.filename, this.createEntity);
        list.ForEach(x=>entities[x.Id] = x);
    }
}