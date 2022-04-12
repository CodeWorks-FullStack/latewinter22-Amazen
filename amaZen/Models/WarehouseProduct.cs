namespace amaZen.Models
{
  public class WarehouseProduct : Virtual<int>
  {
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }
  }


}