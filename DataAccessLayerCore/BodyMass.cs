using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

/// <summary>
/// Keeps track of our Body Mass in Kilograms	
/// </summary>
[Table("body_mass")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
public partial class BodyMass  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("MASS_KG")]
    [Precision(5, 1)]
    public decimal? MassKg { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
}
