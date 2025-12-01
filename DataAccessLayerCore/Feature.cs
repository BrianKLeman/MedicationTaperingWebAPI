using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

/// <summary>
/// Listed as a swim lane in the kanban board
/// </summary>
[Table("features")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
public partial class Feature  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("NAME")]
    [StringLength(45)]
    public string? Name { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("PROJECT_ID")]
    public int? ProjectId { get; set; }

    [Column("LEARNING_AIM_ID")]
    public int? LearningAimId { get; set; }
}
