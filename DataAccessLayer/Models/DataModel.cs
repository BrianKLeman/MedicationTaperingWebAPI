using LinqToDB.Mapping;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    
    public interface IPersonID
    {
        long PersonID { get; set; }
    }

    [Table(Name = "MEDICATION", Database = "medication_taper_database")]
    public class Medication : IPersonID
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
        public long PersonID { get; set; }

        [Column(Name = "DATETIME_CONSUMED")]
        public DateTime DateTimeConsumed { get; set; }
    }

    [Table(Name = "PRESCRIPTIONS", Database = "medication_taper_database")]
    public class Prescription : IPersonID
    {
        [Column(Name = "PRESCRIPTION_ID", IsPrimaryKey = true)]
        public long PrescriptionID { get; set; }

        [Column(Name = "NAME", CanBeNull = true)]
        public string Name { get; set; }        

        [Column(Name = "DOSE_MG")]
        public decimal DoseMG { get; set; }

        [Column(Name = "REASON", CanBeNull = true)]
        public string Reason { get; set; }

        [Column(Name = "MIN_HALFLIFE_HOURS", CanBeNull = true)]
        public long? MinHalfLifeHours { get; set; }

        [Column(Name = "MAX_HALFLIFE_HOURS", CanBeNull = true)]
        public long? MaxHalfLifeHours { get; set; }


        [Column(Name = "AVERAGE_HALFLIFE_HOURS", CanBeNull = true)]
        public long? AverageHalfLifeHours { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; } 
        
        [Column(Name = "END_DATE")]
        public DateTime? EndDate { get; set; }
    }

    [Table(Name = "PEOPLE", Database = "medication_taper_database")]
    public class People : IPersonID
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
    public class Notes : IPersonID
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

        [Column(Name = "BEHAVIOR_CHANGE_NEEDED")]
        public int BehaviorChange { get; set; }

        [Column(Name = "DISPLAY_AS_HTML")]
        public bool DisplayAsHTML { get; set; }
    }

    [Table(Name = "PROJECTS", Database = "medication_taper_database")]
    public class Projects : IPersonID
    {
        [Column(Name = "PROJECT_ID", IsPrimaryKey = true)]
        public long ProjectID { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "PROJECT_NAME", CanBeNull = true)]
        public string Name { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "CREATED_BY")]
        public string CreatedBy { get; set; }        

        [Column(Name = "PRIORITY")]
        public decimal Priority { get; set; }

        [Column(Name = "STATUS")]
        public decimal Status { get; set; }

        [Column(Name = "START_DATE", CanBeNull = true)]
        public DateTime? StartDate { get; set; }

        [Column(Name = "END_DATE", CanBeNull = true)]
        public DateTime? EndDate { get; set; }
    }

    [Table(Name = "LEARNING_AIMS", Database = "medication_taper_database")]
    public class LearningAims : IPersonID
    {
        [Column(Name = "LEARNING_AIM_ID", IsPrimaryKey = true)]
        public long LearningAimID { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "NAME")]
        public string Name { get; set; }

        [Column(Name = "DESCRIPTION", CanBeNull = true)]
        public string Description { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "ACHIEVED_DATE", CanBeNull = true)]
        public DateTime? AchievedDate { get; set; }       
    }

    [System.Serializable]
    [Table(Name = "SHOPPING_ITEMS", Database = "medication_taper_database")]
    public class ShoppingItems : IPersonID
    {
        [Column(Name = "ITEM_ID", IsPrimaryKey = true)]
        [PrimaryKey]
        public long Id { get; set; }        

        [Column(Name = "ITEM_NAME")]
        public string Name { get; set; }

        [Column(Name = "STATUS", CanBeNull = true)]
        public string Status { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "DATE_CHECKED", CanBeNull = true)]
        public DateTime? DateChecked { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "CREATED_BY")]
        public string CreatedBy { get; set; }
    }

    [Table(Name = "TASKS", Database = "medication_taper_database")]
    public class Tasks : IPersonID
    {
        [Column(Name = "TASK_ID", IsPrimaryKey = true)]
        public long TaskID { get; set; }

        [Column(Name = "TASK_NAME", CanBeNull = true)]
        public string TaskName { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "CREATED_BY")]
        public string CreatedBy { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "DUE_DATE")]
        public DateTime DueDate { get; set; }

        [Column(Name = "DESCRIPTION", CanBeNull = true)]
        public string Description { get; set; }

        [Column(Name = "DATE_COMPLETED")]
        public string DateCompleted { get; set; }

        [Column(Name = "PRIORITY")]
        public decimal Priority { get; set; }

        [Column(Name = "STATUS")]
        public string Status { get; set; }
    }

    [Table(Name = "TABLE_TASK_LINKS", Database = "medication_taper_database")]
    public class TableTaskLinks : IPersonID
    {
        [Column(Name = "TABLE_TASK_LINKS_ID", IsPrimaryKey = true)]
        public long ID { get; set; }

        [Column(Name = "TABLE_NAME")]
        [Required]
        public string TableName { get; set; }

        [Column(Name = "ENTITY_ID")]
        [Required]
        public long EntityID { get; set; }

        [Column(Name = "TASK_ID")]
        [Required]
        public long TaskID { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }        
    }

    [Table(Name = "SLEEPS", Database = "medication_taper_database")]
    public class Sleeps : IPersonID
    {
        [Column(Name = "SLEEP_ID", IsPrimaryKey = true)]
        public long SleepID { get; set; }
        
        public decimal Hours
        {
            get
            {
                var ts = (ToDate - FromDate);
                return ts.Hours + (decimal)ts.Minutes / (decimal)60;
            }
        }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "FROM_DATE")]
        public DateTime FromDate { get; set; }

        [Column(Name = "TO_DATE")]
        public DateTime ToDate { get; set; }        
    }

    [Table(Name = "TABLE_NOTES_LINKS", Database = "medication_taper_database")]
    public class TableNotesLinks : IPersonID
    {
        [Column(Name = "TABLE_NOTES_LINKS_ID", IsPrimaryKey = true)]
        public long NotesLinksID { get; set; }

        [Column(Name = "TABLE")]
        [Required]
        public string Table { get; set; }

        [Column(Name = "NOTES_ID")]
        [Required]
        public long NotesID { get; set; }

        [Column(Name = "ENTITY_ID")]
        [Required]
        public long EntityID { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "CREATED_BY")]
        public string CreatedBy { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime CreatedDate { get; set; }        
    }

    [Table(Name = "PHENOMENA", Database = "medication_taper_database")]
    public class Phenomena : IPersonID
    {
        [Column(Name = "PHENOMENA_ID", IsPrimaryKey = true)]
        public long PhenomenaID { get; set; }

        [Column(Name = "PHENOMENA_DETAILS", CanBeNull = true)]
        public string PhenomenaDetails { get; set; }

        [Column(Name = "LOCKED_TO_PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "CREATED_USER")]
        public string CreatedUser { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime CreatedDate { get; set; }
        
    }

    [Table(Name = "AUTH_TOKENS", Database = "medication_taper_database")]
    public class AuthTokens : IPersonID
    {
        [Column(Name = "TOKEN_ID", IsPrimaryKey = true)]
        public long TokenID { get; set; }

        [Column(Name = "PEOPLE_ID")]
        public long PersonID { get; set; }

        [Column(Name = "AUTH_TOKEN")]
        public string AuthToken { get; set; }

        [Column(Name = "TOKEN_DATE")]
        public DateTime TokenDate { get; set; }       
    }

    [Table(Name = "APPOINTMENTS", Database = "medication_taper_database")]
    public class Appointments : IPersonID
    {
        [Column(Name = "APPOINTMENT_ID", IsPrimaryKey = true)]
        public long AppointmentID { get; set; }

        [Column(Name = "PEOPLE_ID")]
        public long PersonID { get; set; }

        [Column(Name = "APPOINTMENT_NAME")]
        public string AppointmentName { get; set; }

        [Column(Name = "APPOINTMENT_DATE")]
        public DateTime AppointmentDate { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "CREATED_BY")]
        public string CreatedUser { get; set; }
    }

    [Table(Name = "JOBS_AT_HOME", Database = "medication_taper_database")]
    public class JobsAtHome : IPersonID
    {
        [Column(Name = "JOBS_AT_HOME_ID", IsPrimaryKey = true)]
        public long JobsAtHomeID { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "JOB")]
        public string Job { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime CreatedDate { get; set; }
    }

    [Table(Name = "JOBS_AT_HOME_LOG", Database = "medication_taper_database")]
    public class JobsAtHomeLog : IPersonID
    {
        [Column(Name = "JOBS_AT_HOME_LOG_ID", IsPrimaryKey = true)]
        public long JobsAtHomeLogID { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "JOBS_AT_HOME_ID")]
        public long JobID { get; set; }

        [Column(Name = "DATE_COMPLETED")]
        public DateTime DateCompleted { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "CREATED_BY")]
        public string CreatedUser { get; set; }
    }

    [Table(Name = "JOBS_AT_HOME_SUMMARY", Database = "medication_taper_database", IsView = true)]
    public class JobsAtHomeSummaryView : IPersonID
    {
        [Column(Name = "JOB_ID")]
        public long JobID { get; set; }

        [Column(Name = "JOB")]
        public string Job { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "DATE_COMPLETED")]
        public DateTime DateCompleted { get; set; }
    }
}
