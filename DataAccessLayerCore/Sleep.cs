using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Index("SLEEP_ID", Name = "SLEEP_ID_UNIQUE", IsUnique = true)]
public partial class sleep
{
    [Key]
    public int SLEEP_ID { get; set; }

    public int PERSON_ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FROM_DATE { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TO_DATE { get; set; }
}
