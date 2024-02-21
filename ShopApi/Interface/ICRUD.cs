

namespace ShopApi.Interface;

public interface ICRUD<TEntity, Tkey>
{
    Task<IEnumerable<TEntity>> Get(Tkey Key);

    Task Add(TEntity Source);
    void Edit(TEntity Source);
    void Erase(TEntity Source);
    Task Save();
    Task<TEntity> Track(TEntity Source);
}

