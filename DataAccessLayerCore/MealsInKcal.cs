using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Keyless]
public partial class MealsInKcal 
{
    [Column("ID")]
    public uint Id { get; set; }

    [Column("MEAL_NAME")]
    [StringLength(255)]
    public string? MealName { get; set; }

    [Column("KJ_PER_PERSON")]
    [Precision(31, 0)]
    public decimal? KjPerPerson { get; set; }

    [Column("KCAL_PER_PERSON")]
    [Precision(31, 0)]
    public decimal? KcalPerPerson { get; set; }

    [Column("DATE_EATEN", TypeName = "datetime")]
    public DateTime? DateEaten { get; set; }
}
