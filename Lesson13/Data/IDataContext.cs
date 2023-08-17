using Lesson13.Models;

namespace Lesson13.Data;

public interface IDataContext
{
    public IList<Product?> SelectProducts(IDictionary<string, object>? args = null);
    public int InsertProduct(Product product);
    public int UpdateProduct(int id, IDictionary<string, object> args);
    public int DeleteProduct(int id);

    public IList<Customer?> SelectCustomers(int? id = null);
    public int InsertCustomer(Customer customer);
    public int UpdateCustomer(int id, IDictionary<string, object> args);
    public int DeleteCustomer(int id);

    public IList<Order?> SelectOrders(IDictionary<string, object>? args = null);
    public int InsertOrder(Order order);
    public int UpdateOrder(int id, IDictionary<string, object> args);
    public int DeleteOrder(int id);
}
