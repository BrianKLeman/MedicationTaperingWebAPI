using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

/// <summary>
/// PEOPLE FOR Person&apos;s
/// </summary>
[Index("PEOPLE_ANON", Name = "PEOPLE_ANON_UNIQUE", IsUnique = true)]
[Index("READONLY_ANON", Name = "READONLY_ANON_UNIQUE", IsUnique = true)]
public partial class person
{
    [Key]
    public uint PEOPLE_ID { get; set; }

    [StringLength(8)]
    public string? PEOPLE_ANON { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    [StringLength(3)]
    public string? CREATED_BY { get; set; }

    [StringLength(3)]
    public string? UPDATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UPDATED_DATE { get; set; }

    [StringLength(45)]
    public string? PASSWORD { get; set; }

    [StringLength(45)]
    public string? READONLY_ANON { get; set; }

    [InverseProperty("PERSON")]
    public virtual ICollection<medication> medications { get; set; } = new List<medication>();

    [InverseProperty("PERSON")]
    public virtual ICollection<note> notes { get; set; } = new List<note>();
}
