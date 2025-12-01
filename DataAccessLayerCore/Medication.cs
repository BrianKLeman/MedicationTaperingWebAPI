using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

/// <summary>
/// MedicationTaken Dates and Dosage
/// </summary>
[Table("medication")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
[Index("PrescriptionId", Name = "PRESCRIPTION_ID_MEDICATION_FK")]
public partial class Medication  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("CREATED_USER")]
    [StringLength(3)]
    public string? CreatedUser { get; set; }

    [Column("UPDATED_DATE", TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [Column("UPDATED_USER")]
    [StringLength(3)]
    public string? UpdatedUser { get; set; }

    [Column("PRESCRIPTION_ID")]
    public uint? PrescriptionId { get; set; }

    [Column("DOSE_TAKEN_MG")]
    [Precision(10, 3)]
    public decimal? DoseTakenMg { get; set; }

    [Column("DATETIME_CONSUMED", TypeName = "datetime")]
    public DateTime? DatetimeConsumed { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [ForeignKey("PrescriptionId")]
    [InverseProperty("Medications")]
    public virtual Prescription? Prescription { get; set; }
}
