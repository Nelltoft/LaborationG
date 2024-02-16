namespace LaborationG.Interfaces;

public interface IProduct
{
    public int Id { get; }
    public string? Name { get; }
    public string? Description { get; }
    public string? Image { get; }
    public double Price { get; }
}
