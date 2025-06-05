using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Table("adhoc_detail")]
[Index("ID", Name = "ID_UNIQUE", IsUnique = true)]
[Index("ADHOC_TABLE_COLUMN_ID", Name = "TABLE_COLUMN_ID_FK_idx")]
[Index("ADHOC_TABLE_ID", Name = "TABLE_FK_idx")]
[Index("ADHOC_TABLE_ROW_ID", Name = "TABLE_ROW_ID_FK_idx")]
public partial class adhoc_detail
{
    [Key]
    public int ID { get; set; }

    public int ADHOC_TABLE_ID { get; set; }

    public int ADHOC_TABLE_ROW_ID { get; set; }

    public int ADHOC_TABLE_COLUMN_ID { get; set; }

    [StringLength(2048)]
    public string? DETAILS { get; set; }

    [ForeignKey("ADHOC_TABLE_ID")]
    [InverseProperty("adhoc_details")]
    public virtual adhoc_table ADHOC_TABLE { get; set; } = null!;

    [ForeignKey("ADHOC_TABLE_COLUMN_ID")]
    [InverseProperty("adhoc_details")]
    public virtual adhoc_table_column ADHOC_TABLE_COLUMN { get; set; } = null!;

    [ForeignKey("ADHOC_TABLE_ROW_ID")]
    [InverseProperty("adhoc_details")]
    public virtual adhoc_table_row ADHOC_TABLE_ROW { get; set; } = null!;
}
