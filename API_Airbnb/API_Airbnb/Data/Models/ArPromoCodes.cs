// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Airbnb.Data.Models
{
    [Table("ar_promo_codes")]
    public partial class ArPromoCodes
    {
        public ArPromoCodes()
        {
            ArTransactions = new HashSet<ArTransactions>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        [StringLength(255)]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("code")]
        [StringLength(5)]
        public string Code { get; set; }
        [Column("discount", TypeName = "decimal(10, 2)")]
        public decimal? Discount { get; set; }
        [Column("created", TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column("modified", TypeName = "datetime")]
        public DateTime? Modified { get; set; }
        [Column("status")]
        public bool? Status { get; set; }

        [InverseProperty("PromoCode")]
        public virtual ICollection<ArTransactions> ArTransactions { get; set; }
    }
}