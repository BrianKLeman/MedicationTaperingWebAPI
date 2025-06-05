using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

/// <summary>
/// MedicationTaken Dates and Dosage
/// </summary>
[Table("medication")]
[Index("PERSON_ID", Name = "PERSON_ID_PEOPLE_ID_MED_ID_FK")]
[Index("PRESCRIPTION_ID", Name = "PRESCRIPTION_ID_MEDICATION_FK")]
public partial class medication
{
    [Key]
    public uint MEDICATION_ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATED_DATE { get; set; }

    [StringLength(3)]
    public string? CREATED_USER { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UPDATED_DATE { get; set; }

    [StringLength(3)]
    public string? UPDATED_USER { get; set; }

    public uint? PRESCRIPTION_ID { get; set; }

    [Precision(10, 3)]
    public decimal? DOSE_TAKEN_MG { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATETIME_CONSUMED { get; set; }

    public uint PERSON_ID { get; set; }

    [ForeignKey("PERSON_ID")]
    [InverseProperty("medications")]
    public virtual person PERSON { get; set; } = null!;

    [ForeignKey("PRESCRIPTION_ID")]
    [InverseProperty("medications")]
    public virtual prescription? PRESCRIPTION { get; set; }
}
