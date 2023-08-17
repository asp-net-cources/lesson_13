using System.Text.Json.Serialization;

namespace Lesson13.Models;

public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public ProductType ProductType { get; set; }
}