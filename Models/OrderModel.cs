using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ClientModel? Client { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Product Name")]
        public ProductModel? Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Status Status { get; set; }
    }

    public enum Status
    {
        Created,
        Paid,
        Delivered
    }
}
