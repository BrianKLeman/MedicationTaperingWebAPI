using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("activities_log")]
[Index("Id", Name = "ACTIVITIES_LOG_ID_UNIQUE", IsUnique = true)]
public partial class ActivitiesLog  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("DATE_COMPLETED", TypeName = "datetime")]
    public DateTime? DateCompleted { get; set; }

    [Column("CREATED_BY")]
    [StringLength(3)]
    public string? CreatedBy { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("ACTIVITIES_ID")]
    public int ActivitiesId { get; set; }
}
