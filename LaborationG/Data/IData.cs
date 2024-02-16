using LaborationG.Interfaces;

namespace LaborationG.Data;

public interface IData
{
    List<IProduct> Products { get; }
    List<IProduct> ProductsInCart { get; }
    void Seed();
    Task AddProductToCart(IProduct product);
    Task RemoveProductFromCart(int id);
    Task GetLocalStorage();
}
