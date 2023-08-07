using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models;

public class ProductModel
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string? Title { get; set; }
    public decimal Price { get; set; }
}
