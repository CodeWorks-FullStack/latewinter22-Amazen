using System.Collections.Generic;
using amaZen.Models;
using amaZen.Repositories;

namespace amaZen.Services
{
  public class WarehousesService
  {
    private readonly WarehousesRepository _repo;

    public WarehousesService(WarehousesRepository repo)
    {
      _repo = repo;
    }

    internal List<Warehouse> GetAll()
    {
      return _repo.GetAll();
    }

    internal Warehouse GetById(int id)
    {
      return _repo.GetById(id);
    }


  }
}