using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

public partial class medication_taper_databaseContext : DbContext
{
    public medication_taper_databaseContext()
    {
    }

    public medication_taper_databaseContext(DbContextOptions<medication_taper_databaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<activities_log> activities_logs { get; set; }

    public virtual DbSet<activity> activities { get; set; }

    public virtual DbSet<adhoc_detail> adhoc_details { get; set; }

    public virtual DbSet<adhoc_table> adhoc_tables { get; set; }

    public virtual DbSet<adhoc_table_column> adhoc_table_columns { get; set; }

    public virtual DbSet<adhoc_table_row> adhoc_table_rows { get; set; }

    public virtual DbSet<alcohol> alcohols { get; set; }

    public virtual DbSet<appointment> appointments { get; set; }

    public virtual DbSet<auth_token> auth_tokens { get; set; }

    public virtual DbSet<expense> expenses { get; set; }

    public virtual DbSet<group> groups { get; set; }

    public virtual DbSet<jobs_at_home> jobs_at_homes { get; set; }

    public virtual DbSet<jobs_at_home_frequency> jobs_at_home_frequencies { get; set; }

    public virtual DbSet<jobs_at_home_log> jobs_at_home_logs { get; set; }

    public virtual DbSet<jobs_at_home_summary> jobs_at_home_summaries { get; set; }

    public virtual DbSet<learning_aim> learning_aims { get; set; }

    public virtual DbSet<meal> meals { get; set; }

    public virtual DbSet<medication> medications { get; set; }

    public virtual DbSet<note> notes { get; set; }

    public virtual DbSet<person> people { get; set; }

    public virtual DbSet<phenomenon> phenomena { get; set; }

    public virtual DbSet<prescription> prescriptions { get; set; }

    public virtual DbSet<project> projects { get; set; }

    public virtual DbSet<shopping_item> shopping_items { get; set; }

    public virtual DbSet<sleep> sleeps { get; set; }

    public virtual DbSet<sprint> sprints { get; set; }

    public virtual DbSet<table_notes_link> table_notes_links { get; set; }

    public virtual DbSet<table_task_link> table_task_links { get; set; }

    public virtual DbSet<task> tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=127.0.0.1;Port=3306;Database=medication_taper_database;Uid=rbupyowxvz;Pwd=C0deFus!0n#850122;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<activities_log>(entity =>
        {
            entity.HasKey(e => e.ACTIVITIES_LOG_ID).HasName("PRIMARY");
        });

        modelBuilder.Entity<activity>(entity =>
        {
            entity.HasKey(e => e.ACTIVITY_ID).HasName("PRIMARY");
        });

        modelBuilder.Entity<adhoc_detail>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PRIMARY");

            entity.HasOne(d => d.ADHOC_TABLE_COLUMN).WithMany(p => p.adhoc_details)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TABLE_COLUMN_ID_FK");

            entity.HasOne(d => d.ADHOC_TABLE).WithMany(p => p.adhoc_details)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TABLE_FK");

