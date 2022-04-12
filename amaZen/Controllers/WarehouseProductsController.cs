using amaZen.Models;
using amaZen.Services;
using Microsoft.AspNetCore.Mvc;

namespace amaZen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WarehouseProductsController : ControllerBase
  {
    private readonly WarehouseProductsService _wps;

    public WarehouseProductsController(WarehouseProductsService wps)
    {
      _wps = wps;
    }

    //NOTE Create takes in the data from the many to many, but returns the product view model, not always what you want but if your create on the front end needs to be responsive.
    [HttpPost]
    public ActionResult<ProductViewModel> Create([FromBody] WarehouseProduct warehouseProductData)
    {
      try
      {
        ProductViewModel product = _wps.Create(warehouseProductData);
        return Ok(product);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}