using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("sprints")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
[Index("PersonId", Name = "PERSON_ID_UNIQUE", IsUnique = true)]
public partial class Sprint  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("NAME")]
    [StringLength(45)]
    public string? Name { get; set; }

    [Column("DESCRIPTION")]
    [StringLength(255)]
    public string? Description { get; set; }

    [Column("START_DATE", TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column("END_DATE", TypeName = "datetime")]
    public DateTime? EndDate { get; set; }
}
