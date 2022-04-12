using System.Collections.Generic;
using amazen.Services;
using amaZen.Models;
using Microsoft.AspNetCore.Mvc;

namespace amaZen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ProductsService _ps;

    public ProductsController(ProductsService ps)
    {
      _ps = ps;
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAll()
    {
      try
      {
        return Ok(_ps.GetAll());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}