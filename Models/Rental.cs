﻿using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Thrift_Us.Models
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [Required]
        public int RentalDuration { get; set; }

        public int Count { get; set; }
        [Required]
        public RentalStatus Status { get; set; }

        public decimal TotalPrice { get; set; } 
  
        public Product Product { get; set; }
        public virtual IdentityUser ApplicationUser { get; set; }
    }

    public enum RentalStatus
    {
        Pending,
        Approved,
        Rejected
    }
}