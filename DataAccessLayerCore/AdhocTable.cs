using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("adhoc_table")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
public partial class AdhocTable  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("PROJECT_ID")]
    public int ProjectId { get; set; }

    [Column("NAME")]
    [StringLength(45)]
    public string? Name { get; set; }
}
