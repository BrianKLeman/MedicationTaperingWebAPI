using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Keyless]
public partial class MealIngredient 
{
    [Column("ID")]
    public uint Id { get; set; }

    [Column("MEAL_NAME")]
    [StringLength(255)]
    public string? MealName { get; set; }

    [Column("FOOD_ITEM_ID")]
    public uint FoodItemId { get; set; }

    [Column("NAME")]
    [StringLength(45)]
    public string? Name { get; set; }

    [Column("AMOUNT")]
    [Precision(4, 0)]
    public decimal? Amount { get; set; }

    [Column("UNIT")]
    [StringLength(45)]
    public string? Unit { get; set; }

    [Column("KJ_PER_PERSON")]
    [Precision(9, 0)]
    public decimal? KjPerPerson { get; set; }

    [Column("KCAL_PER_PERSON")]
    [Precision(9, 0)]
    public decimal? KcalPerPerson { get; set; }

    [Column("DATE_EATEN", TypeName = "datetime")]
    public DateTime? DateEaten { get; set; }
}
