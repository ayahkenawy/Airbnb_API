﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Airbnb.Data.Models
{
    [Table("ar_disputes")]
    public partial class ArDisputes
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        [StringLength(255)]
        public string UserId { get; set; }
        [Column("property_id")]
        public int? PropertyId { get; set; }
        [Column("booking_id")]
        public int? BookingId { get; set; }
        [Column("title")]
        [StringLength(255)]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("created", TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column("modified", TypeName = "datetime")]
        public DateTime? Modified { get; set; }
        [Column("status")]
        public bool? Status { get; set; }

        [ForeignKey("BookingId")]
        [InverseProperty("ArDisputes")]
        public virtual ArBookings Booking { get; set; }
        [ForeignKey("PropertyId")]
        [InverseProperty("ArDisputes")]
        public virtual ArProperties Property { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("ArDisputes")]
        public virtual ArUsers User { get; set; }
    }
}