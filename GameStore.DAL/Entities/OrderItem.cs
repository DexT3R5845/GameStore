﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities
{
    public class OrderItem : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }

        public int? GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Discount will be like 0.1, 0.2, 0.25
        public decimal Discount { get; set; }

        public int? OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        public int? NorthwindOrderId { get; set; }
        public int? NorthwindProductId { get; set; }
    }
}