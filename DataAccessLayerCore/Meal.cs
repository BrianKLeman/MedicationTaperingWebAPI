using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("meals")]
[Index("Id", Name = "MEALS_ID_UNIQUE", IsUnique = true)]
public partial class Meal  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("DETAILS")]
    [StringLength(255)]
    public string? Details { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("CREATED_BY")]
    [StringLength(3)]
    public string? CreatedBy { get; set; }

    [Column("EATEN_DATE", TypeName = "datetime")]
    public DateTime? EatenDate { get; set; }

    [Column("SERVED_N_PEOPLE")]
    public uint ServedNPeople { get; set; }
}
