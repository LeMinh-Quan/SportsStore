using System.Linq;
using System.Collections.Generic;
using SportsStore.Domain;

namespace SportsStore.WebUI.Models;

// 1. Đổi tên class và thuộc tính thành dạng ViếtHoaChữCáiĐầu (PascalCase)
public class CartLine
{
    public int CartLineId { get; set; }
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
}

public class Cart
{
    public List<CartLine> Lines { get; set; } = new List<CartLine>();

    public virtual void AddItem(Product product, int quantity)
    {
        CartLine? line = Lines.FirstOrDefault(p => p.Product.ProductID == product.ProductID);
        if (line == null)
        {
            Lines.Add(new CartLine { Product = product, Quantity = quantity });
        }
        else
        {
            line.Quantity += quantity;
        }
    }

    public virtual void RemoveLine(Product product)
    {
        Lines.RemoveAll(l => l.Product.ProductID == product.ProductID);
    }

    public virtual decimal ComputeTotalValue() =>
        Lines.Sum(e => e.Product.Price * e.Quantity);

    public virtual void Clear() => Lines.Clear();
}