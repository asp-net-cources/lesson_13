namespace Lesson13.Models;

public class Food : Product
{
    public new ProductType ProductType { get; } = ProductType.Food;
}
