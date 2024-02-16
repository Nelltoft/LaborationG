using LaborationG.Interfaces;

namespace LaborationG.Classes;

public class Book : IProduct
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public double Price { get; set; }
}
