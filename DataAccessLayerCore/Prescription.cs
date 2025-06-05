using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

/// <summary>
/// PRESCRIBED MEDICATION
/// </summary>
public partial class prescription
{
    [Key]
    public uint PRESCRIPTION_ID { get; set; }

    [StringLength(100)]
    public string NAME { get; set; } = null!;

    [Precision(11, 3)]
    public decimal? DOSE_MG { get; set; }

    public int? REASON { get; set; }

    public int? MIN_HALFLIFE_HOURS { get; set; }

    public int? MAX_HALFLIFE_HOURS { get; set; }

    public int? AVERAGE_HALFLIFE_HOURS { get; set; }

    public int PERSON_ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? END_DATE { get; set; }

    [InverseProperty("PRESCRIPTION")]
    public virtual ICollection<medication> medications { get; set; } = new List<medication>();
}
