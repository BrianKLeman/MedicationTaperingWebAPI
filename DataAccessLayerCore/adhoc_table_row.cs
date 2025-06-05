using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Table("adhoc_table_row")]
[Index("ID", Name = "ID_UNIQUE", IsUnique = true)]
[Index("ADHOC_TABLE_ID", Name = "ROW_ADHOC_TABLE_ID_FK_idx")]
public partial class adhoc_table_row
{
    [Key]
    public int ID { get; set; }

    public int ADHOC_TABLE_ID { get; set; }

    [StringLength(45)]
    public string? NAME { get; set; }

    [ForeignKey("ADHOC_TABLE_ID")]
    [InverseProperty("adhoc_table_rows")]
    public virtual adhoc_table ADHOC_TABLE { get; set; } = null!;

    [InverseProperty("ADHOC_TABLE_ROW")]
    public virtual ICollection<adhoc_detail> adhoc_details { get; set; } = new List<adhoc_detail>();
}
