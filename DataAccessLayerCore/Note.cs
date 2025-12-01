using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

/// <summary>
/// Notes by person
/// </summary>
[Table("notes")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
public partial class Note  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    /// <summary>
    /// RANDOM_NOTES
    /// </summary>
    [Column("TEXT", TypeName = "text")]
    public string? Text { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("CREATED_USER")]
    [StringLength(3)]
    public string? CreatedUser { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("UPDATED_USER")]
    [StringLength(3)]
    public string? UpdatedUser { get; set; }

    [Column("RECORDED_DATE", TypeName = "datetime")]
    public DateTime? RecordedDate { get; set; }

    [Column("BEHAVIOR_CHANGE_NEEDED")]
    public sbyte? BehaviorChangeNeeded { get; set; }

    [Column("DISPLAY_AS_HTML")]
    public sbyte? DisplayAsHtml { get; set; }

    [Column("PERSONAL")]
    public sbyte? Personal { get; set; }

    [Column("UPDATED_DATE", TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}
