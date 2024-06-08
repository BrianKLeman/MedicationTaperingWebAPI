using LinqToDB.Mapping;
using System;

namespace DataAccessLayer.Models
{
    
    [Table(Name = "MEDICATION", Database = "medication_taper_database")]
    public class Medication
    {
        [Column(Name = "MEDICATION_ID", IsPrimaryKey = true)]
        public long MedicationID { get; set; }

        [Column(Name = "CREATED_DATE", CanBeNull = true)]
        public DateTime? CreatedDate { get; set; }

        [Column(Name = "CREATED_USER")]
        public string CreatedUser { get; set; }

        [Column(Name = "UPDATED_DATE")]
        public DateTime UpdatedDate { get; set; }

        [Column(Name = "UPDATED_USER", CanBeNull = true)]
        public string UpdatedUser { get; set; }

        [Column(Name = "PRESCRIPTION_ID")]
        public long PrescriptionId { get; set; }

        [Column(Name = "DOSE_TAKEN_MG")]
        public decimal DoseTakenMG { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID;

        [Column(Name = "DATETIME_CONSUMED")]
        public DateTime DateTimeConsumed { get; set; }
    }

    [Table(Name = "PRESCRIPTIONS", Database = "medication_taper_database")]
    public class Prescription
    {
        [Column(Name = "PRESCRIPTION_ID", IsPrimaryKey = true)]
        public long PrescriptionID { get; set; }

        [Column(Name = "NAME", CanBeNull = true)]
        public string Name { get; set; }        

        [Column(Name = "DOSE_MG")]
        public decimal DoseMG { get; set; }

        [Column(Name = "REASON")]
        public string Reason { get; set; }

        [Column(Name = "MIN_HALFLIFE_HOURS", CanBeNull = true)]
        public long MinHalfLifeHours { get; set; }

        [Column(Name = "MAX_HALFLIFE_HOURS")]
        public long MaxHalfLifeHours { get; set; }


        [Column(Name = "AVERAGE_HALFLIFE_HOURS")]
        public long AverageHalfLifeHours { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }        
    }

    [Table(Name = "PEOPLE", Database = "medication_taper_database")]
    public class People
    {
        [Column(Name = "PEOPLE_ID", IsPrimaryKey = true)]
        public long PersonID { get; set; }

        [Column(Name = "PEOPLE_ANON", CanBeNull = true)]
        public string PeopleAnon { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "CREATED_BY")]
        public string CreatedBy { get; set; }

        [Column(Name = "UPDATED_BY", CanBeNull = true)]
        public string UpdatedBy { get; set; }

        [Column(Name = "UPDATED_DATE")]
        public DateTime UpdatedDate { get; set; }


        [Column(Name = "PASSWORD")]
        public string Password { get; set; } 
        
        [Column(Name = "READONLY_ANON")]
        public string ReadOnlyAnon { get; set; }
    }

    [Table(Name = "NOTES", Database = "medication_taper_database")]
    public class Notes
    {
        [Column(Name = "NOTE_ID", IsPrimaryKey = true)]
        public long NoteID { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "TEXT", CanBeNull = true)]
        public string Text { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "CREATED_USER")]
        public string CreatedUser { get; set; }

        [Column(Name = "UPDATED_USER", CanBeNull = true)]
        public string UpdatedUser { get; set; }

        [Column(Name = "UPDATED_DATE")]
        public DateTime UpdatedDate { get; set; }

        [Column(Name = "RECORDED_DATE")]
        public DateTime RecordedDate { get; set; }
    }
}
