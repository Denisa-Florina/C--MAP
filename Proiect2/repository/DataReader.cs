namespace lab12.repository;

public class DataReader
{
    public static List<T>ReadData<T>(string filename, CreateEntity<T> createEntity)
    {
        List<T> list = new List<T>();
        using(StreamReader reader = new StreamReader(filename))
        {
            string s;
            while((s = reader.ReadLine()) != null)
            {
                T entity = createEntity(s);
                list.Add(entity);
            }
        }
        return list;
    }
}