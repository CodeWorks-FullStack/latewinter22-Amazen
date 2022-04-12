using System.Data;
using amaZen.Models;
using Dapper;

namespace amaZen.Repositories
{
  public class WarehouseProductsRepository
  {
    private readonly IDbConnection _db;

    public WarehouseProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal WarehouseProduct Create(WarehouseProduct warehouseProductData)
    {
      string sql = @"
      INSERT INTO warehouseProducts
      (warehouseId, productId)
      VALUES
      (@WarehouseId, @ProductId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, warehouseProductData);
      warehouseProductData.Id = id;
      return warehouseProductData;
    }
  }
}