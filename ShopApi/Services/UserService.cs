
using ShopApi.DTOs.InvoiceDTOs;
using ShopApi.DTOs.UserDTOs;
using ShopApi.Interface;
using ShopApi.Mappers;
using ShopApi.Models;


namespace ShopApi.Services;

public class UserService(ICRUD<User, string> repository) : IService<UserDTO,  string>
{
    private readonly EntityToUserDTO _ToDTO = new();
    private readonly UserDTOToEntity _ToEntity = new();


    public async Task<UserDTO> Add(UserDTO user)
    {
        var User = _ToEntity.Mapp(user);
        await repository.Add(User);
        await repository.Save();
        var response = _ToDTO.Mapp(User);

        return response;
    }

    public async Task<UserDTO> Update(UserDTO user)
    {
        var Target = await repository.Track(_ToEntity.Mapp(user));
        if (Target != null)
        {
            Target = _ToEntity.Mapp(user);
            repository.Edit(Target);
            await repository.Save();
            var response = _ToDTO.Mapp(Target);
            return response;
        }
        return null!;

    }

    public async Task<UserDTO> Delete(UserDTO user)
    {
        var Target = await repository.Track(_ToEntity.Mapp(user));
        if (Target != null)
        {
            repository.Erase(Target);
            await repository.Save();
            var response = _ToDTO.Mapp(Target);
            return response;
        }
        return null!;
    }

    public async Task<IEnumerable<UserDTO>> Get(string Name)
    {

        var users = await repository.Get(Name);
        var response = users.Select(b => _ToDTO.Mapp(b));

        return response;
    }

}