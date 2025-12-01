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
[Table("meal_part")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
public partial class MealPart  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("FOOD_ITEM_ID")]
    public int? FoodItemId { get; set; }

    [Column("AMOUNT_GRAMS")]
    [Precision(5)]
    public decimal? AmountGrams { get; set; }

    [Column("MEAL_ID")]
    [StringLength(45)]
    public string? MealId { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }
}
