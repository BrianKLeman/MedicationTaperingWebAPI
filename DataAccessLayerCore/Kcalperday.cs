using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Keyless]
public partial class Kcalperday 
{
    [Column("MEAL_DATE")]
    [StringLength(72)]
    public string? MealDate { get; set; }

    [Column("SUM(KCAL_PER_PERSON)")]
    [Precision(53, 0)]
    public decimal? SumKcalPerPerson { get; set; }
}
