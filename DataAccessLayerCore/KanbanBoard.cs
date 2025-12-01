using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

/// <summary>
/// Kanban Board
/// </summary>
[Table("kanban_board")]
[Index("Id", Name = "id_UNIQUE", IsUnique = true)]
public partial class KanbanBoard  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("NAME")]
    [StringLength(45)]
    public string? Name { get; set; }

    [Column("BOARD")]
    [StringLength(45)]
    public string? Board { get; set; }

    /// <summary>
    /// Person ID
    /// </summary>
    [Column("PERSON_ID")]
    public uint PersonId { get; set; }
}
