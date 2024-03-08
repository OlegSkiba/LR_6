using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication2.Models;

[ApiController]
[Route("[controller]")]
public class PizzaOrderController : ControllerBase
{
    private List<Product> _products = new List<Product>();

    [HttpPost("register")]
    public IActionResult Register(User user)
    {
        if (user.Age > 16)
        {
            return Ok("How many units of product do you want to order?");
        }
        else
        {
            return BadRequest("You must be at least 16 years old to order.");
        }
    }

    [HttpPost("order")]
    public IActionResult Order(List<Product> products)
    {
        _products = products;
        return Ok("Please fill out the quantity for each product.");
    }

    [HttpPost("confirm")]
    public IActionResult Confirm(List<int> quantities)
    {
        // Combine products with quantities
        List<string> orderDetails = new List<string>();
        for (int i = 0; i < _products.Count; i++)
        {
            orderDetails.Add($"{_products[i].Name}: {quantities[i]} units");
        }
        return Ok($"Order confirmed:\n{string.Join("\n", orderDetails)}");
    }
}
