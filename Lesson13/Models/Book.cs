namespace Lesson13.Models;

public class Book : Product
{
    public new ProductType ProductType { get; } = ProductType.Book;
}
