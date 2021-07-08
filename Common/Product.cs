using Common;
using System;


public class Product
{
    public long Id { get; set; }
    public long? OwnerId { get; set; }
    public long? UserId { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public string Picture1 { get; set; }
    public string Picture2 { get; set; }
    public string Picture3 { get; set; }
    public ProductStatus State { get; set; }
    public DateTime? BasketExpirationDate { get; set; }
    public virtual User Owner { get; set; }
    public virtual User User { get; set; }
    public Product()
    {
        Date = DateTime.Now;
        State = ProductStatus.ForSale;
    }
}
