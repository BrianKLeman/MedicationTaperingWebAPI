using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

/// <summary>
/// Phenomena Notes Links
/// </summary>
[Index("TABLE_NOTES_LINKS_ID", Name = "TABLE_NOTES_LINKS_ID_UNIQUE", IsUnique = true)]
public partial class table_notes_link
{
    [Key]
    public uint TABLE_NOTES_LINKS_ID { get; set; }

    [StringLength(255)]
    public string TABLE { get; set; } = null!;

    public int NOTES_ID { get; set; }

    public int PERSON_ID { get; set; }

    [StringLength(3)]
    public string CREATED_BY { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    [StringLength(3)]
    public string? UPDATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UPDATED_DATE { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PERSON_ID_ADDED_DATE { get; set; }

    public uint? ENTITY_ID { get; set; }
}
