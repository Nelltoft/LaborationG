using Blazored.LocalStorage;
using LaborationG.Classes;
using LaborationG.Interfaces;


namespace LaborationG.Data;

public class Data : IData
{
    public List<IProduct> _products = new();
    public List<IProduct> _productsInCart = new();
    public List<IProduct> _boughtProducts = new();
    private readonly ILocalStorageService _localStorage;
    public Customer Customer { get; set; } = new();
    List<IProduct> IData.Products => _products;
    List<IProduct> IData.ProductsInCart => _productsInCart;
    List<IProduct> IData.BoughtProducts => _boughtProducts;

    public Data(ILocalStorageService localStorage)
    {
        Seed();
        _localStorage = localStorage;
    } 


    public async Task AddProductToCart(IProduct product)
    {
        _productsInCart.Add(product);
        await _localStorage.SetItemAsync<List<IProduct>>("IProduct", _productsInCart);
    }

    public async Task RemoveProductFromCart(int id)
    {
        var product = _productsInCart.Where(p => p.Id == id).FirstOrDefault();

        if (product is not null)
            _productsInCart.Remove(product);

        await _localStorage.SetItemAsync<List<IProduct>>("IProduct", _productsInCart);
    }
    
    public async Task GetLocalStorage()
    {
        var products = await _localStorage.GetItemAsync<List<Book>>("IProduct");
        if (products?.Count > _productsInCart.Count)
        {
            foreach (var item in products) 
            {
                _productsInCart.Add(item);
            }
        }
    }
    public void AddBoughtProducts(List<IProduct> products)
    {
        _boughtProducts.AddRange(products);
    }
    public void Seed()
    {
        _products.Add(
        new Book()
        {
            Id = 1,
            Name = "Dune",
            Description = "Set on the desert planet Arrakis, Dune is the story of the boy Paul Atreides, heir to a noble family tasked with ruling an inhospitable world where the only thing of value is the “spice” melange, a drug capable of extending life and enhancing consciousness.",
            Image = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1555447414i/44767458.jpg",
            Price = 15.99
        });
        _products.Add(
        new Book()
        {
            Id = 2,
            Name = "Foundation",
            Description = "The Galactic Empire has prospered for twelve thousand years. Nobody suspects that the heart of the thriving Empire is rotten, until psychohistorian Hari Seldon uses his new science to foresee its terrible fate.",
            Image = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1520376086i/39037823.jpg",
            Price = 9.99
        });
        _products.Add(
        new Book()
        {
            Id = 3,
            Name = "The Wheel of Time, The Eye of the World",
            Description = "When their village is attacked by terrifying creatures, Rand al'Thor and his friends are forced to flee for their lives. An ancient evil is stirring, and its servants are scouring the land for the Dragon Reborn - the prophesised hero who can deliver the world from darkness.",
            Image = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1627667880i/58663212.jpg",
            Price = 13.49
        });
        _products.Add(
        new Book()
        {
            Id = 4,
            Name = "Skyward",
            Description = "Defeated, crushed, and driven almost to extinction, the remnants of the human race are trapped on a planet that is constantly attacked by mysterious alien starfighters. Spensa, a teenage girl living among them, longs to be a pilot. When she discovers the wreckage of an ancient ship, she realizes this dream might be possible—assuming she can repair the ship, navigate flight school, and (perhaps most importantly) persuade the strange machine to help her. Because this ship, uniquely, appears to have a soul.",
            Image = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1531845177i/36642458.jpg",
            Price = 10
        });
        _products.Add(
        new Book()
        {
            Id = 5,
            Name = "Children of Time",
            Description = "The last remnants of the human race left a dying Earth, desperate to find a new home among the stars. Following in the footsteps of their ancestors, they discover the greatest treasure of the past age—a world terraformed and prepared for human life.",
            Image = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1431014197i/25499718.jpg",
            Price = 8.09
        });
    }
}
