using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

/// <summary>
/// PEOPLE FOR Person&apos;s
/// </summary>
[Table("people")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
[Index("PeopleAnon", Name = "PEOPLE_ANON_UNIQUE", IsUnique = true)]
[Index("PersonId", Name = "PEOPLE_ID_UNIQUE", IsUnique = true)]
[Index("ReadonlyAnon", Name = "READONLY_ANON_UNIQUE", IsUnique = true)]
public partial class Person  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("PEOPLE_ANON")]
    [StringLength(8)]
    public string? PeopleAnon { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("CREATED_BY")]
    [StringLength(3)]
    public string? CreatedBy { get; set; }

    [Column("UPDATED_BY")]
    [StringLength(3)]
    public string? UpdatedBy { get; set; }

    [Column("UPDATED_DATE", TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    [Column("PASSWORD")]
    [StringLength(45)]
    public string? Password { get; set; }

    [Column("READONLY_ANON")]
    [StringLength(45)]
    public string? ReadonlyAnon { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }
}
