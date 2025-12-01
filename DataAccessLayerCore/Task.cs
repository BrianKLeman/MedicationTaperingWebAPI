using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("tasks")]
[Index("Id", Name = "TASK_ID_UNIQUE", IsUnique = true)]
public partial class Task  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("TASK_NAME")]
    [StringLength(255)]
    public string? TaskName { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("CREATED_BY")]
    [StringLength(3)]
    public string? CreatedBy { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("STATUS")]
    [StringLength(45)]
    public string? Status { get; set; }

    [Column("DUE_DATE", TypeName = "datetime")]
    public DateTime? DueDate { get; set; }

    [Column("DATE_COMPLETED", TypeName = "datetime")]
    public DateTime? DateCompleted { get; set; }

    [Column("PRIORITY")]
    [Precision(10, 0)]
    public decimal? Priority { get; set; }

    [Column("DESCRIPTION")]
    [StringLength(255)]
    public string? Description { get; set; }

    [Column("PERSONAL")]
    public sbyte? Personal { get; set; }

    [Column("ESTIMATE")]
    public int? Estimate { get; set; }

    [Column("REQUIRES_LEARNING")]
    public sbyte RequiresLearning { get; set; }

    [Column("ACCEPTANCE_CRITERIA", TypeName = "text")]
    public string? AcceptanceCriteria { get; set; }

    [Column("DIFFICULTY")]
    public int Difficulty { get; set; }

    [Column("ORDER")]
    [Precision(10)]
    public decimal Order { get; set; }
}
