using Microsoft.EntityFrameworkCore;
using ShopApi.Interface;
using ShopApi.Models;
namespace ShopApi.Repository;

public class UserRepository(ShopContext context) : ICRUD<User, string>
{
    public async Task Add(User Source) => await context.Users.AddAsync(Source);

    public void Edit(User Source)
    {
        context.Users.Attach(Source);
        context.Users.Entry(Source).State = EntityState.Modified;
    }

    public void Erase(User Source)
    {
        context.Users.Attach(Source);
        context.Users.Entry(Source).State = EntityState.Deleted;
    }

    public async Task<IEnumerable<User>> Get(string Key) => await context.Users.Where(b => String.Compare(b.Phone, Key) >= 0).Select(b => b).ToListAsync();

    public async Task Save()
    {
        await context.SaveChangesAsync();
    }

    public Task<User> Track(User Source)
    {
        throw new NotImplementedException();
    }
}