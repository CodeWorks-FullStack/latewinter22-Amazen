using System;

namespace amaZen.Interfaces
{
  public interface IRepoItem<T>
  {
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}