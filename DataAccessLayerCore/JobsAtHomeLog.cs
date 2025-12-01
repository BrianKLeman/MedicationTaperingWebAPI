using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("jobs_at_home_log")]
[Index("Id", Name = "JOBS_AT_HOME_LOG_ID_UNIQUE", IsUnique = true)]
public partial class JobsAtHomeLog  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("CREATED_BY")]
    [StringLength(45)]
    public string CreatedBy { get; set; } = null!;

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("DATE_COMPLETED", TypeName = "datetime")]
    public DateTime? DateCompleted { get; set; }

    [Column("JOBS_AT_HOME_ID")]
    public uint JobsAtHomeId { get; set; }
}
