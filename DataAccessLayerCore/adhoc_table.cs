using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Table("adhoc_table")]
[Index("ID", Name = "ID_UNIQUE", IsUnique = true)]
public partial class adhoc_table
{
    [Key]
    public int ID { get; set; }

    public int PERSON_ID { get; set; }

    public int PROJECT_ID { get; set; }

    [StringLength(45)]
    public string? NAME { get; set; }

    [InverseProperty("ADHOC_TABLE")]
    public virtual ICollection<adhoc_detail> adhoc_details { get; set; } = new List<adhoc_detail>();

    [InverseProperty("ADHOC_TABLE")]
    public virtual ICollection<adhoc_table_column> adhoc_table_columns { get; set; } = new List<adhoc_table_column>();

    [InverseProperty("ADHOC_TABLE")]
    public virtual ICollection<adhoc_table_row> adhoc_table_rows { get; set; } = new List<adhoc_table_row>();
}
