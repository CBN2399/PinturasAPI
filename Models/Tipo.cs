﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PinturasAPI.Models
{
    [Table("tipo")]
    public partial class tipo
    {
        public tipo()
        {
            imagens = new HashSet<imagen>();
        }

        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [InverseProperty("idtipoNavigation")]
        public virtual ICollection<imagen> imagens { get; set; }
    }
}