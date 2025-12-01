using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

/// <summary>
/// The column for kanban board
/// </summary>
[Table("kanban_column")]
[Index("Id", Name = "id_UNIQUE", IsUnique = true)]
public partial class KanbanColumn  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("NAME")]
    [StringLength(45)]
    public string? Name { get; set; }

    [Column("STATUS")]
    [StringLength(45)]
    public string? Status { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }
}
