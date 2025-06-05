using TableAttribute = LinqToDB.Mapping.TableAttribute;
using System;
using System.ComponentModel.DataAnnotations;
using ColumnAttribute = LinqToDB.Mapping.ColumnAttribute;
using PrimaryKeyAttribute = LinqToDB.Mapping.PrimaryKeyAttribute;
using Data.Services.Interfaces.IModels;
namespace DataAccessLayer.Models
{
    
    public interface IPersonID
    {
        long PersonID { get; set; }
    }

    public interface IId
    {
        long Id { get; set; }
    }

    

    [Table(Name = "MEDICATION", Database = "medication_taper_database")]
    public class Medication : IPersonID, IId
    {
        [Column(Name = "MEDICATION_ID", IsPrimaryKey = true)]
        public long Id { get; set; }

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
    public class Prescription : IPersonID, IId
    {
        [Column(Name = "PRESCRIPTION_ID", IsPrimaryKey = true)]
        public long Id { get; set; }

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
    public class People : IPersonID, IId
    {
        [Column(Name = "PEOPLE_ID", IsPrimaryKey = true)]
        public long Id { get; set; }

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
    public class Notes : IPersonID, IId, INote
    {
        [Column(Name = "NOTE_ID", IsPrimaryKey = true)]
        public long Id { get; set; }

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
        public DateTime? UpdatedDate { get; set; }

        [Column(Name = "RECORDED_DATE")]
        public DateTime? RecordedDate { get; set; }

        [Column(Name = "BEHAVIOR_CHANGE_NEEDED")]
        public int BehaviorChange { get; set; }

        [Column(Name = "DISPLAY_AS_HTML")]
        public bool DisplayAsHTML { get; set; }


        [Column(Name = "PERSONAL")]
        public int Personal { get; set; }
    }

    [Table(Name = "PROJECTS", Database = "medication_taper_database")]
    public class Projects : IPersonID, IId
    {
        [Column(Name = "PROJECT_ID", IsPrimaryKey = true)]
        public long Id { get; set; }

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

        [Column(Name = "PERSONAL")]
        public int Personal { get; set; }
    }

    [Table(Name = "LEARNING_AIMS", Database = "medication_taper_database")]
    public class LearningAims : IPersonID, IId
    {
        [Column(Name = "LEARNING_AIM_ID", IsPrimaryKey = true)]
        public long Id { get; set; }

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
    public class ShoppingItems : IPersonID, IId
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

        [Column(Name = "CREATED_DATE", CanBeNull = true)]
        public DateTime? CreatedDate { get; set; }

        [Column(Name = "CREATED_BY")]
        public string CreatedBy { get; set; }


        [Column(Name = "PERSONAL")]
        public int Personal { get; set; }
    }

    [Table(Name = "TASKS", Database = "medication_taper_database")]
    public class Tasks : IPersonID, IId
    {
        [Column(Name = "TASK_ID", IsPrimaryKey = true)]
        public long Id { get; set; }

        [Column(Name = "TASK_NAME", CanBeNull = true)]
        public string TaskName { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime? CreatedDate { get; set; }

        [Column(Name = "CREATED_BY")]
        public string CreatedBy { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "DUE_DATE")]
        public DateTime? DueDate { get; set; }

        [Column(Name = "DESCRIPTION", CanBeNull = true)]
        public string Description { get; set; }

        [Column(Name = "DATE_COMPLETED")]
        public string DateCompleted { get; set; }

        [Column(Name = "PRIORITY")]
        public decimal Priority { get; set; }

        [Column(Name = "STATUS")]
        public string Status { get; set; }

        [Column(Name = "PERSONAL")]
        public int Personal { get; set; }

        [Column(Name = "DIFFICULTY")]
        public int Difficulty { get; set; }

        [Column(Name = "REQUIRES_LEARNING")]
        public int RequiresLearning { get; set; }

        [Column(Name = "ACCEPTANCE_CRITERIA")]
        public string AcceptanceCriteria { get; set; }
    }

    [Table(Name = "TABLE_TASK_LINKS", Database = "medication_taper_database")]
    public class TableTaskLinks : IPersonID, IId
    {
        [Column(Name = "TABLE_TASK_LINKS_ID", IsPrimaryKey = true)]
        public long Id { get; set; }

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
    public class Sleeps : IPersonID, IId
    {
        [Column(Name = "SLEEP_ID", IsPrimaryKey = true)]
        public long Id { get; set; }
        
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
    public class TableNotesLinks : IPersonID, IId
    {
        [Column(Name = "TABLE_NOTES_LINKS_ID", IsPrimaryKey = true)]
        public long Id { get; set; }

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
    public class Phenomena : IPersonID, IId
    {
        [Column(Name = "PHENOMENA_ID", IsPrimaryKey = true)]
        public long Id { get; set; }

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
    public class AuthTokens : IPersonID, IId
    {
        [Column(Name = "TOKEN_ID", IsPrimaryKey = true)]
        public long Id { get; set; }

        [Column(Name = "PEOPLE_ID")]
        public long PersonID { get; set; }

