using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Index("TABLE_TASK_LINKS_ID", Name = "TABLE_TASK_LINKS_ID_UNIQUE", IsUnique = true)]
public partial class table_task_link
{
    [Key]
    public int TABLE_TASK_LINKS_ID { get; set; }

    [StringLength(45)]
    public string? TABLE_NAME { get; set; }

    public int? ENTITY_ID { get; set; }

    public int? TASK_ID { get; set; }

    public int? PERSON_ID { get; set; }
}
