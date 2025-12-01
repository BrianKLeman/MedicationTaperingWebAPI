using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("learning_aims")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
public partial class LearningAim  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("NAME")]
    [StringLength(45)]
    public string? Name { get; set; }

    [Column("DESCRIPTION")]
    [StringLength(255)]
    public string? Description { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("ACHIEVED_DATE", TypeName = "datetime")]
    public DateTime? AchievedDate { get; set; }

    [Column("PRIORITY_WEIGHT")]
    [Precision(10, 5)]
    public decimal? PriorityWeight { get; set; }
}
