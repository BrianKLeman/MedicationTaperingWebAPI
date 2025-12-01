using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

/// <summary>
/// PRESCRIBED MEDICATION
/// </summary>
[Table("prescriptions")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
public partial class Prescription  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("NAME")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("DOSE_MG")]
    [Precision(11, 3)]
    public decimal? DoseMg { get; set; }

    [Column("REASON")]
    public int? Reason { get; set; }

    [Column("MIN_HALFLIFE_HOURS")]
    public int? MinHalflifeHours { get; set; }

    [Column("MAX_HALFLIFE_HOURS")]
    public int? MaxHalflifeHours { get; set; }

    [Column("AVERAGE_HALFLIFE_HOURS")]
    public int? AverageHalflifeHours { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("END_DATE", TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    [InverseProperty("Prescription")]
    public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();
}
