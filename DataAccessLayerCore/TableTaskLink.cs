using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("table_task_links")]
[Index("Id", Name = "TABLE_TASK_LINKS_ID_UNIQUE", IsUnique = true)]
public partial class TableTaskLink  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("TABLE_NAME")]
    [StringLength(45)]
    public string? TableName { get; set; }

    [Column("ENTITY_ID")]
    public int? EntityId { get; set; }

    [Column("TASK_ID")]
    public int? TaskId { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }
}
