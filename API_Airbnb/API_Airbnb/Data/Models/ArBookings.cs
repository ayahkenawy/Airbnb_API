﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Airbnb.Data.Models
{
    [Table("ar_bookings")]
    public partial class ArBookings
    {
        public ArBookings()
        {
            ArDisputes = new HashSet<ArDisputes>();
            ArPropertyReviews = new HashSet<ArPropertyReviews>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("property_id")]
        public int? PropertyId { get; set; }
        [Column("user_id")]
        [StringLength(255)]
        public string UserId { get; set; }
        [Column("check_in_date", TypeName = "datetime")]
        public DateTime? CheckInDate { get; set; }
        [Column("check_out_date", TypeName = "datetime")]
        public DateTime? CheckOutDate { get; set; }
        [Column("price_per_day", TypeName = "decimal(10, 2)")]
        public decimal? PricePerDay { get; set; }
        [Column("price_per_stay", TypeName = "decimal(10, 2)")]
        public decimal? PricePerStay { get; set; }
        [Column("tax_paid", TypeName = "decimal(10, 2)")]
        public decimal? TaxPaid { get; set; }
        [Column("site_fees", TypeName = "decimal(10, 2)")]
        public decimal? SiteFees { get; set; }
        [Column("amount_paid", TypeName = "decimal(10, 2)")]
        public decimal? AmountPaid { get; set; }
        [Column("is_refund")]
        public bool? IsRefund { get; set; }
        [Column("cancel_date", TypeName = "datetime")]
        public DateTime? CancelDate { get; set; }
        [Column("refund_paid", TypeName = "decimal(10, 2)")]
        public decimal? RefundPaid { get; set; }
        [Column("booking_date", TypeName = "datetime")]
        public DateTime? BookingDate { get; set; }
        [Column("created", TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column("modified", TypeName = "datetime")]
        public DateTime? Modified { get; set; }
        [Column("status")]
        public bool? Status { get; set; }
        [Column("rooms_count", TypeName = "tinyint")]
        public byte? RoomsCount { get; set; }
        [Column("guests_count", TypeName = "tinyint")]
        public byte? GuestCount { get; set; }
        [Column("children_count", TypeName = "tinyint")]
        public byte? ChildrenCount { get; set; }

        [ForeignKey("PropertyId")]
        [InverseProperty("ArBookings")]
        public virtual ArProperties Property { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("ArBookings")]
        public virtual ArUsers User { get; set; }
        [InverseProperty("Booking")]
        public virtual ICollection<ArDisputes> ArDisputes { get; set; }
        [InverseProperty("Booking")]
        public virtual ICollection<ArPropertyReviews> ArPropertyReviews { get; set; }
    }
}