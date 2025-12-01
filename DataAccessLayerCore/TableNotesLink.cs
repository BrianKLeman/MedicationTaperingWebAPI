using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

/// <summary>
/// Phenomena Notes Links
/// </summary>
[Table("table_notes_links")]
[Index("Id", Name = "TABLE_NOTES_LINKS_ID_UNIQUE", IsUnique = true)]
public partial class TableNotesLink  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("TABLE")]
    [StringLength(255)]
    public string Table { get; set; } = null!;

    [Column("NOTES_ID")]
    public int NotesId { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("CREATED_BY")]
    [StringLength(3)]
    public string CreatedBy { get; set; } = null!;

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("UPDATED_BY")]
    [StringLength(3)]
    public string? UpdatedBy { get; set; }

    [Column("UPDATED_DATE", TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    [Column("PERSON_ID_ADDED_DATE", TypeName = "datetime")]
    public DateTime? PersonIdAddedDate { get; set; }

    [Column("ENTITY_ID")]
    public uint? EntityId { get; set; }
}
