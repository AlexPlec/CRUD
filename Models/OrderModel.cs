using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUD.Models;

namespace CRUD.Models;

public class OrderModel
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public ClientModel? Client { get; set; }
    public int ProductId { get; set; }
    public ProductModel? Product { get; set; }
    public int Quantity { get; set; }
    public Status Status { get; set; }
}

public enum Status
{
    Created,
    Paid,
    Delivered
}
