using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models;

public class ClientModel
{
    public int Id { get; set; }
    public string? Name {get; set;}
    public string? Email {get; set;}
    public DateTime Birthdate { get; set;}
    public Gender Gender { get; set;}
    public ICollection<OrderModel>? Orders { get; set; }
}

public enum Gender
{
    Male,
    Female
}