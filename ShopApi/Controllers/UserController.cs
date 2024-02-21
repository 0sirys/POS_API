using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShopApi.DTOs.UserDTOs;
using ShopApi.Interface;
namespace ShopApi.Controllers;

[Route("api/Users")]
[ApiController]
public class UserController(IService<UserDTO, string> Service, IValidator<UserDTO> validator) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUser([FromHeader] string Name = null!)
    {
        if (Name.IsNullOrEmpty())
        {
            var response = await Service.Get(Name);

            return response.IsNullOrEmpty() ? NotFound(Name) : Ok(response);
        }
        return BadRequest();


    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> Add([FromBody] UserDTO user)
    {
        var validation = validator.Validate(user);
        if (validation.IsValid)
        {
            var response = await Service.Add(user);
            return response == null ? NotFound() : Ok(response);
        }
        return BadRequest(validation.Errors);


    }
    [HttpPut]
    public async Task<ActionResult<UserDTO>> Update([FromBody] UserDTO user)
    {
        var validation = validator.Validate(user);
        if (validation.IsValid)
        {
            var response = await Service.Update(user);
            return response == null ? NotFound() : Ok(response);
        }
        return BadRequest(validation.Errors);

    }

    [HttpDelete]
    public async Task<ActionResult<UserDTO>> Delete([FromBody] UserDTO user)
    {
        var validation = validator.Validate(user);
        if (validation.IsValid)
        {
            var response = await Service.Update(user);
            return response == null ? NotFound() : Ok(response);
        }

        return BadRequest(validation.Errors);
    }



}