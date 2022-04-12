using amazen.Services;
using amaZen.Models;
using amaZen.Repositories;

namespace amaZen.Services
{
  public class WarehouseProductsService
  {
    private readonly WarehouseProductsRepository _repo;

    private readonly ProductsService _pService;
    private readonly WarehousesService _wService;

    public WarehouseProductsService(WarehouseProductsRepository repo, ProductsService pService, WarehousesService wService)
    {
      _repo = repo;
      _pService = pService;
      _wService = wService;
    }

    // NOTE making the switch from warehouse product to productviewmodel happens here in the service
    internal ProductViewModel Create(WarehouseProduct warehouseProductData)
    {
      WarehouseProduct warehouseProduct = _repo.Create(warehouseProductData);
      // NOTE making the switch (ProductViewModel) casts it from product to ProductViewModel
      ProductViewModel product = _pService.GetViewModelById(warehouseProduct.ProductId);
      Warehouse warehouse = _wService.GetById(warehouseProduct.WarehouseId);
      // NOTE add view model properties
      product.WarehouseProductId = warehouseProduct.Id;
      product.location = warehouse.Location;
      return product;

    }
  }
}