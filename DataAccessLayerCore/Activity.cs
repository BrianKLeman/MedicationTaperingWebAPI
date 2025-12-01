using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("activities")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
public partial class Activity  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("DETAILS")]
    [StringLength(255)]
    public string? Details { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("CREATED_BY")]
    [StringLength(3)]
    public string? CreatedBy { get; set; }
}