            entity.HasOne(d => d.ADHOC_TABLE_ROW).WithMany(p => p.adhoc_details)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TABLE_ROW_ID_FK");
        });

        modelBuilder.Entity<adhoc_table>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PRIMARY");
        });

        modelBuilder.Entity<adhoc_table_column>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PRIMARY");

            entity.HasOne(d => d.ADHOC_TABLE).WithMany(p => p.adhoc_table_columns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ADHOC_TABLE_ID_FK");
        });

        modelBuilder.Entity<adhoc_table_row>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PRIMARY");

            entity.HasOne(d => d.ADHOC_TABLE).WithMany(p => p.adhoc_table_rows)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ROW_ADHOC_TABLE_ID_FK");
        });

        modelBuilder.Entity<alcohol>(entity =>
        {
            entity.HasKey(e => e.ALCOHOL_ID).HasName("PRIMARY");

            entity.Property(e => e.CREATED_DATE).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.PERSONAL).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<appointment>(entity =>
        {
            entity.HasKey(e => e.APPOINTMENT_ID).HasName("PRIMARY");
        });

        modelBuilder.Entity<auth_token>(entity =>
        {
            entity.HasKey(e => e.TOKEN_ID).HasName("PRIMARY");
        });

        modelBuilder.Entity<expense>(entity =>
        {
            entity.HasKey(e => e.EXPENSES_ID).HasName("PRIMARY");
        });

        modelBuilder.Entity<group>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PRIMARY");
        });

        modelBuilder.Entity<jobs_at_home>(entity =>
        {
            entity.HasKey(e => e.JOBS_AT_HOME_ID).HasName("PRIMARY");
        });

        modelBuilder.Entity<jobs_at_home_frequency>(entity =>
        {
            entity.ToView("jobs_at_home_frequency");
        });

        modelBuilder.Entity<jobs_at_home_log>(entity =>
        {
            entity.HasKey(e => e.JOBS_AT_HOME_LOG_ID).HasName("PRIMARY");

            entity.Property(e => e.CREATED_BY).HasDefaultValueSql("'NOT SET'");
            entity.Property(e => e.CREATED_DATE).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<jobs_at_home_summary>(entity =>
        {
            entity.ToView("jobs_at_home_summary");
        });

        modelBuilder.Entity<learning_aim>(entity =>
        {
            entity.HasKey(e => e.LEARNING_AIM_ID).HasName("PRIMARY");

            entity.Property(e => e.CREATED_DATE).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<meal>(entity =>
        {
            entity.HasKey(e => e.MEALS_ID).HasName("PRIMARY");
        });

        modelBuilder.Entity<medication>(entity =>
        {
            entity.HasKey(e => e.MEDICATION_ID).HasName("PRIMARY");

            entity.ToTable("medication", tb => tb.HasComment("MedicationTaken Dates and Dosage"));

            entity.Property(e => e.CREATED_DATE).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.PERSON).WithMany(p => p.medications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PERSON_ID_PEOPLE_ID_MED_ID_FK");

            entity.HasOne(d => d.PRESCRIPTION).WithMany(p => p.medications).HasConstraintName("PRESCRIPTION_ID_MEDICATION_FK");
        });

        modelBuilder.Entity<note>(entity =>
        {
            entity.HasKey(e => e.NOTE_ID).HasName("PRIMARY");

            entity.ToTable(tb => tb.HasComment("Notes by person"));

            entity.Property(e => e.BEHAVIOR_CHANGE_NEEDED).HasDefaultValueSql("'0'");
            entity.Property(e => e.CREATED_DATE).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.DISPLAY_AS_HTML).HasDefaultValueSql("'0'");
            entity.Property(e => e.PERSONAL).HasDefaultValueSql("'0'");
            entity.Property(e => e.TEXT).HasComment("RANDOM_NOTES");

            entity.HasOne(d => d.PERSON).WithMany(p => p.notes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PERSON_ID_PEOPLE_ID_FK");
        });

        modelBuilder.Entity<person>(entity =>
        {
            entity.HasKey(e => e.PEOPLE_ID).HasName("PRIMARY");

            entity.ToTable(tb => tb.HasComment("PEOPLE FOR Person's"));

            entity.Property(e => e.UPDATED_DATE).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<phenomenon>(entity =>
        {
            entity.HasKey(e => e.PHENOMENA_ID).HasName("PRIMARY");

            entity.Property(e => e.CREATED_DATE).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<prescription>(entity =>
        {
            entity.HasKey(e => e.PRESCRIPTION_ID).HasName("PRIMARY");

            entity.ToTable(tb => tb.HasComment("PRESCRIBED MEDICATION"));
        });

        modelBuilder.Entity<project>(entity =>
        {
            entity.HasKey(e => e.PROJECT_ID).HasName("PRIMARY");

            entity.Property(e => e.PERSONAL).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<shopping_item>(entity =>
        {
            entity.HasKey(e => e.ITEM_ID).HasName("PRIMARY");

            entity.Property(e => e.PERSONAL).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<sleep>(entity =>
        {
            entity.HasKey(e => e.SLEEP_ID).HasName("PRIMARY");
        });

        modelBuilder.Entity<sprint>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PRIMARY");
        });

        modelBuilder.Entity<table_notes_link>(entity =>
        {
            entity.HasKey(e => e.TABLE_NOTES_LINKS_ID).HasName("PRIMARY");

            entity.ToTable(tb => tb.HasComment("Phenomena Notes Links"));

            entity.Property(e => e.CREATED_DATE).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.PERSON_ID_ADDED_DATE).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UPDATED_DATE).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<table_task_link>(entity =>
        {
            entity.HasKey(e => e.TABLE_TASK_LINKS_ID).HasName("PRIMARY");
        });

        modelBuilder.Entity<task>(entity =>
        {
            entity.HasKey(e => e.TASK_ID).HasName("PRIMARY");

            entity.Property(e => e.CREATED_DATE).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.PERSONAL).HasDefaultValueSql("'0'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
