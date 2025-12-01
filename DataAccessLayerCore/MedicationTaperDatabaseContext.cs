using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
namespace test;

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

    public virtual DbSet<BodyMass> BodyMasses { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Feature> Features { get; set; }

    public virtual DbSet<FoodItem> FoodItems { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<JobsAtHome> JobsAtHomes { get; set; }

    public virtual DbSet<JobsAtHomeFrequency> JobsAtHomeFrequencies { get; set; }

    public virtual DbSet<JobsAtHomeLog> JobsAtHomeLogs { get; set; }

    public virtual DbSet<JobsAtHomeSummary> JobsAtHomeSummaries { get; set; }

    public virtual DbSet<KanbanBoard> KanbanBoards { get; set; }

    public virtual DbSet<KanbanColumn> KanbanColumns { get; set; }

    public virtual DbSet<Kcalperday> Kcalperdays { get; set; }

    public virtual DbSet<LearningAim> LearningAims { get; set; }

    public virtual DbSet<Meal> Meals { get; set; }

    public virtual DbSet<MealIngredient> MealIngredients { get; set; }

    public virtual DbSet<MealPart> MealParts { get; set; }

    public virtual DbSet<MealsInKcal> MealsInKcals { get; set; }

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
        { 
             var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddUserSecrets<MedicationTaperDatabaseContext>()
        .Build();
        var myText = configuration.GetConnectionString("taperbase");
        optionsBuilder.UseMySQL(myText);
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivitiesLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<AdhocDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<AdhocTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<AdhocTableColumn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<AdhocTableRow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Alcohol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Personal).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<AuthToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<BodyMass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("body_mass", tb => tb.HasComment("Keeps track of our Body Mass in Kilograms	"));
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Feature>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("features", tb => tb.HasComment("Listed as a swim lane in the kanban board"));
        });

        modelBuilder.Entity<FoodItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("food_items", tb => tb.HasComment("		"));

            entity.Property(e => e.PersonId).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<JobsAtHome>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.PersonId).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<JobsAtHomeFrequency>(entity =>
        {
            entity.ToView("jobs_at_home_frequency");
        });

        modelBuilder.Entity<JobsAtHomeLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'NOT SET'");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<JobsAtHomeSummary>(entity =>
        {
            entity.ToView("jobs_at_home_summary");

            entity.Property(e => e.PersonId).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<KanbanBoard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kanban_board", tb => tb.HasComment("Kanban Board"));

            entity.Property(e => e.PersonId).HasComment("Person ID");
        });

        modelBuilder.Entity<KanbanColumn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kanban_column", tb => tb.HasComment("The column for kanban board"));
        });

        modelBuilder.Entity<Kcalperday>(entity =>
        {
            entity.ToView("kcalperday");
        });

        modelBuilder.Entity<LearningAim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Meal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.ServedNPeople).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<MealIngredient>(entity =>
        {
            entity.ToView("meal_ingredients");
        });

        modelBuilder.Entity<MealPart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("meal_part", tb => tb.HasComment("	"));
        });

        modelBuilder.Entity<MealsInKcal>(entity =>
        {
            entity.ToView("meals_in_kcal");
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("medication", tb => tb.HasComment("MedicationTaken Dates and Dosage"));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Prescription).WithMany(p => p.Medications).HasConstraintName("PRESCRIPTION_ID_MEDICATION_FK");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("notes", tb => tb.HasComment("Notes by person"));

            entity.Property(e => e.BehaviorChangeNeeded).HasDefaultValueSql("'0'");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.DisplayAsHtml).HasDefaultValueSql("'0'");
            entity.Property(e => e.Personal).HasDefaultValueSql("'0'");
            entity.Property(e => e.Text).HasComment("RANDOM_NOTES");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("people", tb => tb.HasComment("PEOPLE FOR Person's"));

            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Phenomenon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("prescriptions", tb => tb.HasComment("PRESCRIBED MEDICATION"));
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Personal).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<ShoppingItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Personal).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<Sleep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Sprint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<TableNotesLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("table_notes_links", tb => tb.HasComment("Phenomena Notes Links"));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.PersonIdAddedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<TableTaskLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Order).HasDefaultValueSql("'1.00'");
            entity.Property(e => e.Personal).HasDefaultValueSql("'0'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
