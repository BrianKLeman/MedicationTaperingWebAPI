using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("adhoc_table_row")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
public partial class AdhocTableRow  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("ADHOC_TABLE_ID")]
    public uint AdhocTableId { get; set; }

    [Column("NAME")]
    [StringLength(45)]
    public string? Name { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }
}
