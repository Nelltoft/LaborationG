using LaborationG.Interfaces;

namespace LaborationG.Classes;

public class Customer : IPerson
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
