using System;
using System.Collections.Generic;
using MS_API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MS_API.Data;

public partial class MateoSantosExam1PdbContext : DbContext
{
    public MateoSantosExam1PdbContext()
    {
    }

    public MateoSantosExam1PdbContext(DbContextOptions<MateoSantosExam1PdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MsCerveza> MsCervezas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MateoSantosExam1PDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MsCerveza>(entity =>
        {
            entity.ToTable("MS_Cerveza");

            entity.Property(e => e.MsCervezaId).HasColumnName("MS_CervezaId");
            entity.Property(e => e.MsCervezaDescription).HasColumnName("MS_CervezaDescription");
            entity.Property(e => e.MsCervezaName).HasColumnName("MS_CervezaName");
            entity.Property(e => e.MsDate).HasColumnName("MS_Date");
            entity.Property(e => e.MsEscarchada).HasColumnName("MS_Escarchada");
            entity.Property(e => e.MsPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MS_Price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
