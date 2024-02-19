using LaborationG.Classes;
using LaborationG.Interfaces;

namespace LaborationG.Data;

public interface IData
{
    Customer Customer { get; }
    List<IProduct> Products { get; }
    List<IProduct> ProductsInCart { get; }
    List<IProduct> BoughtProducts { get; }
    void Seed();
    Task AddProductToCart(IProduct product);
    Task RemoveProductFromCart(int id);
    Task GetLocalStorage();
    void AddBoughtProducts(List<IProduct> products);
}
