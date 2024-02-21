namespace ShopApi.Interface;


public interface IService<T, Tkey>
{
    Task<IEnumerable<T>> Get(Tkey source);
    Task<T> Add(T source);
    Task<T> Update(T source);
    Task<T> Delete(T source);


}

