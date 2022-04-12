using System.Collections.Generic;

namespace amaZen.Interfaces
{
  public interface IRepo<T, TId>
  {
    List<T> GetAll();
    T GetViewModelById(TId id);
    T Create(T data);
    T Update(T data, TId id, string userId);
  }
}