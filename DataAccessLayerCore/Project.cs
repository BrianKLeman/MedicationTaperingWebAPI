using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("projects")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
public partial class Project  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("PROJECT_NAME")]
    [StringLength(255)]
    public string? ProjectName { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("CREATED_BY")]
    [StringLength(45)]
    public string? CreatedBy { get; set; }

    [Column("STATUS")]
    [Precision(10, 0)]
    public decimal? Status { get; set; }

    [Column("PRIORITY")]
    [Precision(10, 0)]
    public decimal? Priority { get; set; }

    [Column("START_DATE", TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column("END_DATE", TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    [Column("PRIORITY_WEIGHT")]
    [Precision(6, 3)]
    public decimal? PriorityWeight { get; set; }

    [Column("PERSONAL")]
    public sbyte? Personal { get; set; }
}
