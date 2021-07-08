using System;
using System.Collections.Generic;

public class User
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public virtual List<Product> ProductsAdded { get; set; }
    public virtual List<Product> ProductsCreated { get; set; }
}
