namespace ASP6.Models
{
    public record class Product(string Name, List<string> Ingredients, int Diameter, double Price);
}
