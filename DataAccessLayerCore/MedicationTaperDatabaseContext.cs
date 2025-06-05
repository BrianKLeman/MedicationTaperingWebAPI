using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

public partial class MedicationTaperDatabaseContext : DbContext
{
    public MedicationTaperDatabaseContext()
    {
    }

    public MedicationTaperDatabaseContext(DbContextOptions<MedicationTaperDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivitiesLog> ActivitiesLogs { get; set; }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<AdhocDetail> AdhocDetails { get; set; }

    public virtual DbSet<AdhocTable> AdhocTables { get; set; }

    public virtual DbSet<AdhocTableColumn> AdhocTableColumns { get; set; }

    public virtual DbSet<AdhocTableRow> AdhocTableRows { get; set; }

    public virtual DbSet<Alcohol> Alcohols { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AuthToken> AuthTokens { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<JobsAtHome> JobsAtHomes { get; set; }

    public virtual DbSet<JobsAtHomeFrequency> JobsAtHomeFrequencies { get; set; }

    public virtual DbSet<JobsAtHomeLog> JobsAtHomeLogs { get; set; }

    public virtual DbSet<JobsAtHomeSummary> JobsAtHomeSummaries { get; set; }

    public virtual DbSet<LearningAim> LearningAims { get; set; }

    public virtual DbSet<Meal> Meals { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Phenomenon> Phenomena { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ShoppingItem> ShoppingItems { get; set; }

    public virtual DbSet<Sleep> Sleeps { get; set; }

    public virtual DbSet<Sprint> Sprints { get; set; }

    public virtual DbSet<TableNotesLink> TableNotesLinks { get; set; }

    public virtual DbSet<TableTaskLink> TableTaskLinks { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("removed");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivitiesLog>(entity =>
        {
            entity.HasKey(e => e.ActivitiesLogId).HasName("PRIMARY");

            entity.ToTable("activities_log");

            entity.HasIndex(e => e.ActivitiesLogId, "ACTIVITIES_LOG_ID_UNIQUE").IsUnique();

            entity.Property(e => e.ActivitiesLogId).HasColumnName("ACTIVITIES_LOG_ID");
            entity.Property(e => e.ActivitiesId).HasColumnName("ACTIVITIES_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(3)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.DateCompleted)
                .HasColumnType("datetime")
                .HasColumnName("DATE_COMPLETED");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PRIMARY");

            entity.ToTable("activities");

            entity.Property(e => e.ActivityId).HasColumnName("ACTIVITY_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(3)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Details)
                .HasMaxLength(255)
                .HasColumnName("DETAILS");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
        });

        modelBuilder.Entity<AdhocDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("adhoc_detail");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.HasIndex(e => e.AdhocTableColumnId, "TABLE_COLUMN_ID_FK_idx");

            entity.HasIndex(e => e.AdhocTableId, "TABLE_FK_idx");

            entity.HasIndex(e => e.AdhocTableRowId, "TABLE_ROW_ID_FK_idx");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdhocTableColumnId).HasColumnName("ADHOC_TABLE_COLUMN_ID");
            entity.Property(e => e.AdhocTableId).HasColumnName("ADHOC_TABLE_ID");
            entity.Property(e => e.AdhocTableRowId).HasColumnName("ADHOC_TABLE_ROW_ID");
            entity.Property(e => e.Details)
                .HasMaxLength(2048)
                .HasColumnName("DETAILS");

            entity.HasOne(d => d.AdhocTableColumn).WithMany(p => p.AdhocDetails)
                .HasForeignKey(d => d.AdhocTableColumnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TABLE_COLUMN_ID_FK");

            entity.HasOne(d => d.AdhocTable).WithMany(p => p.AdhocDetails)
                .HasForeignKey(d => d.AdhocTableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TABLE_FK");

            entity.HasOne(d => d.AdhocTableRow).WithMany(p => p.AdhocDetails)
                .HasForeignKey(d => d.AdhocTableRowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TABLE_ROW_ID_FK");
        });

        modelBuilder.Entity<AdhocTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("adhoc_table");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("NAME");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
            entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");
        });

        modelBuilder.Entity<AdhocTableColumn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("adhoc_table_column");

            entity.HasIndex(e => e.AdhocTableId, "ADHOC_TABLE_ID_FK_idx");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdhocTableId).HasColumnName("ADHOC_TABLE_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("NAME");
            entity.Property(e => e.Order).HasColumnName("ORDER");

            entity.HasOne(d => d.AdhocTable).WithMany(p => p.AdhocTableColumns)
                .HasForeignKey(d => d.AdhocTableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ADHOC_TABLE_ID_FK");
        });

        modelBuilder.Entity<AdhocTableRow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("adhoc_table_row");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.HasIndex(e => e.AdhocTableId, "ROW_ADHOC_TABLE_ID_FK_idx");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdhocTableId).HasColumnName("ADHOC_TABLE_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("NAME");

            entity.HasOne(d => d.AdhocTable).WithMany(p => p.AdhocTableRows)
                .HasForeignKey(d => d.AdhocTableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ROW_ADHOC_TABLE_ID_FK");
        });

        modelBuilder.Entity<Alcohol>(entity =>
        {
            entity.HasKey(e => e.AlcoholId).HasName("PRIMARY");

            entity.ToTable("alcohol");

            entity.Property(e => e.AlcoholId).HasColumnName("ALCOHOL_ID");
            entity.Property(e => e.ConsumedDate)
                .HasColumnType("datetime")
                .HasColumnName("CONSUMED_DATE");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.CreatedUser)
                .HasMaxLength(3)
                .HasColumnName("CREATED_USER");
            entity.Property(e => e.Details)
                .HasMaxLength(45)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Personal)
                .HasDefaultValueSql("'0'")
                .HasColumnName("PERSONAL");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PRIMARY");

            entity.ToTable("appointments");

            entity.HasIndex(e => e.AppointmentId, "APPOINTMENT_ID_UNIQUE").IsUnique();

            entity.Property(e => e.AppointmentId).HasColumnName("APPOINTMENT_ID");
            entity.Property(e => e.AppointmentDate)
                .HasColumnType("datetime")
                .HasColumnName("APPOINTMENT_DATE");
            entity.Property(e => e.AppointmentName)
                .HasMaxLength(45)
                .HasColumnName("APPOINTMENT_NAME");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(3)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.PeopleId).HasColumnName("PEOPLE_ID");
        });

        modelBuilder.Entity<AuthToken>(entity =>
        {
            entity.HasKey(e => e.TokenId).HasName("PRIMARY");

            entity.ToTable("auth_tokens");

            entity.HasIndex(e => e.TokenId, "TOKEN_ID_UNIQUE").IsUnique();

            entity.Property(e => e.TokenId).HasColumnName("TOKEN_ID");
            entity.Property(e => e.AuthToken1)
                .HasMaxLength(45)
                .HasColumnName("AUTH_TOKEN");
            entity.Property(e => e.PeopleId).HasColumnName("PEOPLE_ID");
            entity.Property(e => e.TokenDate)
                .HasColumnType("datetime")
                .HasColumnName("TOKEN_DATE");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpensesId).HasName("PRIMARY");

            entity.ToTable("expenses");

            entity.Property(e => e.ExpensesId).HasColumnName("EXPENSES_ID");
            entity.Property(e => e.Balance)
                .HasPrecision(10)
                .HasColumnName("BALANCE");
            entity.Property(e => e.DateDue)
                .HasColumnType("datetime")
                .HasColumnName("DATE_DUE");
            entity.Property(e => e.ExpensesName)
                .HasMaxLength(45)
                .HasColumnName("EXPENSES_NAME");
            entity.Property(e => e.OnDay).HasColumnName("ON_DAY");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
            entity.Property(e => e.RegularPayment)
                .HasPrecision(10)
                .HasColumnName("REGULAR_PAYMENT");
            entity.Property(e => e.Reoccuring).HasColumnName("REOCCURING");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("groups");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("NAME");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
        });

