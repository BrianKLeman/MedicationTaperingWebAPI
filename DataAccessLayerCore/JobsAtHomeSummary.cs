using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Keyless]
public partial class JobsAtHomeSummary 
{
    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("JOB_ID")]
    public uint JobId { get; set; }

    [Column("JOB")]
    [StringLength(45)]
    public string? Job { get; set; }

    [Column("DATE_COMPLETED", TypeName = "datetime")]
    public DateTime? DateCompleted { get; set; }
}
