using lab12.domain;

namespace lab12.repository;

public interface Repository<ID, E>where E : Entity<ID>
{
    E FindOne(ID id);
    IEnumerable<E> FindAll();
    E Save(E entity);
    E Delete(ID id);
    E Update(E entity);

}