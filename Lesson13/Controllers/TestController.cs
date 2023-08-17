using Lesson13.Data;
using Lesson13.Data.Ado;
using Lesson13.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace Lesson13.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
	private readonly IDataContext _dataContext;

	public TestController() {
        var connectionStringBuilder = new MySqlConnectionStringBuilder {
            Server = "localhost",
            Database = "shop",
            UserID = "root",
            Password = "root123"
        };

        //_dataContext = new RawSqlDataContext("Datasource=localhost;Database=shop;User=root;Password=root123;");
        _dataContext = new AdoDataContext(connectionStringBuilder.ConnectionString);
	}

    [HttpGet("customers")]
    public IList<Customer?> GetCustomers([FromQuery] int? id = null) {
        return _dataContext.SelectCustomers(id);
    }

    [HttpGet("orders")]
    public IList<Order?> GetOrders([FromQuery] string? count = null) {
        IDictionary<string, object>? args = null;

        if (!string.IsNullOrEmpty(count)) {
            args = new Dictionary<string, object>() {
                { "count", count }
            };
        }

        return _dataContext.SelectOrders(args);
    }

	[HttpGet("products")]
	public IList<Product?> GetProducts() {
		return _dataContext.SelectProducts();
	}

    [HttpPost("products")]
    public int InsertProducts([FromBody] Product product) {
        return _dataContext.InsertProduct(product);
    }

    [HttpPut("products/{id}")]
    public int UpdateProducts([FromRoute] int id, [FromQuery] string description) {
        var args = new Dictionary<string, object>() {
            { "description", description }
        };
        return _dataContext.UpdateProduct(id, args);
    }

    [HttpDelete("products/{id}")]
    public int DeleteProducts([FromRoute] int id) {
        return _dataContext.DeleteProduct(id);
    }
}
