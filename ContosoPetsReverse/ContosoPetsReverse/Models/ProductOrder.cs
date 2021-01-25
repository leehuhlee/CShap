using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ContosoPetsReverse.Models
{
    [Index(nameof(OrderId), Name = "IX_ProductOrders_OrderId")]
    [Index(nameof(ProductId), Name = "IX_ProductOrders_ProductId")]
    public partial class ProductOrder
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("ProductOrders")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductOrders")]
        public virtual Product Product { get; set; }
    }
}
