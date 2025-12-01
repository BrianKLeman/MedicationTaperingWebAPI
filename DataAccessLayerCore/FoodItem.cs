using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

/// <summary>
/// 		
/// </summary>
[Table("food_items")]
[Index("Id", Name = "id_UNIQUE", IsUnique = true)]
public partial class FoodItem  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("NAME")]
    [StringLength(45)]
    public string? Name { get; set; }

    [Column("KCAL_PER_100")]
    [Precision(6)]
    public decimal? KcalPer100 { get; set; }

    [Column("KJ_PER_100")]
    [Precision(6)]
    public decimal? KjPer100 { get; set; }

    [Column("CARBOHYDRATE_PER_100")]
    [Precision(5)]
    public decimal? CarbohydratePer100 { get; set; }

    [Column("FAT_PER_100")]
    [Precision(5)]
    public decimal? FatPer100 { get; set; }

    [Column("SALT_PER_100")]
    [Precision(5)]
    public decimal? SaltPer100 { get; set; }

    [Column("FIBRE_PER_100")]
    [Precision(5)]
    public decimal? FibrePer100 { get; set; }

    [Column("UNIT")]
    [StringLength(45)]
    public string? Unit { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }
}
