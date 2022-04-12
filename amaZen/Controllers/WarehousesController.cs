using System.Collections.Generic;
using amazen.Services;
using amaZen.Models;
using amaZen.Services;
using Microsoft.AspNetCore.Mvc;

namespace amaZen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WarehousesController : ControllerBase
  {
    private readonly WarehousesService _ws;
    private readonly ProductsService _pService;

    public WarehousesController(WarehousesService ws, ProductsService pService)
    {
      _ws = ws;
      _pService = pService;
    }

    [HttpGet]
    public ActionResult<List<Warehouse>> GetAll()
    {
      try
      {
        return Ok(_ws.GetAll());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/products")]
    public ActionResult<List<ProductViewModel>> GetProductsByWarehouseId(int id)
    {
      try
      {
        List<ProductViewModel> products = _pService.GetProductsByWarehouseId(id);
        return Ok(products);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}