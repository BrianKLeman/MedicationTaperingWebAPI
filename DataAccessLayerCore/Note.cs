using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

/// <summary>
/// Notes by person
/// </summary>
[Index("PERSON_ID", Name = "PERSON_ID_PEOPLE_ID_FK")]
public partial class note
{
    [Key]
    public uint NOTE_ID { get; set; }

    /// <summary>
    /// RANDOM_NOTES
    /// </summary>
    [Column(TypeName = "text")]
    public string? TEXT { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    [StringLength(3)]
    public string? CREATED_USER { get; set; }

    public uint PERSON_ID { get; set; }

    [StringLength(3)]
    public string? UPDATED_USER { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RECORDED_DATE { get; set; }

    public sbyte? BEHAVIOR_CHANGE_NEEDED { get; set; }

    public sbyte? DISPLAY_AS_HTML { get; set; }

    public sbyte? PERSONAL { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UPDATED_DATE { get; set; }

    [ForeignKey("PERSON_ID")]
    [InverseProperty("notes")]
    public virtual person PERSON { get; set; } = null!;
}
