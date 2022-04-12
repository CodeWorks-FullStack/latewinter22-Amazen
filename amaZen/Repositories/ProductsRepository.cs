using System.Collections.Generic;
using System.Data;
using System.Linq;
using amaZen.Interfaces;
using amaZen.Models;
using Dapper;

namespace amaZen.Repositories
{
  public class ProductsRepository : IRepo<Product, int>
  {
    private readonly IDbConnection _db;

    public ProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Product Create(Product data)
    {
      throw new System.NotImplementedException();
    }

    public List<Product> GetAll()
    {
      string sql = "SELECT * FROM products";
      return _db.Query<Product>(sql).ToList();
    }

    internal List<ProductViewModel> GetProductsByWareHouseId(int warehouseId)
    {
      string sql = @"
      SELECT
        p.*,
        wp.*,
        w.*
      FROM warehouseProducts wp
      JOIN products p ON p.id = wp.productId
      JOIN warehouses w ON w.id = wp.warehouseId
      WHERE wp.warehouseId = @warehouseId;
      ";
      List<ProductViewModel> products = _db.Query<ProductViewModel, WarehouseProduct, Warehouse, ProductViewModel>(sql, (p, wp, w) =>
      {
        // NOTE assemble the view model
        p.WarehouseProductId = wp.Id;
        p.location = w.Location;
        return p;
      }, new { warehouseId }).ToList();
      return products;
    }

    public ProductViewModel GetViewModelById(int id)
    {
      string sql = "SELECT * FROM products WHERE id = @id;";
      return _db.Query<ProductViewModel>(sql, new { id }).FirstOrDefault();
    }

    public Product Update(Product data, int id, string userId)
    {
      throw new System.NotImplementedException();
    }

    Product IRepo<Product, int>.GetViewModelById(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}