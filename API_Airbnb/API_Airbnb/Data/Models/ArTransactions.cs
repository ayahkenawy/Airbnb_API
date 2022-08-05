﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Airbnb.Data.Models
{
    [Table("ar_transactions")]
    public partial class ArTransactions
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("property_id")]
        public int? PropertyId { get; set; }
        [Column("reciever_id")]
        [StringLength(255)]
        public string RecieverId { get; set; }
        [Column("booking_id")]
        public int? BookingId { get; set; }
        [Column("site_frees", TypeName = "decimal(10, 2)")]
        public decimal? SiteFrees { get; set; }
        [Column("amount", TypeName = "decimal(10, 0)")]
        public decimal? Amount { get; set; }
        [Column("transfer_on", TypeName = "decimal(10, 2)")]
        public decimal? TransferOn { get; set; }
        [Column("currency_id")]
        public int? CurrencyId { get; set; }
        [Column("promo_code_id")]
        public int? PromoCodeId { get; set; }
        [Column("discound_amt", TypeName = "decimal(10, 2)")]
        public decimal? DiscoundAmt { get; set; }
        [Column("created", TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column("modified", TypeName = "datetime")]
        public DateTime? Modified { get; set; }
        [Column("status")]
        public bool? Status { get; set; }

        [ForeignKey("CurrencyId")]
        [InverseProperty("ArTransactions")]
        public virtual ArCurrencies Currency { get; set; }
        [ForeignKey("PromoCodeId")]
        [InverseProperty("ArTransactions")]
        public virtual ArPromoCodes PromoCode { get; set; }
        [ForeignKey("PropertyId")]
        [InverseProperty("ArTransactions")]
        public virtual ArProperties Property { get; set; }
        [ForeignKey("RecieverId")]
        [InverseProperty("ArTransactions")]
        public virtual ArUsers Reciever { get; set; }
    }
}