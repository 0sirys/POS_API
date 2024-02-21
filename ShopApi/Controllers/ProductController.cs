using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShopApi.DTOs.ProductDTOs;
using ShopApi.Interface;
namespace ShopApi.Controllers;

[Route("api/Products")]
[ApiController]
public class ProductController(IService<ProductDTO, long> Service) : ControllerBase
{



   [HttpGet]
   public async Task<ActionResult<IEnumerable<ProductDTO>>> GetResult([FromHeader] long Code = 0)
   {
      if (Code > 0)
      {
         var response = await Service.Get(Code);
         return response.IsNullOrEmpty() ? NotFound(Code) : Ok(response);

      }
      return BadRequest();
   }

   [HttpPost]
   public async Task<ActionResult<ProductDTO>> Add([FromBody] ProductDTO product)
   {
      var response = await Service.Add(product);
      return response == null ? BadRequest() : Ok(response);
   }

   [HttpPut]
   public async Task<ActionResult<ProductDTO>> Update([FromBody] ProductDTO product)
   {

      var response = await Service.Update(product);
      return response == null ? BadRequest() : Ok(response);
   }

   [HttpDelete]
   public async Task<ActionResult<ProductDTO>> Delete([FromBody] ProductDTO product)
   {
      var response = await Service.Delete(product);
      return response == null ? BadRequest() : Ok(response);
   }


}