        modelBuilder.Entity<JobsAtHome>(entity =>
        {
            entity.HasKey(e => e.JobsAtHomeId).HasName("PRIMARY");

            entity.ToTable("jobs_at_home");

            entity.Property(e => e.JobsAtHomeId).HasColumnName("JOBS_AT_HOME_ID");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Job)
                .HasMaxLength(45)
                .HasColumnName("JOB");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
        });

        modelBuilder.Entity<JobsAtHomeFrequency>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("jobs_at_home_frequency");

            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Job)
                .HasMaxLength(45)
                .HasColumnName("job");
        });

        modelBuilder.Entity<JobsAtHomeLog>(entity =>
        {
            entity.HasKey(e => e.JobsAtHomeLogId).HasName("PRIMARY");

            entity.ToTable("jobs_at_home_log");

            entity.HasIndex(e => e.JobsAtHomeLogId, "JOBS_AT_HOME_LOG_ID_UNIQUE").IsUnique();

            entity.Property(e => e.JobsAtHomeLogId).HasColumnName("JOBS_AT_HOME_LOG_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NOT SET'")
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.DateCompleted)
                .HasColumnType("datetime")
                .HasColumnName("DATE_COMPLETED");
            entity.Property(e => e.JobsAtHomeId).HasColumnName("JOBS_AT_HOME_ID");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
        });

        modelBuilder.Entity<JobsAtHomeSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("jobs_at_home_summary");

            entity.Property(e => e.DateCompleted)
                .HasColumnType("datetime")
                .HasColumnName("DATE_COMPLETED");
            entity.Property(e => e.Job)
                .HasMaxLength(45)
                .HasColumnName("JOB");
            entity.Property(e => e.JobId).HasColumnName("JOB_ID");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
        });

        modelBuilder.Entity<LearningAim>(entity =>
        {
            entity.HasKey(e => e.LearningAimId).HasName("PRIMARY");

            entity.ToTable("learning_aims");

            entity.Property(e => e.LearningAimId).HasColumnName("LEARNING_AIM_ID");
            entity.Property(e => e.AchievedDate)
                .HasColumnType("datetime")
                .HasColumnName("ACHIEVED_DATE");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("NAME");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
            entity.Property(e => e.PriorityWeight)
                .HasPrecision(10, 5)
                .HasColumnName("PRIORITY_WEIGHT");
        });

        modelBuilder.Entity<Meal>(entity =>
        {
            entity.HasKey(e => e.MealsId).HasName("PRIMARY");

            entity.ToTable("meals");

            entity.HasIndex(e => e.MealsId, "MEALS_ID_UNIQUE").IsUnique();

            entity.Property(e => e.MealsId).HasColumnName("MEALS_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(3)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Details)
                .HasMaxLength(255)
                .HasColumnName("DETAILS");
            entity.Property(e => e.EatenDate)
                .HasColumnType("datetime")
                .HasColumnName("EATEN_DATE");
            entity.Property(e => e.PeopleId).HasColumnName("PEOPLE_ID");
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.HasKey(e => e.MedicationId).HasName("PRIMARY");

            entity.ToTable("medication", tb => tb.HasComment("MedicationTaken Dates and Dosage"));

            entity.HasIndex(e => e.PersonId, "PERSON_ID_PEOPLE_ID_MED_ID_FK");

            entity.HasIndex(e => e.PrescriptionId, "PRESCRIPTION_ID_MEDICATION_FK");

            entity.Property(e => e.MedicationId).HasColumnName("MEDICATION_ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.CreatedUser)
                .HasMaxLength(3)
                .HasColumnName("CREATED_USER");
            entity.Property(e => e.DatetimeConsumed)
                .HasColumnType("datetime")
                .HasColumnName("DATETIME_CONSUMED");
            entity.Property(e => e.DoseTakenMg)
                .HasPrecision(10, 3)
                .HasColumnName("DOSE_TAKEN_MG");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
            entity.Property(e => e.PrescriptionId).HasColumnName("PRESCRIPTION_ID");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
            entity.Property(e => e.UpdatedUser)
                .HasMaxLength(3)
                .HasColumnName("UPDATED_USER");

            entity.HasOne(d => d.Person).WithMany(p => p.Medications)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PERSON_ID_PEOPLE_ID_MED_ID_FK");

            entity.HasOne(d => d.Prescription).WithMany(p => p.Medications)
                .HasForeignKey(d => d.PrescriptionId)
                .HasConstraintName("PRESCRIPTION_ID_MEDICATION_FK");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.NoteId).HasName("PRIMARY");

            entity.ToTable("notes", tb => tb.HasComment("Notes by person"));

            entity.HasIndex(e => e.PersonId, "PERSON_ID_PEOPLE_ID_FK");

            entity.Property(e => e.NoteId).HasColumnName("NOTE_ID");
            entity.Property(e => e.BehaviorChangeNeeded)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BEHAVIOR_CHANGE_NEEDED");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.CreatedUser)
                .HasMaxLength(3)
                .HasColumnName("CREATED_USER");
            entity.Property(e => e.DisplayAsHtml)
                .HasDefaultValueSql("'0'")
                .HasColumnName("DISPLAY_AS_HTML");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
            entity.Property(e => e.Personal)
                .HasDefaultValueSql("'0'")
                .HasColumnName("PERSONAL");
            entity.Property(e => e.RecordedDate)
                .HasColumnType("datetime")
                .HasColumnName("RECORDED_DATE");
            entity.Property(e => e.Text)
                .HasComment("RANDOM_NOTES")
                .HasColumnType("text")
                .HasColumnName("TEXT");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
            entity.Property(e => e.UpdatedUser)
                .HasMaxLength(3)
                .HasColumnName("UPDATED_USER");

            entity.HasOne(d => d.Person).WithMany(p => p.Notes)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PERSON_ID_PEOPLE_ID_FK");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PeopleId).HasName("PRIMARY");

            entity.ToTable("people", tb => tb.HasComment("PEOPLE FOR Person's"));

            entity.HasIndex(e => e.PeopleAnon, "PEOPLE_ANON_UNIQUE").IsUnique();

            entity.HasIndex(e => e.ReadonlyAnon, "READONLY_ANON_UNIQUE").IsUnique();

            entity.Property(e => e.PeopleId).HasColumnName("PEOPLE_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(3)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.PeopleAnon)
                .HasMaxLength(8)
                .HasColumnName("PEOPLE_ANON");
            entity.Property(e => e.ReadonlyAnon)
                .HasMaxLength(45)
                .HasColumnName("READONLY_ANON");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(3)
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<Phenomenon>(entity =>
        {
            entity.HasKey(e => e.PhenomenaId).HasName("PRIMARY");

            entity.ToTable("phenomena");

            entity.Property(e => e.PhenomenaId).HasColumnName("PHENOMENA_ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.CreatedUser)
                .HasMaxLength(3)
                .HasColumnName("CREATED_USER");
            entity.Property(e => e.LockedToPersonId).HasColumnName("LOCKED_TO_PERSON_ID");
            entity.Property(e => e.PhenomenaDetails)
                .HasColumnType("text")
                .HasColumnName("PHENOMENA_DETAILS");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(3)
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PRIMARY");

            entity.ToTable("prescriptions", tb => tb.HasComment("PRESCRIBED MEDICATION"));

            entity.Property(e => e.PrescriptionId).HasColumnName("PRESCRIPTION_ID");
            entity.Property(e => e.AverageHalflifeHours).HasColumnName("AVERAGE_HALFLIFE_HOURS");
            entity.Property(e => e.DoseMg)
                .HasPrecision(11, 3)
                .HasColumnName("DOSE_MG");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("END_DATE");
            entity.Property(e => e.MaxHalflifeHours).HasColumnName("MAX_HALFLIFE_HOURS");
            entity.Property(e => e.MinHalflifeHours).HasColumnName("MIN_HALFLIFE_HOURS");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("NAME");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
            entity.Property(e => e.Reason).HasColumnName("REASON");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PRIMARY");

            entity.ToTable("projects");

            entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(45)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("END_DATE");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
            entity.Property(e => e.Personal)
                .HasDefaultValueSql("'0'")
                .HasColumnName("PERSONAL");
            entity.Property(e => e.Priority)
                .HasPrecision(10)
                .HasColumnName("PRIORITY");
            entity.Property(e => e.PriorityWeight)
                .HasPrecision(6, 3)
                .HasColumnName("PRIORITY_WEIGHT");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .HasColumnName("PROJECT_NAME");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("START_DATE");
            entity.Property(e => e.Status)
                .HasPrecision(10)
                .HasColumnName("STATUS");
        });

        modelBuilder.Entity<ShoppingItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PRIMARY");

            entity.ToTable("shopping_items");

            entity.HasIndex(e => e.ItemId, "ITEM_LIST_ID_UNIQUE").IsUnique();

            entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(45)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.DateChecked)
                .HasColumnType("datetime")
                .HasColumnName("DATE_CHECKED");
            entity.Property(e => e.ItemName)
                .HasMaxLength(45)
                .HasColumnName("ITEM_NAME");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
            entity.Property(e => e.Personal)
                .HasDefaultValueSql("'0'")
                .HasColumnName("PERSONAL");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .HasColumnName("STATUS");
        });

        modelBuilder.Entity<Sleep>(entity =>
        {
            entity.HasKey(e => e.SleepId).HasName("PRIMARY");

            entity.ToTable("sleeps");

            entity.HasIndex(e => e.SleepId, "SLEEP_ID_UNIQUE").IsUnique();

            entity.Property(e => e.SleepId).HasColumnName("SLEEP_ID");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.FromDate)
                .HasColumnType("datetime")
                .HasColumnName("FROM_DATE");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
            entity.Property(e => e.ToDate)
                .HasColumnType("datetime")
                .HasColumnName("TO_DATE");
        });

        modelBuilder.Entity<Sprint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sprints");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("END_DATE");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("NAME");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("START_DATE");
        });

        modelBuilder.Entity<TableNotesLink>(entity =>
        {
            entity.HasKey(e => e.TableNotesLinksId).HasName("PRIMARY");

            entity.ToTable("table_notes_links", tb => tb.HasComment("Phenomena Notes Links"));

            entity.HasIndex(e => e.TableNotesLinksId, "TABLE_NOTES_LINKS_ID_UNIQUE").IsUnique();

            entity.Property(e => e.TableNotesLinksId).HasColumnName("TABLE_NOTES_LINKS_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(3)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.EntityId).HasColumnName("ENTITY_ID");
            entity.Property(e => e.NotesId).HasColumnName("NOTES_ID");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
            entity.Property(e => e.PersonIdAddedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("PERSON_ID_ADDED_DATE");
            entity.Property(e => e.Table)
                .HasMaxLength(255)
                .HasColumnName("TABLE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(3)
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<TableTaskLink>(entity =>
        {
            entity.HasKey(e => e.TableTaskLinksId).HasName("PRIMARY");

            entity.ToTable("table_task_links");

            entity.HasIndex(e => e.TableTaskLinksId, "TABLE_TASK_LINKS_ID_UNIQUE").IsUnique();

            entity.Property(e => e.TableTaskLinksId).HasColumnName("TABLE_TASK_LINKS_ID");
            entity.Property(e => e.EntityId).HasColumnName("ENTITY_ID");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
            entity.Property(e => e.TableName)
                .HasMaxLength(45)
                .HasColumnName("TABLE_NAME");
            entity.Property(e => e.TaskId).HasColumnName("TASK_ID");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PRIMARY");

            entity.ToTable("tasks");

            entity.HasIndex(e => e.TaskId, "TASK_ID_UNIQUE").IsUnique();

            entity.Property(e => e.TaskId).HasColumnName("TASK_ID");
            entity.Property(e => e.AcceptanceCriteria)
                .HasColumnType("text")
                .HasColumnName("ACCEPTANCE_CRITERIA");
            entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.DateCompleted)
                .HasColumnType("datetime")
                .HasColumnName("DATE_COMPLETED");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Difficulty).HasColumnName("DIFFICULTY");
            entity.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasColumnName("DUE_DATE");
            entity.Property(e => e.Estimate).HasColumnName("ESTIMATE");
            entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");
            entity.Property(e => e.Personal)
                .HasDefaultValueSql("'0'")
                .HasColumnName("PERSONAL");
            entity.Property(e => e.Priority)
                .HasPrecision(10)
                .HasColumnName("PRIORITY");
            entity.Property(e => e.RequiresLearning).HasColumnName("REQUIRES_LEARNING");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .HasColumnName("STATUS");
            entity.Property(e => e.TaskName)
                .HasMaxLength(255)
                .HasColumnName("TASK_NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
