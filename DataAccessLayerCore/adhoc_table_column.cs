using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Table("adhoc_table_column")]
[Index("ADHOC_TABLE_ID", Name = "ADHOC_TABLE_ID_FK_idx")]
[Index("ID", Name = "ID_UNIQUE", IsUnique = true)]
public partial class adhoc_table_column
{
    [Key]
    public int ID { get; set; }

    public int ADHOC_TABLE_ID { get; set; }

    [StringLength(45)]
    public string? NAME { get; set; }

    public int ORDER { get; set; }

    [ForeignKey("ADHOC_TABLE_ID")]
    [InverseProperty("adhoc_table_columns")]
    public virtual adhoc_table ADHOC_TABLE { get; set; } = null!;

    [InverseProperty("ADHOC_TABLE_COLUMN")]
    public virtual ICollection<adhoc_detail> adhoc_details { get; set; } = new List<adhoc_detail>();
}
