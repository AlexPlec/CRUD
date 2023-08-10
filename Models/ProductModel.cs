using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models;

public class ProductModel
{
    public int Id { get; set; }
    [Required]
    public int Code { get; set; }

    [Required]
    [StringLength(100)]
   [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    public string Title { get; set; }
    [Required]
    public decimal Price { get; set; }
}
