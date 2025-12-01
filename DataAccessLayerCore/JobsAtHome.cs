using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("jobs_at_home")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
public partial class JobsAtHome  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("JOB")]
    [StringLength(45)]
    public string? Job { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }
}
