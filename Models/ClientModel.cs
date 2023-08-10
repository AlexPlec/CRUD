using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUDModel.Data;

namespace CRUD.Models;

public class ClientModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; }
    [Required]
    public Gender Gender { get; set; }
    public ICollection<OrderModel>? Orders { get; set; }
}

public enum Gender
{
    Male,
    Female
}
