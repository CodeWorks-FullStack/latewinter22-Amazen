using System.Collections.Generic;
using System.Data;
using System.Linq;
using amaZen.Models;
using Dapper;

namespace amaZen.Repositories
{
  public class WarehousesRepository
  {
    private readonly IDbConnection _db;

    public WarehousesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Warehouse> GetAll()
    {
      string sql = @"SELECT * FROM warehouses";
      return _db.Query<Warehouse>(sql).ToList();
    }

    internal Warehouse GetById(int id)
    {
      string sql = @"SELECT * FROM warehouses WHERE id = @Id";
      return _db.Query<Warehouse>(sql, new { id }).FirstOrDefault();
    }
  }
}