        [Column(Name = "AUTH_TOKEN")]
        public string AuthToken { get; set; }

        [Column(Name = "TOKEN_DATE")]
        public DateTime TokenDate { get; set; }       
    }

    [Table(Name = "APPOINTMENTS", Database = "medication_taper_database")]
    public class Appointments : IPersonID, IId
    {
        [Column(Name = "APPOINTMENT_ID", IsPrimaryKey = true)]
        public long Id { get; set; }

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
    public class JobsAtHome : IPersonID, IId
    {
        [Column(Name = "JOBS_AT_HOME_ID", IsPrimaryKey = true)]
        public long Id { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "JOB")]
        public string Job { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime CreatedDate { get; set; }
    }

    [Table(Name = "JOBS_AT_HOME_LOG", Database = "medication_taper_database")]
    public class JobsAtHomeLog : IPersonID, IId
    {
        [Column(Name = "JOBS_AT_HOME_LOG_ID", IsPrimaryKey = true)]
        public long Id { get; set; }

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

    [Table(Name = "JOBS_AT_HOME_SUMMARY", Database = "medication_taper_database")]
    public class JobsAtHomeSummaryView : IPersonID, IId
    {
        [Column(Name = "JOB_ID")]
        public long Id { get; set; }

        [Column(Name = "JOB")]
        public string Job { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "DATE_COMPLETED")]
        public DateTime DateCompleted { get; set; }
    }

    [Table(Name = "GROUPS", Database = "medication_taper_database")]
    public class Groups : IId, IPersonID
    {
        [PrimaryKey]
        [Column(Name="ID")]
        public long Id { get; set; }

        [Column(Name="PERSON_ID")]
        public long PersonID { get; set; }  
        
        [Column(Name="NAME")]
        public string Name { get; set; }
    }

    [Table(Name = "ALCOHOL", Database = "medication_taper_database")]
    public class Alcohol : IId, IPersonID
    {
        [PrimaryKey]
        [Column(Name = "ALCOHOL_ID")]
        public long Id { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "DETAILS")]
        public string Details { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "CREATED_USER")]
        public string CreatedUser { get; set; }

        [Column(Name = "CONSUMED_DATE")]
        public DateTime ConsumedDate { get; set; }

        [Column(Name = "PERSONAL")]
        public int Personal { get; set; }
    }

    [Table(Name = "SPRINTS", Database = "medication_taper_database")]
    public class Sprint : IId, IPersonID
    {
        [PrimaryKey]
        [Column(Name = "ID")]
        public long Id { get; set; }

        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }

        [Column(Name = "NAME")]
        public string Name { get; set; }

        [Column(Name = "DESCRIPTION")]
        public string Description { get; set; }

        [Column(Name = "START_DATE")]
        public DateTime? StartDate { get; set; }

        [Column(Name = "END_DATE")]
        public DateTime? EndDate { get; set; }        
    }

    [Table(Name = "ADHOC_TABLE", Database = "medication_taper_database")]
    public class AdhocTable : IId, IPersonID
    {
        [PrimaryKey]
        [Column(Name = "ID")]
        public long Id { get; set; }

        [Required]
        [Column(Name = "PERSON_ID")]
        public long PersonID { get; set; }


        [Column(Name = "PROJECT_ID")]
        public long ProjectID { get; set; }

        [Column(Name = "NAME")]
        public string Name { get; set; }
    }

    [Table(Name = "ADHOC_TABLE_COLUMN", Database = "medication_taper_database")]
    public class AdhocTableColumn : IId
    {
        [PrimaryKey]
        [Column(Name = "ID")]
        public long Id { get; set; }
        
        [Column(Name = "ADHOC_TABLE_ID")]
        [Required]
        public long AdhocTableID { get; set; }

        [Column(Name = "NAME")]
        public string Name { get; set; }

        [Column(Name = "ORDER")]
        public int Order { get; set; }
    }

    [Table(Name = "ADHOC_TABLE_ROW", Database = "medication_taper_database")]
    public class AdhocTableRow : IId
    {
        [PrimaryKey]
        public long Id { get; set; }

        [Column(Name = "ADHOC_TABLE_ID")]
        [Required]
        public long AdhocTableID { get; set; }

        [Required]
        [Column(Name = "NAME")]
        public string Name { get; set; }
    }

    [Table(Name = "ADHOC_DETAIL", Database = "medication_taper_database")]
    public class AdhocTablesDetail : IId
    {
        [Column(Name = "ID")]
        [PrimaryKey]
        public long Id { get; set; }

        [Column(Name = "ADHOC_TABLE_ID")]
        [Required]
        public long AdhocTableID { get; set; }

        [Column(Name = "ADHOC_TABLE_ROW_ID")]
        [Required]
        public long AdhocTableRowID { get; set; }

        [Column(Name = "ADHOC_TABLE_COLUMN_ID")]
        [Required]
        public long AdhocTableColumnID { get; set; }

        [Column(Name = "Details")]
        public string Details { get; set; }
    }
}
