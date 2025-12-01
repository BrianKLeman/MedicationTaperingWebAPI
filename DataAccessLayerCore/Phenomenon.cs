using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("phenomena")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
public partial class Phenomenon  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("PHENOMENA_DETAILS", TypeName = "text")]
    public string? PhenomenaDetails { get; set; }

    [Column("CREATED_USER")]
    [StringLength(3)]
    public string? CreatedUser { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("UPDATED_BY")]
    [StringLength(3)]
    public string? UpdatedBy { get; set; }

    [Column("UPDATED_DATE", TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }
}
