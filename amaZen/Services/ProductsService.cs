using System.Collections.Generic;
using amaZen.Models;
using amaZen.Repositories;

namespace amazen.Services
{
  public class ProductsService
  {
    private readonly ProductsRepository _repo;

    public ProductsService(ProductsRepository repo)
    {
      _repo = repo;
    }

    internal List<Product> GetAll()
    {
      return _repo.GetAll();
    }

    internal ProductViewModel GetViewModelById(int id)
    {
      return _repo.GetViewModelById(id);
    }

    internal List<ProductViewModel> GetProductsByWarehouseId(int warehouseId)
    {
      return _repo.GetProductsByWareHouseId(warehouseId);
    }
  }
}